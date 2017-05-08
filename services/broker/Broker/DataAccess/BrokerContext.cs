using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class BrokerContext : DbContext
    {
        public BrokerContext(DbContextOptions<BrokerContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
    }
}
