using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxTobin.Models;

namespace TaxTobin.ExternalTaxComms
{
    public interface IExternalTaxComms
    {
        void SendToExternalTaxSystems(SaleInfo saleInfo, double taxedPrice);
    }
}
