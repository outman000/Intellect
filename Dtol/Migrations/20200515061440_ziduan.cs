using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class ziduan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "curCode",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deviceInfo",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "identityName",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "identityNumb",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "identityType",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orderTime",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "spbillCreateIp",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "terminalChnl",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tradeType",
                table: "bus_Payment_Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "curCode",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "deviceInfo",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "identityName",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "identityNumb",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "identityType",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "orderTime",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "spbillCreateIp",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "terminalChnl",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "tradeType",
                table: "bus_Payment_Order");
        }
    }
}
