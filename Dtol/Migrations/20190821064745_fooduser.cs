using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class fooduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "user_Relate_Foods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "user_Relate_Foods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "user_Relate_Foods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "user_Relate_Foods");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "user_Relate_Foods");

            migrationBuilder.DropColumn(
                name: "status",
                table: "user_Relate_Foods");
        }
    }
}
