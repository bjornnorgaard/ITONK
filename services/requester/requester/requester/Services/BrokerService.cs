using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using requester.Models;

namespace requester.Services
{
    public class BrokerService
    {
        public BrokerService()
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(BrokerUrl)};
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<bool> SubmitBuyOrder(BuyOrder buyOrder)
        {
            var srlzd = JsonConvert.SerializeObject(buyOrder);
            var httpOrder = new StringContent(srlzd);

            var httpResponse = await _httpClient.PostAsync("/buy", httpOrder);
            return httpResponse.IsSuccessStatusCode;
        }


        private const string BrokerUrl = "";
        private readonly HttpClient _httpClient;
    }
}
