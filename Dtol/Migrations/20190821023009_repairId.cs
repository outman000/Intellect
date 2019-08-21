using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class repairId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opinion_Infos_suggest_Boxes_Suggest_BoxId",
                table: "opinion_Infos");

            migrationBuilder.RenameColumn(
                name: "Suggest_BoxId",
                table: "opinion_Infos",
                newName: "Repair_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_opinion_Infos_Suggest_BoxId",
                table: "opinion_Infos",
                newName: "IX_opinion_Infos_Repair_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_opinion_Infos_repair_Info_Repair_InfoId",
                table: "opinion_Infos",
                column: "Repair_InfoId",
                principalTable: "repair_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_opinion_Infos_repair_Info_Repair_InfoId",
                table: "opinion_Infos");

            migrationBuilder.RenameColumn(
                name: "Repair_InfoId",
                table: "opinion_Infos",
                newName: "Suggest_BoxId");

            migrationBuilder.RenameIndex(
                name: "IX_opinion_Infos_Repair_InfoId",
                table: "opinion_Infos",
                newName: "IX_opinion_Infos_Suggest_BoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_opinion_Infos_suggest_Boxes_Suggest_BoxId",
                table: "opinion_Infos",
                column: "Suggest_BoxId",
                principalTable: "suggest_Boxes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
