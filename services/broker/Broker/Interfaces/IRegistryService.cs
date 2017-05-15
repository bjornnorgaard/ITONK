using System.Threading.Tasks;
using Broker.Models;

namespace Interfaces
{
    public interface IRegistryService
    {
        Task<bool> ChangeOwnerShip(OwnershipModel ownershipModel);
    }
}
