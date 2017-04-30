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
using TaxTobin.Models;

namespace TaxTobin.NancyModules
{
    public class TaxTobinModule : NancyModule
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TaxTobinModule() : base(string.Empty)
        {
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

                    log.Info("Received following request:");

                    log.Info("ID: " + saleInfo.sellerId);
                    log.Info("TotalPrice_: " + saleInfo.totalPrice);

                    return HttpStatusCode.OK;
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
