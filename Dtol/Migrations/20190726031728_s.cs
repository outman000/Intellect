using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flow_Relate_NodeRole_flow_NodeDefine_Flow_NodeDefineId",
                table: "Flow_Relate_NodeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Flow_Relate_NodeRole_user_Role_User_RoleId",
                table: "Flow_Relate_NodeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flow_Relate_NodeRole",
                table: "Flow_Relate_NodeRole");

            migrationBuilder.RenameTable(
                name: "Flow_Relate_NodeRole",
                newName: "flow_Relate_NodeRole");

            migrationBuilder.RenameIndex(
                name: "IX_Flow_Relate_NodeRole_User_RoleId",
                table: "flow_Relate_NodeRole",
                newName: "IX_flow_Relate_NodeRole_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Flow_Relate_NodeRole_Flow_NodeDefineId",
                table: "flow_Relate_NodeRole",
                newName: "IX_flow_Relate_NodeRole_Flow_NodeDefineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_flow_Relate_NodeRole",
                table: "flow_Relate_NodeRole",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_flow_Relate_NodeRole_flow_NodeDefine_Flow_NodeDefineId",
                table: "flow_Relate_NodeRole",
                column: "Flow_NodeDefineId",
                principalTable: "flow_NodeDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flow_Relate_NodeRole_user_Role_User_RoleId",
                table: "flow_Relate_NodeRole",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flow_Relate_NodeRole_flow_NodeDefine_Flow_NodeDefineId",
                table: "flow_Relate_NodeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_flow_Relate_NodeRole_user_Role_User_RoleId",
                table: "flow_Relate_NodeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_flow_Relate_NodeRole",
                table: "flow_Relate_NodeRole");

            migrationBuilder.RenameTable(
                name: "flow_Relate_NodeRole",
                newName: "Flow_Relate_NodeRole");

            migrationBuilder.RenameIndex(
                name: "IX_flow_Relate_NodeRole_User_RoleId",
                table: "Flow_Relate_NodeRole",
                newName: "IX_Flow_Relate_NodeRole_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_flow_Relate_NodeRole_Flow_NodeDefineId",
                table: "Flow_Relate_NodeRole",
                newName: "IX_Flow_Relate_NodeRole_Flow_NodeDefineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flow_Relate_NodeRole",
                table: "Flow_Relate_NodeRole",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flow_Relate_NodeRole_flow_NodeDefine_Flow_NodeDefineId",
                table: "Flow_Relate_NodeRole",
                column: "Flow_NodeDefineId",
                principalTable: "flow_NodeDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flow_Relate_NodeRole_user_Role_User_RoleId",
                table: "Flow_Relate_NodeRole",
                column: "User_RoleId",
                principalTable: "user_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
