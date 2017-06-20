using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaxTobin.Models;
using Microsoft.Extensions.Logging;
using TaxTobin.ExternalTaxComms;
using TaxTobin.TaxCalculations;

namespace TaxTobin.Controllers
{
    [Route("[controller]")]
    public class TaxController : Controller
    {
        ILogger<TaxController> _logger;
        private ITaxCalculator _taxCalculator;
        private IExternalTaxComms _externalTaxComms;

        public TaxController(ILogger<TaxController> logger, ITaxCalculator taxCalculator, IExternalTaxComms externalTaxComms)
        {
            this._logger = logger;
            this._taxCalculator = taxCalculator;
            this._externalTaxComms = externalTaxComms;

            Console.Out.WriteLine("taxController created");
        }

        // GET /tax
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.Out.WriteLine("Get test for taxController. Method was called succesfully");

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
            Console.Out.WriteLine("Received post message with the seller Id " + saleInfo.sellerId + " and the totalprice " + saleInfo.totalPrice);

            double taxedPrice = _taxCalculator.NewTaxValue(saleInfo);

            _externalTaxComms.SendToExternalTaxSystems(saleInfo, taxedPrice);
        }
    }
}
