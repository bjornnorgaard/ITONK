using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using TaxTobin.Models;

namespace TaxTobin.TaxCalculations
{
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
    }
}
