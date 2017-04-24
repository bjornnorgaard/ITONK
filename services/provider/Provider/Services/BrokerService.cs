using System;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public bool CreateSellOrder(Order order)
        {
            var stringObject = JsonConvert.SerializeObject(order);
            StringContent stringContent = new StringContent(stringObject);

            var request = Client.PostAsync("/sell", stringContent);
            request.Wait();
            var response = request.Result;

            return response.IsSuccessStatusCode;
        }
    }
}
