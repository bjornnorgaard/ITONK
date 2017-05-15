using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IRegistryService
    {
        Task<bool> ChangeOwnershipAsync(ChangeOwnershipObject changeOwnershipObject);
        Task<bool> IsValidOwnershipAsync(SellOrder order);
    }
}
