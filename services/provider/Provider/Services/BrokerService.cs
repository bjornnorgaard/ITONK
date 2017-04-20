using Interfaces;
using Models;

namespace Services
{
    public class BrokerService : IBrokerService
    {
        public bool CreateSellOrder(Order order)
        {
            return true;
        }
    }
}
