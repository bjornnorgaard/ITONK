using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRegistryService
    {
        Task<bool> ChangeOwnerShip(bool oij);
    }
}
