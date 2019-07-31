using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class opinio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opinion_Infos_flow_Node_Flow_NodeId",
                table: "opinion_Infos");

            migrationBuilder.RenameColumn(
                name: "Flow_NodeId",
                table: "opinion_Infos",
                newName: "Flow_NodeDefineId");

            migrationBuilder.RenameIndex(
                name: "IX_opinion_Infos_Flow_NodeId",
                table: "opinion_Infos",
                newName: "IX_opinion_Infos_Flow_NodeDefineId");

            migrationBuilder.AddForeignKey(
                name: "FK_opinion_Infos_flow_NodeDefine_Flow_NodeDefineId",
                table: "opinion_Infos",
                column: "Flow_NodeDefineId",
                principalTable: "flow_NodeDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opinion_Infos_flow_NodeDefine_Flow_NodeDefineId",
                table: "opinion_Infos");

            migrationBuilder.RenameColumn(
                name: "Flow_NodeDefineId",
                table: "opinion_Infos",
                newName: "Flow_NodeId");

            migrationBuilder.RenameIndex(
                name: "IX_opinion_Infos_Flow_NodeDefineId",
                table: "opinion_Infos",
                newName: "IX_opinion_Infos_Flow_NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_opinion_Infos_flow_Node_Flow_NodeId",
                table: "opinion_Infos",
                column: "Flow_NodeId",
                principalTable: "flow_Node",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
