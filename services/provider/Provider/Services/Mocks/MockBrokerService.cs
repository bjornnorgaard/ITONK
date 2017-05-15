using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Services.Mocks
{
    public class MockBrokerService : IBrokerService
    {
        public MockBrokerService(string value) { }

        public Task<bool> CreateSellOrderAsync(SellOrder sellOrder)
        {
            return Task.FromResult(true);
        }
    }
}
