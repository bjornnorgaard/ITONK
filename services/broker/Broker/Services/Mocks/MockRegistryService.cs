using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Services.Mocks
{
    public class MockRegistryService : IRegistryService
    {
        public MockRegistryService(string value) { }

        public Task<bool> ChangeOwnershipAsync(ChangeOwnershipObject changeOwnershipObject)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsValidOwnershipAsync(SellOrder order)
        {
            return Task.FromResult(true);
        }
    }
}
