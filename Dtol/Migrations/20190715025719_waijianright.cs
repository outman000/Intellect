using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class waijianright : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Role_Right_user_Rights_User_RightsId",
                table: "user_Relate_Role_Right");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Role_Right_user_Role_User_RoleId",
                table: "user_Relate_Role_Right");

            migrationBuilder.DropColumn(
                name: "User_Rights_ID",
                table: "user_Relate_Role_Right");

            migrationBuilder.DropColumn(
                name: "User_Role_ID",
                table: "user_Relate_Role_Right");

            migrationBuilder.AlterColumn<int>(
                name: "User_RoleId",
                table: "user_Relate_Role_Right",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_RightsId",
                table: "user_Relate_Role_Right",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Role_Right_user_Rights_User_RightsId",
                table: "user_Relate_Role_Right",
                column: "User_RightsId",
                principalTable: "user_Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Role_Right_user_Role_User_RoleId",
                table: "user_Relate_Role_Right",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Role_Right_user_Rights_User_RightsId",
                table: "user_Relate_Role_Right");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Role_Right_user_Role_User_RoleId",
                table: "user_Relate_Role_Right");

            migrationBuilder.AlterColumn<int>(
                name: "User_RoleId",
                table: "user_Relate_Role_Right",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "User_RightsId",
                table: "user_Relate_Role_Right",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "User_Rights_ID",
                table: "user_Relate_Role_Right",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Role_ID",
                table: "user_Relate_Role_Right",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Role_Right_user_Rights_User_RightsId",
                table: "user_Relate_Role_Right",
                column: "User_RightsId",
                principalTable: "user_Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Relate_Role_Right_user_Role_User_RoleId",
                table: "user_Relate_Role_Right",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
