using Microsoft.EntityFrameworkCore.Migrations;

namespace MRKT.Common.Persistence.Migrations
{
    public partial class RemveExtraJsonFiled : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Stock",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ProductDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TakeOutAddress",
                table: "OrderDetail",
                type: "json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Order",
                type: "json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Order",
                type: "json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "EventPosition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "CartDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Cart",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Brand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ProductDetail");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "TakeOutAddress",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "EventPosition");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CartDetail");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "TakeOutAddressJson",
                table: "OrderDetail",
                type: "json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressJson",
                table: "Order",
                type: "json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddressJson",
                table: "Order",
                type: "json",
                nullable: true);
        }
    }
}
