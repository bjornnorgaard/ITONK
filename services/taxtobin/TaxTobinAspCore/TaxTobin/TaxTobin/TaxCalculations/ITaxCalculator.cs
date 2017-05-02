using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD:services/taxtobin/TaxTobinAspCore/TaxTobin/TaxTobin/TaxCalculations/ITaxCalculator.cs
using System.Threading.Tasks;
=======
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
>>>>>>> refs/remotes/origin/master:services/taxtobin/TaxTobin/TaxTobin/TaxCalculations/TaxCalculator.cs
using TaxTobin.Models;

namespace TaxTobin.TaxCalculations
{
<<<<<<< HEAD:services/taxtobin/TaxTobinAspCore/TaxTobin/TaxTobin/TaxCalculations/ITaxCalculator.cs
    public interface ITaxCalculator
    {
        double NewTaxValue(SaleInfo saleInfo);
=======
    public class TaxCalculator
    {
        private double percentage = 0.02;

        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public double CalculateTax(SaleInfo sales)
        {
            log.Info("Calculating tax for seller with id " + sales.sellerId);

            log.Info("Total price of stock was " + sales.totalPrice);
            log.Info("Calculating tax using the current tax percentage " + percentage);

            double priceWithTax = (sales.totalPrice * percentage) + sales.totalPrice;

            log.Info("Price with added tax is " + priceWithTax);

            return priceWithTax;
        }
>>>>>>> refs/remotes/origin/master:services/taxtobin/TaxTobin/TaxTobin/TaxCalculations/TaxCalculator.cs
    }
}
