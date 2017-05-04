using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Registry.Models;

namespace Registry.Controllers
{
    [Route("[controller]/[action]")]
    public class RegistryController : Controller
    {
        private readonly ShareContext context;

        public RegistryController(ShareContext shareContext)
        {
            this.context = shareContext;
        }

        [HttpGet]
        public IActionResult checkOwnership(string tickerSymbol, int sellerId, int quantity)
        {
            if (string.IsNullOrWhiteSpace(tickerSymbol) || sellerId == 0 || quantity == 0)
            {
                Response.StatusCode = 400;
                return Json(new { errorMessage = "Insufficient parameters given" });
            }
            var shares = context.Shares.Where(share => share.Owner == sellerId && share.TickerSymbol == tickerSymbol);

            return Json(shares.Count() >= quantity ? new { Owner = "True" } : new { Owner = "False" });
        }

        [HttpPost]
        public void changeOwnership([FromBody] JObject jsonbody)
        {

        }
    }
}
