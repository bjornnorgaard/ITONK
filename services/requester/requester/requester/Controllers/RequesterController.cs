using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using requester.Models;
using requester.Services;

namespace requester.Controllers
{
    [Route("[Controller]")]
    public class RequesterController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody] BuyOrder buyOrder)
        {
            HttpResponseMessage response;
            try
            {
                response = await BrokerService.SubmitBuyOrder(buyOrder);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return response.IsSuccessStatusCode ? Resource.order_submitted_ok : Resource.order_submitted_error;
        }

        [HttpGet]
        public string Get(int id)
        {
            return Resource.operation_not_permitted;
        }

        [HttpPut]
        public string Put(int id,[FromBody] string data)
        {
            return Resource.operation_not_permitted;
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return Resource.operation_not_permitted;
        }
    }
}
