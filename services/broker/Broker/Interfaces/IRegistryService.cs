using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IRegistryService
    {
        Task<bool> ChangeOwnership(ChangeOwnershipObject changeOwnershipObject);
        Task<bool> IsValidOwnershipAsync(SellOrder order);
    }
}
