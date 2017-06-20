using System;
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
            Console.Out.WriteLine($"{nameof(ProviderController)}'s controller invoked");
            _registryService = registryService;
            _brokerService = brokerService;
        }

        [HttpPost]
        public async Task<IActionResult> Sell([FromBody] SellOrder sellOrder)
        {
            if (await _registryService.IsValidOwnershipAsync(sellOrder) == false)
            {
                var ownershipCouldNotBeVerified = "Ownership could not be verified.";
                Console.Out.WriteLine(ownershipCouldNotBeVerified);
                return Json(new {status = ownershipCouldNotBeVerified});
            }
            if (await _brokerService.CreateSellOrderAsync(sellOrder))
            {
                Response.StatusCode = 201;
                var sellorderSubmittedToBroker = "Sellorder submitted to broker!";
                Console.Out.WriteLine(sellorderSubmittedToBroker);
                return Json(new {status = sellorderSubmittedToBroker});
            }
            Response.StatusCode = 500;
            var brokerReturnedError = "Broker returned error";
            Console.Out.WriteLine(brokerReturnedError);
            return Json(new {status = brokerReturnedError});
        }
    }
}