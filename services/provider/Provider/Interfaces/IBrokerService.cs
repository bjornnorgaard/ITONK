using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IBrokerService
    {
        Task<bool> CreateSellOrderAsync(Order order);
    }
}
