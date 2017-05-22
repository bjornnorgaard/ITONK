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
                return Json(new { errorMessage = "Insufficient parameters given" });
            }

            var shares = _context.Shares
                .Where(s => s.Owner == sellerId)
                .Where(s => s.TickerSymbol == tickerSymbol);

            return Json(shares.Count() >= quantity ? new { Owner = "True" } : new { Owner = "False" });
        }

        [HttpPost]
        public IActionResult ChangeOwnership([FromBody] BuyModel buyModel)
        {
            if (buyModel.BuyerId == 0 || buyModel.Quantity == 0 || buyModel.SellerId == 0 || string.IsNullOrWhiteSpace(buyModel.TickerSymbol))
            {
                Response.StatusCode = 400;
                return Json(new { errorMessage = "Insufficient parameters given" });
            }

            var shares = _context.Shares.Where(share => share.Owner == buyModel.SellerId && share.TickerSymbol == buyModel.TickerSymbol);

            if (shares.Count() < buyModel.Quantity)
                return Json(new { errorMessage = "Insufficient shares owned" });

            var sharesToBeSold = shares.Take(buyModel.Quantity);

            foreach (var share in sharesToBeSold)
            {
                share.Owner = buyModel.BuyerId;
            }

            _context.Shares.UpdateRange(sharesToBeSold);
            _context.SaveChanges();

            return Json(new { Message = "Shares sold" });
        }
    }
}
