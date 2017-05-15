using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;

namespace Services
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

        public Task<bool> ChangeOwnerShip(bool oij)
        {
            throw new System.NotImplementedException();
        }
    }
}
