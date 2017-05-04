using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxTobin.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using TaxTobin.ExternalTaxComms;
using TaxTobin.TaxCalculations;

namespace TaxTobin.Controllers
{
    [Route("[controller]")]
    public class taxController : Controller
    {
        ILogger<taxController> logger;
        private ITaxCalculator taxCalculator;
        private IExternalTaxComms externalTaxComms;

        public taxController(ILogger<taxController> logger, ITaxCalculator taxCalculator, IExternalTaxComms externalTaxComms)
        {
            this.logger = logger;
            this.taxCalculator = taxCalculator;
            this.externalTaxComms = externalTaxComms;

            logger.LogInformation("taxController created");
        }

        // GET /tax
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInformation("Get test for taxController. Method was called succesfully");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST /tax
        [HttpPost]
        public void Post([FromBody]SaleInfo saleInfo)
        {
            logger.LogInformation("Received post message with the seller Id " + saleInfo.sellerId + " and the totalprice " + saleInfo.totalPrice);

            double taxedPrice = taxCalculator.NewTaxValue(saleInfo);

            externalTaxComms.SendToExternalTaxSystems(saleInfo, taxedPrice);

        }
    }
}
