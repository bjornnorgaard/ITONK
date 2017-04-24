using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Interfaces;
using Models;

namespace Services
{
    public class RegistryService : IRegistryService
    {
        public static HttpClient Client { get; set; }

        public RegistryService(IRegistryAddressService addressService)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(addressService.GetRegistryApiAddress());
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public bool IsValidOwnership(Order order)
        {
            var request = Client.GetAsync($"/checkOwnership/" +
                                          $"tickerSymbol={order.TickerSymbol}&" +
                                          $"sellerId={order.SellerId}&" +
                                          $"quantity={order.Quantity}");
            request.Wait();
            var response = request.Result;

            return response.IsSuccessStatusCode;
        }
    }
}
