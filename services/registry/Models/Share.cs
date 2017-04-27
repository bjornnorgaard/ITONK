using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registry.Models
{
    public class Share
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; }
        public int Owner { get; set; }
    }
}
