using Models;

namespace Interfaces
{
    public interface IBrokerService
    {
        bool CreateSellOrder(Order order);
    }
}
