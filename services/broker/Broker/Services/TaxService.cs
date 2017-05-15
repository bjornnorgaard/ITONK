using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;

namespace Services
{
    public class TaxService : ITaxService
    {
        public static HttpClient Client { get; set; }

        public TaxService(string taxApiAddress)
        {
            if (string.IsNullOrWhiteSpace(taxApiAddress))
            {
                throw new ArgumentException($"The argument {nameof(taxApiAddress)} was null or whitespace. " +
                                            $"Please fill in the relevant sections in 'appsettings.json'. " +
                                            $"The key should be called something like {nameof(taxApiAddress)}.");
            }

            Client = new HttpClient { BaseAddress = new Uri(taxApiAddress) };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<bool> InformTaxGuy(int d)
        {
            throw new System.NotImplementedException();
        }
    }
}
