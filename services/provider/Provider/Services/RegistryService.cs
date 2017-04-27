using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Services
{
    public class RegistryService : IRegistryService
    {
        public static HttpClient Client { get; set; }

        public RegistryService(string registryAddress)
        {
            if (string.IsNullOrWhiteSpace(registryAddress))
            {
                throw new ArgumentException($"The argument {nameof(registryAddress)} was null or whitespace. " +
                                            $"Please fill in the Relevant sections in 'appsettings.json'.");
            }

            Client = new HttpClient {BaseAddress = new Uri(registryAddress)};
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> IsValidOwnershipAsync(Order order)
        {
            var request = await Client.GetAsync($"/checkOwnership/" +
                                          $"tickerSymbol={order.TickerSymbol}&" +
                                          $"sellerId={order.SellerId}&" +
                                          $"quantity={order.Quantity}");
            return request.IsSuccessStatusCode;
        }
    }
}
