using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class gaipai2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Docdate",
                table: "Car_Reassignment_Record",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GetOffLocation",
                table: "Car_Reassignment_Record",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickUpLocation",
                table: "Car_Reassignment_Record",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Car_Reassignment_Record",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Docdate",
                table: "Car_Reassignment_Record");

            migrationBuilder.DropColumn(
                name: "GetOffLocation",
                table: "Car_Reassignment_Record");

            migrationBuilder.DropColumn(
                name: "PickUpLocation",
                table: "Car_Reassignment_Record");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Car_Reassignment_Record");
        }
    }
}
