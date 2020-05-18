using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class ziduansfz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDNumber",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateCodeDate",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "bus_Payment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "IDNumber",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "UpdateCodeDate",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "bus_Payment");
        }
    }
}
