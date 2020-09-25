using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class smjiluxiug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusPaymentId",
                table: "Bus_Scan_Record",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StationName",
                table: "Bus_Scan_Record",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusPaymentId",
                table: "Bus_Scan_Record");

            migrationBuilder.DropColumn(
                name: "StationName",
                table: "Bus_Scan_Record");
        }
    }
}
