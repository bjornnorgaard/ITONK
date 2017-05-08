using Microsoft.AspNetCore.Mvc;

namespace Broker.Controllers
{
    [Route("[controller]/[action]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public void Buy([FromBody]string value)
        {
        }

        [HttpPost]
        public void Sell([FromBody]string value)
        {
        }
    }
}
