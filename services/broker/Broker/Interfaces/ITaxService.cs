using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITaxService
    {
        Task<bool> InformTaxGuy(int d);
    }
}
