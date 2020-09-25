using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class typeqiye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "user_Depart",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Docdate",
                table: "Car_Reassignment_Record",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "user_Depart");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Docdate",
                table: "Car_Reassignment_Record",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
