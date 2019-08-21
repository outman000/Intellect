using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suggest_Boxes_user_Info_User_InfoId",
                table: "suggest_Boxes");

            migrationBuilder.AlterColumn<int>(
                name: "User_InfoId",
                table: "suggest_Boxes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_suggest_Boxes_user_Info_User_InfoId",
                table: "suggest_Boxes",
                column: "User_InfoId",
                principalTable: "user_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suggest_Boxes_user_Info_User_InfoId",
                table: "suggest_Boxes");

            migrationBuilder.AlterColumn<int>(
                name: "User_InfoId",
                table: "suggest_Boxes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_suggest_Boxes_user_Info_User_InfoId",
                table: "suggest_Boxes",
                column: "User_InfoId",
                principalTable: "user_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
