using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Models;

namespace Services
{
    public class SellService
    {

        public SellService()
        {
            
        }


        public async Task<string> Sell(SellOrder order)
        {       
            throw new NotImplementedException();
        }


        private bool SaveBuyOrder(SellOrder order)
        {
            throw new NotImplementedException();
        }

        private bool MatchWithBuyOrders()
        {
            throw new NotImplementedException();
        }
    }
}
