using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Newtonsoft.Json;

namespace Services
{
    public class BrokerService : IBrokerService
    {
        public static HttpClient Client { get; set; }

        public BrokerService(string brokerAddress)
        {
            if (string.IsNullOrWhiteSpace(brokerAddress))
            {
                throw new ArgumentException($"The argument {nameof(brokerAddress)} was null.");
            }

            Client = new HttpClient { BaseAddress = new Uri(brokerAddress) };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateSellOrderAsync(Order order)
        {
            var stringObject = JsonConvert.SerializeObject(order);
            var stringContent = new StringContent(stringObject);

            var response = await Client.PostAsync("/sell", stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
