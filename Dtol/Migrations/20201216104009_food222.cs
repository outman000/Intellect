using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class food222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WeekNumber",
                table: "food_Infos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "createUser",
                table: "food_Infos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "isDelete",
                table: "food_Infos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "food_Infos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updateUser",
                table: "food_Infos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "food_Infos");

            migrationBuilder.DropColumn(
                name: "createUser",
                table: "food_Infos");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "food_Infos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "food_Infos");

            migrationBuilder.DropColumn(
                name: "updateUser",
                table: "food_Infos");
        }
    }
}
