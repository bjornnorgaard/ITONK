using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Services
{
    public class MockBrokerService : IBrokerService
    {
        public MockBrokerService(string value)
        {

        }

        public Task<bool> CreateSellOrderAsync(Order order)
        {
            return Task.FromResult(true);
        }
    }
}
