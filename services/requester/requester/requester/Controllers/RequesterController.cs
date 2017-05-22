using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using requester.Models;
using requester.Services;

namespace requester.Controllers
{
    [Route("[action]")]
    public class RequesterController : Controller
    {
        [HttpPost]
        public async Task<string> Buy([FromBody] BuyOrder buyOrder)
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
    }
}
