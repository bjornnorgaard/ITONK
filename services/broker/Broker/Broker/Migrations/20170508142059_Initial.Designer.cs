using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Broker.Models;

namespace Broker.Migrations
{
    [DbContext(typeof(BrokerContext))]
    [Migration("20170508142059_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Broker.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuyOrderId");

                    b.Property<int>("SellOrderId");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Models.BuyOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuyerId");

                    b.Property<int>("MaxPrice");

                    b.Property<int>("Quantity");

                    b.Property<string>("TickerSymbol");

                    b.HasKey("Id");

                    b.ToTable("BuyOrders");
                });

            modelBuilder.Entity("Models.SellOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("SellerId");

                    b.Property<string>("TickerSymbol");

                    b.HasKey("Id");

                    b.ToTable("SellOrders");
                });
        }
    }
}
