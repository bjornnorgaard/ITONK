using System;
using System.Linq;
using System.Threading.Tasks;
using Broker.DbModels;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Broker.Controllers
{
    [Route("[controller]/[action]")]
    public class BrokerController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly ITaxService _taxService;
        private readonly BrokerContext _context;

        public BrokerController(IRegistryService registryService, ITaxService taxService, BrokerContext context)
        {
            _registryService = registryService;
            _taxService = taxService;
            _context = context;
        }

        [HttpPost]
        public Task<IActionResult> Buy([FromBody]BuyOrder value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Sell([FromBody]SellOrder sellOrder)
        {
            if (await _registryService.IsValidOwnershipAsync(sellOrder) == false)
            {
                Response.StatusCode = 200;
                return Json(new { status = "Shit aint valid" });
            }

            var sellRecord = new SellRecord
            {
                SellerId = sellOrder.SellerId,
                Price = sellOrder.Price,
                Quantity = sellOrder.Quantity,
                TickerSymbol = sellOrder.TickerSymbol
            };

            _context.SellRecords.Add(sellRecord);
            _context.SaveChanges();

            var matchingBuyOrders = _context.BuyRecords
                .Where(b => b.TickerSymbol == sellRecord.TickerSymbol)
                .Where(b => b.Quantity >= sellRecord.Quantity)
                .First(b => b.MaxPrice >= sellRecord.Price);

            if (matchingBuyOrders == null)
            {
                Response.StatusCode = 200;
                return Json(new { status = "No match found. Will be sold later." });
            }

            var changeOwnershipObject = new ChangeOwnershipObject
            {
                BuyerId = matchingBuyOrders.BuyerId,
                Quantity = sellRecord.Quantity,
                SellerId = sellRecord.SellerId,
                TickerSymbol = sellRecord.TickerSymbol
            };

            if (await _registryService.ChangeOwnershipAsync(changeOwnershipObject) == false)
            {
                Response.StatusCode = 200;
                return Json(new { status = "Could not change ownership." });
            }

            var transaction = new Transaction
            {
                BuyOrderId = matchingBuyOrders.BuyerId,
                SellOrderId = sellRecord.SellerId
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            var taxNotifyObject = new TaxNotifyObject
            {
                SellerId = sellRecord.SellerId,
                TotalPrice = sellRecord.Price * sellRecord.Quantity
            };

            if (await _taxService.InformTaxGuy(taxNotifyObject) == false)
            {
                Response.StatusCode = 200;
                return Json(new { status = "Tax was not applied." });
            }

            Response.StatusCode = 200;
            return Json(new { status = "Match found. Was sold." });
        }
    }
}
