using TaxTobin.Models;

namespace TaxTobin.ExternalTaxComms
{
    public interface IExternalTaxComms
    {
        void SendToExternalTaxSystems(SaleInfo saleInfo, double taxedPrice);
    }
}
