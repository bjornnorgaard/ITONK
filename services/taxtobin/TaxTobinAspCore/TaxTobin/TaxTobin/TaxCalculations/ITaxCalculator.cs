using TaxTobin.Models;

namespace TaxTobin.TaxCalculations
{
    public interface ITaxCalculator
    {
        double NewTaxValue(SaleInfo saleInfo);
    }
}
