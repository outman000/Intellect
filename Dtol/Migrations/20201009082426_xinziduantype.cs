using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class xinziduantype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "Suggest_Box_Type",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "Suggest_Box_Type",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateDate",
                table: "Suggest_Box_Type",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updateUser",
                table: "Suggest_Box_Type",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "Suggest_Box_Type");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "Suggest_Box_Type");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "Suggest_Box_Type");

            migrationBuilder.DropColumn(
                name: "updateUser",
                table: "Suggest_Box_Type");
        }
    }
}
