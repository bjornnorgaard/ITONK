using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxTobin.Models;

namespace TaxTobin.TaxCalculations
{
    public interface ITaxCalculator
    {
        double NewTaxValue(SaleInfo saleInfo);
    }
}
