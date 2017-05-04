using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Provider.Controllers
{
    [Route("[controller]/[action]")]
    public class ProviderController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly IBrokerService _brokerService;

        public ProviderController(IRegistryService registryService, IBrokerService brokerService)
        {
            _registryService = registryService;
            _brokerService = brokerService;
        }

        // POST [controller]/[action]
        [HttpPost]
        public async Task<IActionResult> Sell([FromBody]Order order)
        {
            if (await _registryService.IsValidOwnershipAsync(order) == false)
            {
                Response.StatusCode = 204;
                return Json(new { status = "You don't have shit. I call your bluff!" });
            }
            if (await _brokerService.CreateSellOrderAsync(order))
            {
                Response.StatusCode = 201;
                return Json(new { status = "Shit got done!" });
            }
            Response.StatusCode = 500;
            return Json(new { status = "Tried, but Mr. Broker said no." });
        }
    }
}
