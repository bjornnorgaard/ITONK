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
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "NVO", Owner = 1},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "GOOG", Owner = 2},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "VWS", Owner = 3},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "DANSKE", Owner = 4},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "MAERSK A", Owner = 5},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
                new ShareModel{TickerSymbol = "DENERG", Owner = 6},
            };

            foreach (var share in shares)
            {
                context.Shares.Add(share);
            }

            context.SaveChanges();
        }
    }
}
