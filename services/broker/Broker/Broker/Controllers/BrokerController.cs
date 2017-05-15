using System;
using System.Threading.Tasks;
using Broker.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Broker.Controllers
{
    [Route("[controller]/[action]")]
    public class BrokerController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly ITaxService _taxService;
        private readonly BrokerContext _context;

        public BrokerController(IRegistryService registryService, ITaxService taxService, BrokerContext context)
        {
            _registryService = registryService;
            _taxService = taxService;
            _context = context;
        }

        [HttpPost]
        public Task<IActionResult> Buy([FromBody]BuyOrder value)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Sell([FromBody]SellOrder value)
        {
            // Validate model
            if (await _registryService.IsValidOwnershipAsync(value) == false)
            {
                Response.StatusCode = 200;
                return Json(new { status = "Shit aint valid" });
            }

            // Save buyOrder to DB
            await _context.SellOrders.AddAsync(value);

            // Find match
            var isMatchFound = FindMatchAsync(value);

            if (await isMatchFound == false)
            {
                Response.StatusCode = 200;
                return Json(new {status = "No match found. Will be sold later."});
            }
            if (await isMatchFound)
            {
                // change ownership

                // inform tax

                Response.StatusCode = 200;
                return Json(new { status = "Match found. Was sold." });
            }

            Response.StatusCode = 200;
            return Json(new { status = "This should not have happened." });
        }

        private Task<bool> FindMatchAsync(SellOrder sellOrder)
        {
            throw new NotImplementedException();
        }
    }
}
