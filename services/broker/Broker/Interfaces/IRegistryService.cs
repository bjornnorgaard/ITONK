using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IRegistryService
    {
        Task<bool> ChangeOwnerShip(bool oij);
        Task<bool> IsValidOwnershipAsync(SellOrder order);
    }
}
