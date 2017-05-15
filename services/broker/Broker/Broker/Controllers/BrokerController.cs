using System;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Broker.Controllers
{
    [Route("[controller]/[action]")]
    public class BrokerController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly ITaxService _taxService;

        public BrokerController(IRegistryService registryService, ITaxService taxService )
        {
            _registryService = registryService;
            _taxService = taxService;
        }

        [HttpPost]
        public Task<IActionResult> Buy([FromBody]BuyOrder value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<string> Sell([FromBody]SellOrder value)
        {
            throw  new NotImplementedException();
        }
    }
}
