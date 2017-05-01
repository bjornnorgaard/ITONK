using log4net;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxTobin.DataLink;
using TaxTobin.Models;
using TaxTobin.TaxCalculations;

namespace TaxTobin.NancyModules
{
    public class TaxTobinModule : NancyModule
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private TaxCalculator taxCalculator;
        private ExternalTaxSystemComm taxSystemComm;

        public TaxTobinModule() : base(string.Empty)
        {
            taxCalculator = new TaxCalculator();
            taxSystemComm = new ExternalTaxSystemComm();

            Get["/Test"] = parameters =>
            {
                var feeds = new string[] { "foo", "bar" };
                log.Info("Feed was requested");
                return Response.AsJson(feeds);
            };

            Post["/tax"] = x =>
            {
                try
                {
                    var saleInfo = this.Bind<SaleInfo>();

                    //Setting seller id to the logging context. This helps identifying the statements
                    log4net.GlobalContext.Properties["sellerId"] = saleInfo.sellerId;

                    log.Info("Received following request:");

                    log.Info("ID: " + saleInfo.sellerId);
                    log.Info("TotalPrice_: " + saleInfo.totalPrice);

                    double taxedTotalPrice = taxCalculator.CalculateTax(saleInfo);

                    if(taxSystemComm.SendToTaxGovernments(saleInfo, taxedTotalPrice))
                    {
                        return HttpStatusCode.OK;
                    }
                    return HttpStatusCode.InternalServerError;
                }
                catch(Exception e)
                {
                    log.Error("Request failed with the error", e);

                    return HttpStatusCode.InternalServerError;
                }
            };
        }
    }
}
