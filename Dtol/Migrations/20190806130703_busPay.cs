using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class busPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_bus_Info_Bus_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_bus_Line_Bus_LineId",
                table: "bus_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_bus_Station_Bus_StationId",
                table: "bus_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_user_Depart_User_DepartId",
                table: "bus_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_user_Info_User_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_Bus_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_Bus_LineId",
                table: "bus_Payment");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_Bus_StationId",
                table: "bus_Payment");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_User_DepartId",
                table: "bus_Payment");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_User_InfoId",
                table: "bus_Payment");

            migrationBuilder.AddColumn<string>(
                name: "BusName",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expense",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineName",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Repair_InfoId",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StationName",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Userpicture",
                table: "bus_Payment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_Repair_InfoId",
                table: "bus_Payment",
                column: "Repair_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_repair_Info_Repair_InfoId",
                table: "bus_Payment",
                column: "Repair_InfoId",
                principalTable: "repair_Info",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bus_Payment_repair_Info_Repair_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropIndex(
                name: "IX_bus_Payment_Repair_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "BusName",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "Expense",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "LineName",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "Repair_InfoId",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "StationName",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "bus_Payment");

            migrationBuilder.DropColumn(
                name: "Userpicture",
                table: "bus_Payment");

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_Bus_InfoId",
                table: "bus_Payment",
                column: "Bus_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_Bus_LineId",
                table: "bus_Payment",
                column: "Bus_LineId");

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_Bus_StationId",
                table: "bus_Payment",
                column: "Bus_StationId");

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_User_DepartId",
                table: "bus_Payment",
                column: "User_DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_bus_Payment_User_InfoId",
                table: "bus_Payment",
                column: "User_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_bus_Info_Bus_InfoId",
                table: "bus_Payment",
                column: "Bus_InfoId",
                principalTable: "bus_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_bus_Line_Bus_LineId",
                table: "bus_Payment",
                column: "Bus_LineId",
                principalTable: "bus_Line",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_bus_Station_Bus_StationId",
                table: "bus_Payment",
                column: "Bus_StationId",
                principalTable: "bus_Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_user_Depart_User_DepartId",
                table: "bus_Payment",
                column: "User_DepartId",
                principalTable: "user_Depart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_bus_Payment_user_Info_User_InfoId",
                table: "bus_Payment",
                column: "User_InfoId",
                principalTable: "user_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
