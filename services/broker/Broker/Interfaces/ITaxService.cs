using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface ITaxService
    {
        Task<bool> InformTaxGuy(TaxNotifyObject taxNotifyObject);
    }
}
