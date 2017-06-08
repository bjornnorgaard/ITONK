using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Provider.Controllers
{
    [Route("[action]")]
    public class ProviderController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly IBrokerService _brokerService;

        public ProviderController(IRegistryService registryService, IBrokerService brokerService)
        {
            _registryService = registryService;
            _brokerService = brokerService;
        }

        [HttpPost]
        public async Task<IActionResult> Sell([FromBody] SellOrder sellOrder)
        {
            if (await _registryService.IsValidOwnershipAsync(sellOrder) == false)
            {
                return Json(new {status = "You don't have shit. I call your bluff!"});
            }
            if (await _brokerService.CreateSellOrderAsync(sellOrder))
            {
                Response.StatusCode = 201;
                return Json(new {status = "Shit got done!"});
            }
            Response.StatusCode = 500;
            return Json(new {status = "Tried, but Mr. Broker said no."});
        }
    }
}