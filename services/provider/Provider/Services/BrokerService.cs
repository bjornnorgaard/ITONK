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

        public BrokerService(string brokerApiAddress)
        {
            if (string.IsNullOrWhiteSpace(brokerApiAddress))
            {
                throw new ArgumentException($"The argument {nameof(brokerApiAddress)} was null or whitespace. " +
                                            $"Please fill in the Relevant sections in 'appsettings.json'. " +
                                            $"The key should be called something like {nameof(brokerApiAddress)}.");
            }

            Client = new HttpClient { BaseAddress = new Uri(brokerApiAddress) };
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
