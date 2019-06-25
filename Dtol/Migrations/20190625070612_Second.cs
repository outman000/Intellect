using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Info_User_Depart_User_DepartId",
                table: "user_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Info_Role_user_Info_User_InfoId",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Info_Role_user_Role_User_RoleId",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Role_Right_user_Rights_User_RightsId",
                table: "User_Relate_Role_Right");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Relate_Role_Right_user_Role_User_RoleId",
                table: "User_Relate_Role_Right");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Relate_Role_Right",
                table: "User_Relate_Role_Right");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Relate_Info_Role",
                table: "User_Relate_Info_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Depart",
                table: "User_Depart");

            migrationBuilder.RenameTable(
                name: "User_Relate_Role_Right",
                newName: "user_Relate_Role_Right");

            migrationBuilder.RenameTable(
                name: "User_Relate_Info_Role",
                newName: "user_Relate_Info_Role");

            migrationBuilder.RenameTable(
                name: "User_Depart",
                newName: "user_Depart");

            migrationBuilder.RenameIndex(
                name: "IX_User_Relate_Role_Right_User_RoleId",
                table: "user_Relate_Role_Right",
                newName: "IX_user_Relate_Role_Right_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Relate_Role_Right_User_RightsId",
                table: "user_Relate_Role_Right",
                newName: "IX_user_Relate_Role_Right_User_RightsId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Relate_Info_Role_User_RoleId",
                table: "user_Relate_Info_Role",
                newName: "IX_user_Relate_Info_Role_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Relate_Info_Role_User_InfoId",
                table: "user_Relate_Info_Role",
                newName: "IX_user_Relate_Info_Role_User_InfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_Relate_Role_Right",
                table: "user_Relate_Role_Right",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_Relate_Info_Role",
                table: "user_Relate_Info_Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_Depart",
                table: "user_Depart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Info_user_Depart_User_DepartId",
                table: "user_Info",
                column: "User_DepartId",
                principalTable: "user_Depart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Info_user_Depart_User_DepartId",
                table: "user_Info");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Info_Role_user_Info_User_InfoId",
                table: "user_Relate_Info_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Info_Role_user_Role_User_RoleId",
                table: "user_Relate_Info_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Role_Right_user_Rights_User_RightsId",
                table: "user_Relate_Role_Right");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Relate_Role_Right_user_Role_User_RoleId",
                table: "user_Relate_Role_Right");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_Relate_Role_Right",
                table: "user_Relate_Role_Right");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_Relate_Info_Role",
                table: "user_Relate_Info_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_Depart",
                table: "user_Depart");

            migrationBuilder.RenameTable(
                name: "user_Relate_Role_Right",
                newName: "User_Relate_Role_Right");

            migrationBuilder.RenameTable(
                name: "user_Relate_Info_Role",
                newName: "User_Relate_Info_Role");

            migrationBuilder.RenameTable(
                name: "user_Depart",
                newName: "User_Depart");

            migrationBuilder.RenameIndex(
                name: "IX_user_Relate_Role_Right_User_RoleId",
                table: "User_Relate_Role_Right",
                newName: "IX_User_Relate_Role_Right_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Relate_Role_Right_User_RightsId",
                table: "User_Relate_Role_Right",
                newName: "IX_User_Relate_Role_Right_User_RightsId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Relate_Info_Role_User_RoleId",
                table: "User_Relate_Info_Role",
                newName: "IX_User_Relate_Info_Role_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Relate_Info_Role_User_InfoId",
                table: "User_Relate_Info_Role",
                newName: "IX_User_Relate_Info_Role_User_InfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Relate_Role_Right",
                table: "User_Relate_Role_Right",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Relate_Info_Role",
                table: "User_Relate_Info_Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Depart",
                table: "User_Depart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Info_User_Depart_User_DepartId",
                table: "user_Info",
                column: "User_DepartId",
                principalTable: "User_Depart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Info_Role_user_Info_User_InfoId",
                table: "User_Relate_Info_Role",
                column: "User_InfoId",
                principalTable: "user_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Info_Role_user_Role_User_RoleId",
                table: "User_Relate_Info_Role",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Role_Right_user_Rights_User_RightsId",
                table: "User_Relate_Role_Right",
                column: "User_RightsId",
                principalTable: "user_Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Relate_Role_Right_user_Role_User_RoleId",
                table: "User_Relate_Role_Right",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
