using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IRegistryService
    {
        Task<bool> ChangeOwnership(OwnershipModel ownershipModel);
        Task<bool> IsValidOwnershipAsync(SellOrder order);
    }
}
