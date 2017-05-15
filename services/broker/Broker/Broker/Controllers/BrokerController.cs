using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Broker.Controllers
{
    [Route("[controller]/[action]")]
    public class BrokerController : Controller
    {
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
