using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Broker.DbModels
{
    public class BrokerContext : DbContext
    {
        public BrokerContext() { }

        public BrokerContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.Configuration.GetConnectionString("BrokerConnectionString"));
            }
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BuyRecord> BuyRecords { get; set; }
        public DbSet<SellRecord> SellRecords { get; set; }
    }
}
