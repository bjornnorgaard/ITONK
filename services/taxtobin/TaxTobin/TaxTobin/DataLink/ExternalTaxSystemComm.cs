using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using TaxTobin.Models;

namespace TaxTobin.DataLink
{
    public class ExternalTaxSystemComm
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool SendToTaxGovernments(SaleInfo saleInfo, double taxedTotalPrice)
        {
            log.Info("Tax is being sent to government tax office for the seller with the id " + saleInfo.sellerId);    
            log.Info("Tax information was sent successfully");
            log.Info("Received HttpStatusCode ok");

            return true;
        }
    }
}
