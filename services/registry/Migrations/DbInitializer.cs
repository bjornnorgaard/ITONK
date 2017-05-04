using System.Linq;
using Registry.Models;

namespace Registry.Migrations
{
    public static class DbInitializer
    {
        public static void Initialize(ShareContext context)
        {
            context.Database.EnsureCreated();

            if (context.Shares.Any())
            {
                return; // Database already seeded
            }

            var shares = new[]
            {
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "BAWS", Owner = 1},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
                new ShareModel{TickerSymbol = "OCCD", Owner = 2},
            };

            foreach (var share in shares)
            {
                context.Shares.Add(share);
            }

            context.SaveChanges();
        }
    }
}
