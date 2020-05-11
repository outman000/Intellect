using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bus_Payment_OrderId",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bus_Payment_Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<string>(nullable: true),
                    PlaceAnOrderDate = table.Column<DateTime>(nullable: true),
                    confirmDate = table.Column<DateTime>(nullable: true),
                    confirmStatus = table.Column<string>(nullable: true),
                    paymentStatus = table.Column<string>(nullable: true),
                    Expense = table.Column<decimal>(nullable: true),
                    isDelete = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    departName = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    updateUser = table.Column<string>(nullable: true),
                    Repair_InfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus_Payment_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bus_Payment_Order_repair_Info_Repair_InfoId",
                        column: x => x.Repair_InfoId,
                        principalTable: "repair_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_Bus_Payment_OrderId",
                table: "bus_Payment",
                column: "Bus_Payment_OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_Order_Repair_InfoId",
                table: "bus_Payment_Order",
                column: "Repair_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_bus_Payment_Order_Bus_Payment_OrderId",
                table: "bus_Payment",
                column: "Bus_Payment_OrderId",
                principalTable: "bus_Payment_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_bus_Payment_Order_Bus_Payment_OrderId",
                table: "bus_Payment");

            migrationBuilder.DropTable(
                name: "bus_Payment_Order");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_Bus_Payment_OrderId",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "Bus_Payment_OrderId",
                table: "bus_Payment");
        }
    }
}
