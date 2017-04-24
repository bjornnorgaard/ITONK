using Models;

namespace Interfaces
{
    public interface IRegistryService
    {
        bool IsValidOwnership(Order order);
    }
}
