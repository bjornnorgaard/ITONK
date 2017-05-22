using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Registry.Models;

namespace Registry.Migrations
{
    [DbContext(typeof(ShareContext))]
    partial class ShareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Registry.Models.ShareModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Owner");

                    b.Property<string>("TickerSymbol");

                    b.HasKey("Id");

                    b.ToTable("Shares");
                });
        }
    }
}
