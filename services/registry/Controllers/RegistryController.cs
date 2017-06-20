using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Registry.Models;
using Registry.Models.ViewModel;

namespace Registry.Controllers
{
    [Route("[action]")]
    public class RegistryController : Controller
    {
        private readonly ShareContext _context;

        public RegistryController(ShareContext shareContext)
        {
            _context = shareContext;
        }

        [HttpGet]
        public IActionResult CheckOwnership(string tickerSymbol, int sellerId, int quantity)
        {
            if (string.IsNullOrWhiteSpace(tickerSymbol) || sellerId == 0 || quantity == 0)
            {
                Response.StatusCode = 400;
                var insufficientParametersGiven = "Insufficient parameters given";
                Console.Out.WriteLine(insufficientParametersGiven);
                return Json(new { errorMessage = insufficientParametersGiven });
            }

            var shares = _context.Shares
                .Where(s => s.Owner == sellerId)
                .Where(s => s.TickerSymbol == tickerSymbol);


            var p = shares.Count() >= quantity ? new { Owner = "True" } : new { Owner = "False" };
            Console.Out.WriteLine(p);
            return Json(p);
        }

        [HttpPost]
        public IActionResult ChangeOwnership([FromBody] BuyModel buyModel)
        {
            if (buyModel.BuyerId == 0 || buyModel.Quantity == 0 || buyModel.SellerId == 0 || string.IsNullOrWhiteSpace(buyModel.TickerSymbol))
            {
                Response.StatusCode = 400;
                var insufficientParametersGiven = "Insufficient parameters given";
                Console.Out.WriteLine(insufficientParametersGiven);
                return Json(new { errorMessage = insufficientParametersGiven });
            }

            var shares = _context.Shares.Where(share => share.Owner == buyModel.SellerId && share.TickerSymbol == buyModel.TickerSymbol);

            if (shares.Count() < buyModel.Quantity)
            {
                var insufficientSharesOwned = "Insufficient shares owned";
                Console.Out.WriteLine(insufficientSharesOwned);
                return Json(new { errorMessage = insufficientSharesOwned });
            }

            var sharesToBeSold = shares.Take(buyModel.Quantity);

            foreach (var share in sharesToBeSold)
            {
                share.Owner = buyModel.BuyerId;
            }

            _context.Shares.UpdateRange(sharesToBeSold);
            _context.SaveChanges();

            var sharesSold = "Shares sold";
            Console.Out.WriteLine(sharesSold);
            return Json(new { Message = sharesSold });
        }
    }
}
