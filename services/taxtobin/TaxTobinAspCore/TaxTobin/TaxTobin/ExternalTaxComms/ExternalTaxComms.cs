using Microsoft.Extensions.Logging;
using TaxTobin.Models;

namespace TaxTobin.ExternalTaxComms
{
    public class ExternalTaxComms : IExternalTaxComms
    {
        private ILogger<ExternalTaxComms> logger;

        public ExternalTaxComms(ILogger<ExternalTaxComms> logger)
        {
            this.logger = logger;
        }

        public void SendToExternalTaxSystems(SaleInfo saleInfo, double taxedPrice)
        {
            logger.LogInformation("Sending to external tax systems");
            logger.LogInformation("Received response: OK");
            logger.LogInformation("Tax was calculated and sent succesfully for " + saleInfo.sellerId);
        }
    }
}
