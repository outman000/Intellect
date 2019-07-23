using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class Bus_Info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bus_InfoId",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateDate",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_Bus_InfoId",
                table: "bus_Payment",
                column: "Bus_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_bus_Info_Bus_InfoId",
                table: "bus_Payment",
                column: "Bus_InfoId",
                principalTable: "bus_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_bus_Info_Bus_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_Bus_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "Bus_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "status",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "bus_Payment");
        }
    }
}
