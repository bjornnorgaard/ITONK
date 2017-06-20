using System;
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
            Console.Out.WriteLine($"Received buyorder with " +
                                  $"{nameof(buyOrder.Quantity)}={buyOrder.Quantity}, " +
                                  $"{nameof(buyOrder.TickerSymbol)}={buyOrder.TickerSymbol}, " +
                                  $"{nameof(buyOrder.MaxPrice)}={buyOrder.MaxPrice}");

            var buyRecord = SaveOrderToDatabase(buyOrder);
            var sellRecord = FindMatchingOrder(buyRecord);

            if (sellRecord == null)
            {
                Response.StatusCode = 202;
                var noMatchFoundWillBuyLater = "No match found. Will buy later.";
                Console.Out.WriteLine(noMatchFoundWillBuyLater);
                return Json(new {status = noMatchFoundWillBuyLater});
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
                var couldNotChangeOwnership = "Could not change ownership.";
                Console.Out.WriteLine(couldNotChangeOwnership);
                return Json(new {status = couldNotChangeOwnership});
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
                var taxWasNotApplied = "Tax was not applied.";
                Console.Out.WriteLine(taxWasNotApplied);
                return Json(new {status = taxWasNotApplied});
            }

            Response.StatusCode = 201;
            var matchFoundWasBought = "Match found. Was bought.";
            Console.Out.WriteLine(matchFoundWasBought);
            return Json(new {status = matchFoundWasBought});
        }

        [HttpPost]
        public async Task<IActionResult> Sell([FromBody] SellOrder sellOrder)
        {
            Console.Out.WriteLine($"Received buyorder with " +
                                  $"{nameof(sellOrder.Quantity)}={sellOrder.Quantity}, " +
                                  $"{nameof(sellOrder.TickerSymbol)}={sellOrder.TickerSymbol}, " +
                                  $"{nameof(sellOrder.Price)}={sellOrder.Price}");

            if (await _registryService.IsValidOwnershipAsync(sellOrder) == false)
            {
                Response.StatusCode = 204;
                var shitAinTValid = "Sellorder not valid";
                Console.Out.WriteLine(shitAinTValid);
                return Json(new {status = shitAinTValid});
            }

            var sellRecord = SaveOrderToDatabase(sellOrder);
            var buyRecord = FindMatchingOrder(sellRecord);

            if (buyRecord == null)
            {
                Response.StatusCode = 202;
                var noMatchFoundWillBeSoldLater = "No match found. Will be sold later.";
                Console.Out.WriteLine(noMatchFoundWillBeSoldLater);
                return Json(new {status = noMatchFoundWillBeSoldLater});
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
                var couldNotChangeOwnership = "Could not change ownership.";
                Console.Out.WriteLine(couldNotChangeOwnership);
                return Json(new {status = couldNotChangeOwnership});
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
                var taxWasNotApplied = "Tax was not applied.";
                Console.Out.WriteLine(taxWasNotApplied);
                return Json(new {status = taxWasNotApplied});
            }

            Response.StatusCode = 201;
            var matchFoundWasSold = "Match found. Was sold.";
            Console.Out.WriteLine(matchFoundWasSold);
            return Json(new {status = matchFoundWasSold});
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