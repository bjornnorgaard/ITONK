using System;
using System.Threading.Tasks;
using Broker.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace Broker.Controllers
{
    [Route("[controller]/[action]")]
    public class BrokerController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly ITaxService _taxService;
        private readonly BrokerContext _brokerContext;

        public BrokerController(IRegistryService registryService, ITaxService taxService, BrokerContext brokerContext )
        {
            _registryService = registryService;
            _taxService = taxService;
            _brokerContext = brokerContext;
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
