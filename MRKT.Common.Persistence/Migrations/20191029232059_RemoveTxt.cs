using Microsoft.EntityFrameworkCore.Migrations;

namespace MRKT.Common.Persistence.Migrations
{
    public partial class RemoveTxt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TakeOutAddressJson",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "BillingAddressJson",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddressJson",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TakeOutAddressJson",
                table: "OrderDetail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressJson",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddressJson",
                table: "Order",
                type: "text",
                nullable: true);
        }
    }
}
