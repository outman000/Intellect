using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class zhjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "bus_Payment_Order",
                newName: "payType");

            migrationBuilder.RenameColumn(
                name: "Expense",
                table: "bus_Payment_Order",
                newName: "orderAmount");

            migrationBuilder.AddColumn<string>(
                name: "orderNo",
                table: "bus_Payment_Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orderNote",
                table: "bus_Payment_Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderNo",
                table: "bus_Payment_Order");

            migrationBuilder.DropColumn(
                name: "orderNote",
                table: "bus_Payment_Order");

            migrationBuilder.RenameColumn(
                name: "payType",
                table: "bus_Payment_Order",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "orderAmount",
                table: "bus_Payment_Order",
                newName: "Expense");
        }
    }
}
