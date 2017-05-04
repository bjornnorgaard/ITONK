using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Registry.Models;

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
        public void ChangeOwnership([FromBody] JObject jsonbody)
        {

        }
    }
}
