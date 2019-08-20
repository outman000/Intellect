using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class nodetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NodeKeep",
                table: "flow_NodeDefine",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "bulletin_Boards",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeKeep",
                table: "flow_NodeDefine");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "bulletin_Boards",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
