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
            Console.Out.WriteLine("BuyService recieved order:" + 
                buyOrder.BuyerId + "\n" + 
                buyOrder.MaxPrice + "\n" + 
                buyOrder.Quantity + "\n" + 
                buyOrder.TickerSymbol);

            HttpResponseMessage response;
            try
            {
                response = await BrokerService.SubmitBuyOrder(buyOrder);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.Out.WriteLine("BuyService: " + Resource.order_submitted_ok);
                return Resource.order_submitted_ok;
            }

            Console.Out.WriteLine("BuyService: " + Resource.order_submitted_error);
            return Resource.order_submitted_error;
        }
    }
}
