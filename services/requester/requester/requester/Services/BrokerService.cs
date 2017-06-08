using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using requester.Models;

namespace requester.Services
{
    public static class BrokerService
    {
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = new Uri(Startup.Configuration["BrokerApiAddress"]),
        };

        public static async Task<HttpResponseMessage> SubmitBuyOrder(BuyOrder buyOrder)
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var srlzd = JsonConvert.SerializeObject(buyOrder);
            var httpOrder = new StringContent(srlzd, Encoding.UTF8, "application/json");
            var httpResponse = await HttpClient.PostAsync("/buy", httpOrder);
            return httpResponse;
        }
    }
}
