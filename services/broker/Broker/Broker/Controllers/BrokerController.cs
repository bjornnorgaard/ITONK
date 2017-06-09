using System.Linq;
using System.Threading.Tasks;
using Broker.DbModels;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Broker.Controllers
{
    [Route("[action]")]
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
        public async Task<IActionResult> Buy([FromBody] BuyOrder buyOrder)
        {
            var buyRecord = SaveOrderToDatabase(buyOrder);
            var sellRecord = FindMatchingOrder(buyRecord);

            if (sellRecord == null)
            {
                Response.StatusCode = 202;
                return Json(new {status = "No match found. Will buy later."});
            }

            var changeOwnershipObject = new ChangeOwnershipObject
            {
                BuyerId = buyRecord.BuyerId,
                Quantity = sellRecord.Quantity,
                SellerId = sellRecord.SellerId,
                TickerSymbol = sellRecord.TickerSymbol
            };
            if (await _registryService.ChangeOwnershipAsync(changeOwnershipObject) == false)
            {
                Response.StatusCode = 503;
                return Json(new {status = "Could not change ownership."});
            }

            UpdateRecordsOnMatch(sellRecord, buyRecord);

            var taxNotifyObject = new TaxNotifyObject
            {
                SellerId = sellRecord.SellerId,
                TotalPrice = sellRecord.Price * sellRecord.Quantity
            };
            if (await _taxService.InformTaxTobin(taxNotifyObject) == false)
            {
                Response.StatusCode = 503;
                return Json(new {status = "Tax was not applied."});
            }

            Response.StatusCode = 201;
            return Json(new {status = "Match found. Was bought."});
        }

        [HttpPost]
        public async Task<IActionResult> Sell([FromBody] SellOrder sellOrder)
        {
            if (await _registryService.IsValidOwnershipAsync(sellOrder) == false)
            {
                Response.StatusCode = 204;
                return Json(new {status = "Shit ain't valid"});
            }

            var sellRecord = SaveOrderToDatabase(sellOrder);
            var buyRecord = FindMatchingOrder(sellRecord);

            if (buyRecord == null)
            {
                Response.StatusCode = 202;
                return Json(new {status = "No match found. Will be sold later."});
            }

            var changeOwnershipObject = new ChangeOwnershipObject
            {
                BuyerId = buyRecord.BuyerId,
                Quantity = sellRecord.Quantity,
                SellerId = sellRecord.SellerId,
                TickerSymbol = sellRecord.TickerSymbol
            };
            if (await _registryService.ChangeOwnershipAsync(changeOwnershipObject) == false)
            {
                Response.StatusCode = 503;
                return Json(new {status = "Could not change ownership."});
            }

            UpdateRecordsOnMatch(sellRecord, buyRecord);

            var taxNotifyObject = new TaxNotifyObject
            {
                SellerId = sellRecord.SellerId,
                TotalPrice = sellRecord.Price * sellRecord.Quantity
            };
            if (await _taxService.InformTaxTobin(taxNotifyObject) == false)
            {
                Response.StatusCode = 503;
                return Json(new {status = "Tax was not applied."});
            }

            Response.StatusCode = 201;
            return Json(new {status = "Match found. Was sold."});
        }

        private void UpdateRecordsOnMatch(SellRecord sellRecord, BuyRecord buyRecord)
        {
            sellRecord.IsSold = true;
            buyRecord.IsBought = true;

            var transaction = new Transaction
            {
                BuyRecordId = buyRecord.Id,
                SellRecordId = sellRecord.Id
            };

            _context.Update(sellRecord);
            _context.Update(buyRecord);
            _context.Transactions.Add(transaction);

            _context.SaveChanges();
        }

        private BuyRecord FindMatchingOrder(SellRecord sellRecord)
        {
            var findMatchingBuyOrder = _context.BuyRecords
                .Where(b => b.TickerSymbol == sellRecord.TickerSymbol)
                .Where(b => b.Quantity >= sellRecord.Quantity)
                .Where(b => b.IsBought == false)
                .FirstOrDefault(b => b.MaxPrice >= sellRecord.Price);

            return findMatchingBuyOrder;
        }

        private SellRecord FindMatchingOrder(BuyRecord buyRecord)
        {
            var findMatchingBuyOrder = _context.SellRecords
                .Where(s => s.TickerSymbol == buyRecord.TickerSymbol)
                .Where(s => s.Quantity >= buyRecord.Quantity)
                .Where(s => s.IsSold == false)
                .FirstOrDefault(s => s.Price <= buyRecord.MaxPrice);

            return findMatchingBuyOrder;
        }

        private SellRecord SaveOrderToDatabase(SellOrder order)
        {
            var sellRecord = new SellRecord
            {
                SellerId = order.SellerId,
                Price = order.Price,
                Quantity = order.Quantity,
                TickerSymbol = order.TickerSymbol
            };

            _context.SellRecords.Add(sellRecord);
            _context.SaveChanges();

            return sellRecord;
        }

        private BuyRecord SaveOrderToDatabase(BuyOrder order)
        {
            var buyRecord = new BuyRecord()
            {
                BuyerId = order.BuyerId,
                MaxPrice = order.MaxPrice,
                Quantity = order.Quantity,
                TickerSymbol = order.TickerSymbol
            };

            _context.BuyRecords.Add(buyRecord);
            _context.SaveChanges();

            return buyRecord;
        }
    }
}