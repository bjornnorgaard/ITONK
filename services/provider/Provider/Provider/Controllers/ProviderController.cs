using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Provider.Controllers
{
    [Route("sell")]
    public class ProviderController : Controller
    {
        private readonly IRegistryService _registryService;
        private readonly IBrokerService _brokerService;

        public ProviderController(IRegistryService registryService, IBrokerService brokerService)
        {
            _registryService = registryService;
            _brokerService = brokerService;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "We're not home!";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Go away!";
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody]Order order)
        {
            if (await _registryService.IsValidOwnershipAsync(order))
            {
                if (await _brokerService.CreateSellOrderAsync(order))
                {
                    return "Shit got done!";
                }
                return "Tried, but Mr. Broker said no.";
            }
            return "I call your bluff!";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]string value)
        {
            return "I'm not buying anything!";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "No, precious is mine!";
        }
    }
}
