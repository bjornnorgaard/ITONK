using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace requester.Controllers
{
    [Route("[Controller]")]
    public class ValuesController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody]int buyerId, string tickerSymbol, int maxPrice, int quantity)
        {

        }
    }
}
