using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Repair_InfoId",
                table: "flow_Procedure",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Repair_InfoId",
                table: "flow_Node",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_flow_Procedure_Repair_InfoId",
                table: "flow_Procedure",
                column: "Repair_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_Node_Repair_InfoId",
                table: "flow_Node",
                column: "Repair_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_flow_Node_repair_Info_Repair_InfoId",
                table: "flow_Node",
                column: "Repair_InfoId",
                principalTable: "repair_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_flow_Procedure_repair_Info_Repair_InfoId",
                table: "flow_Procedure",
                column: "Repair_InfoId",
                principalTable: "repair_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flow_Node_repair_Info_Repair_InfoId",
                table: "flow_Node");

            migrationBuilder.DropForeignKey(
                name: "FK_flow_Procedure_repair_Info_Repair_InfoId",
                table: "flow_Procedure");

            migrationBuilder.DropIndex(
                name: "IX_flow_Procedure_Repair_InfoId",
                table: "flow_Procedure");

            migrationBuilder.DropIndex(
                name: "IX_flow_Node_Repair_InfoId",
                table: "flow_Node");

            migrationBuilder.DropColumn(
                name: "Repair_InfoId",
                table: "flow_Procedure");

            migrationBuilder.DropColumn(
                name: "Repair_InfoId",
                table: "flow_Node");
        }
    }
}
