using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using requester.Models;

namespace requester.Services
{
    public static class BrokerService
    {
        private static HttpClient _httpClient;

        public static async Task<HttpResponseMessage> SubmitBuyOrder(BuyOrder buyOrder)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Resource.broker_url) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var srlzd = JsonConvert.SerializeObject(buyOrder);
            var httpOrder = new StringContent(srlzd);
            var httpResponse = await _httpClient.PostAsync("/buy", httpOrder);
            return httpResponse;
        }
    }
}
