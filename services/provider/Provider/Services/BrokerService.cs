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

        public BrokerService(IBrokerAddressService addressService)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(addressService.GetBrokerApiAddress());
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateSellOrderAsync(Order order)
        {
            var stringObject = JsonConvert.SerializeObject(order);
            StringContent stringContent = new StringContent(stringObject);

            var response = await Client.PostAsync("/sell", stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
