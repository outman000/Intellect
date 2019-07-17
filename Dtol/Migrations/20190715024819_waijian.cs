using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class waijian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Info_Role_user_Info_User_InfoId",
                table: "user_Relate_Info_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Info_Role_user_Role_User_RoleId",
                table: "user_Relate_Info_Role");

            migrationBuilder.DropColumn(
                name: "User_Info_ID",
                table: "user_Relate_Info_Role");

            migrationBuilder.DropColumn(
                name: "User_Role_ID",
                table: "user_Relate_Info_Role");

            migrationBuilder.AlterColumn<int>(
                name: "User_RoleId",
                table: "user_Relate_Info_Role",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_InfoId",
                table: "user_Relate_Info_Role",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Info_Role_user_Info_User_InfoId",
                table: "user_Relate_Info_Role",
                column: "User_InfoId",
                principalTable: "user_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Info_Role_user_Role_User_RoleId",
                table: "user_Relate_Info_Role",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Info_Role_user_Info_User_InfoId",
                table: "user_Relate_Info_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Info_Role_user_Role_User_RoleId",
                table: "user_Relate_Info_Role");

            migrationBuilder.AlterColumn<int>(
                name: "User_RoleId",
                table: "user_Relate_Info_Role",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "User_InfoId",
                table: "user_Relate_Info_Role",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "User_Info_ID",
                table: "user_Relate_Info_Role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Role_ID",
                table: "user_Relate_Info_Role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Info_Role_user_Info_User_InfoId",
                table: "user_Relate_Info_Role",
                column: "User_InfoId",
                principalTable: "user_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Info_Role_user_Role_User_RoleId",
                table: "user_Relate_Info_Role",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
