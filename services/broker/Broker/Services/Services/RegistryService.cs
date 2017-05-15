using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Newtonsoft.Json;

namespace Services.Services
{
    public class RegistryService : IRegistryService
    {
        public HttpClient Client { get; set; }

        public RegistryService(string registryApiAddress)
        {
            if (string.IsNullOrWhiteSpace(registryApiAddress))
            {
                throw new ArgumentException($"The argument {nameof(registryApiAddress)} was null or whitespace. " +
                                            $"Please fill in the relevant sections in 'appsettings.json'. " +
                                            $"The key should be called something like {nameof(registryApiAddress)}.");
            }

            Client = new HttpClient { BaseAddress = new Uri(registryApiAddress) };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> ChangeOwnership(OwnershipModel ownershipModel)
        {
            var httpOrder = new StringContent(JsonConvert.SerializeObject(ownershipModel));
            var httpResponse = await Client.PostAsync("/changeOwnership", httpOrder);
            return httpResponse.IsSuccessStatusCode;
        }

        public async Task<bool> IsValidOwnershipAsync(SellOrder order)
        {
            var request = await Client.GetAsync($"Registry/CheckOwnership?" +
                                                $"tickerSymbol={order.TickerSymbol}&" +
                                                $"sellerId={order.SellerId}&" +
                                                $"quantity={order.Quantity}");

            var content = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<RegistryResponseDto>(content);

            if (response.Owner.ToLower().Contains("t"))
            {
                return true;
            }

            return false;
        }
    }
}
