using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using requester.Models;

namespace requester.Controllers
{
    [Route("[Controller]")]
    public class BuyController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] BuyOrder buyOrder)
        {

        }
    }
}
