using Microsoft.Extensions.Logging;
using TaxTobin.Models;

namespace TaxTobin.TaxCalculations
{
    public class TaxCalculator : ITaxCalculator
    {
        private ILogger<TaxCalculator> logger;

        public TaxCalculator(ILogger<TaxCalculator> logger)
        {
            this.logger = logger;

            logger.LogInformation("Created TaxCalculator");
        }

        public double NewTaxValue(SaleInfo saleInfo)
        {
            logger.LogInformation("Calculating tax for " + saleInfo.sellerId);

            double newTaxValue = (saleInfo.totalPrice * 0.02) + saleInfo.totalPrice;

            logger.LogInformation("Taxed totalprice is " + newTaxValue);

            return newTaxValue;
        }
    }
}
