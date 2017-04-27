using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Registry.Models
{
    public class ShareContext : DbContext
    {
        public ShareContext()
        {
        }

        public ShareContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.Configuration.GetConnectionString("ShareDatabase"));
            }
        }

        public DbSet<Share> Shares { get; set; }
    }
}
