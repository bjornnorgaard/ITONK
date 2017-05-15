using Microsoft.EntityFrameworkCore.Migrations;

namespace Broker.Migrations
{
    public partial class AddedStateToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "SellRecords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "BuyRecords",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "SellRecords");

            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "BuyRecords");
        }
    }
}
