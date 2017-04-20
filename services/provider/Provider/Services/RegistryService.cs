using Interfaces;
using Models;

namespace Services
{
    public class RegistryService : IRegistryService
    {
        public bool IsValidOwnership(Order order)
        {
            return true;
        }
    }
}
