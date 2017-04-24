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
            return true;
        }
    }
}
