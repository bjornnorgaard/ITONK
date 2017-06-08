using Broker.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Broker.Migrations
{
    [DbContext(typeof(BrokerContext))]
    partial class BrokerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Broker.DbModels.BuyRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuyerId");

                    b.Property<bool>("IsBought");

                    b.Property<int>("MaxPrice");

                    b.Property<int>("Quantity");

                    b.Property<string>("TickerSymbol");

                    b.HasKey("Id");

                    b.ToTable("BuyRecords");
                });

            modelBuilder.Entity("Broker.DbModels.SellRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSold");

                    b.Property<int>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("SellerId");

                    b.Property<string>("TickerSymbol");

                    b.HasKey("Id");

                    b.ToTable("SellRecords");
                });

            modelBuilder.Entity("Broker.DbModels.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuyRecordId");

                    b.Property<int>("SellRecordId");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });
        }
    }
}
