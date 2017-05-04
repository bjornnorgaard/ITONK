using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Registry.Models;
using Registry.Models.ViewModel;

namespace Registry.Controllers
{
    [Route("[controller]/[action]")]
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
        public IActionResult ChangeOwnership([FromBody] JObject jsonbody)
        {
            BuyViewModel shareViewModel = jsonbody.ToObject<BuyViewModel>();

            if (shareViewModel.BuyerId == 0 || shareViewModel.Quantity == 0 || shareViewModel.SellerId == 0 || string.IsNullOrWhiteSpace(shareViewModel.TickerSymbol))
            {
                Response.StatusCode = 400;
                return Json(new { errorMessage = "Insufficient parameters given" });
            }

            var shares = _context.Shares.Where(share => share.Owner == shareViewModel.SellerId && share.TickerSymbol == shareViewModel.TickerSymbol);

            if (shares.Count() < shareViewModel.Quantity)
                return Json(new { errorMessage = "Insufficient shares owned" });

            var sharesToBeSold = shares.Take(shareViewModel.Quantity);

            foreach (var share in sharesToBeSold)
            {
                share.Owner = shareViewModel.BuyerId;
            }

            _context.Shares.UpdateRange(sharesToBeSold);
            _context.SaveChanges();

            return Json(new { Message = "Shares sold" });
        }
    }
}
