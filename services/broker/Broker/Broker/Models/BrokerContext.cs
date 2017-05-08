using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Broker.Models
{
    public class BrokerContext : DbContext
    {
        public BrokerContext()
        {

        }

        public BrokerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.Configuration.GetConnectionString("BrokerConnectionString"));
            }
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
    }
}
