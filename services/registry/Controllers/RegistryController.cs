﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Registry.Controllers
{
    [Route("[controller]/[action]")]
    public class RegistryController : Controller
    {
        [HttpGet]
        public string checkOwnership(string tickerSymbol, int sellerId, int quantity)
        {
            

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void changeOwnership([FromBody] JObject jsonbody)
        {
        }
    }
}