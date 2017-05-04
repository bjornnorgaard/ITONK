using System.Collections.Generic;
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
            List<ShareModel> sharesList = new List<ShareModel>();

            for (int i = 0; i < 20; i++)
            {
                sharesList.Add(new ShareModel { TickerSymbol = "NVO", Owner = 1 });
                sharesList.Add(new ShareModel { TickerSymbol = "GOOG", Owner = 2 });
                sharesList.Add(new ShareModel { TickerSymbol = "VWS", Owner = 3 });
                sharesList.Add(new ShareModel { TickerSymbol = "DANSKE", Owner = 4 });
                sharesList.Add(new ShareModel { TickerSymbol = "MAERSK A", Owner = 5 });
                sharesList.Add(new ShareModel { TickerSymbol = "DENERG", Owner = 6 });
            }

            context.Shares.AddRange(sharesList);
            context.SaveChanges();
        }
    }
}
