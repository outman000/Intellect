using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class Bus1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bus_Line",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LineName = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus_Line", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bus_Info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DriverName = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CarPlate = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    SeatNum = table.Column<string>(nullable: true),
                    OwnedCompany = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    Bus_LineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus_Info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bus_Info_bus_Line_Bus_LineId",
                        column: x => x.Bus_LineId,
                        principalTable: "bus_Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bus_Station",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StationName = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    OnWorkDate = table.Column<DateTime>(nullable: true),
                    OffWorkDate = table.Column<DateTime>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    Bus_LineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bus_Station_bus_Line_Bus_LineId",
                        column: x => x.Bus_LineId,
                        principalTable: "bus_Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bus_Info_Bus_LineId",
                table: "bus_Info",
                column: "Bus_LineId");

            migrationBuilder.CreateIndex(
                name: "IX_bus_Station_Bus_LineId",
                table: "bus_Station",
                column: "Bus_LineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bus_Info");

            migrationBuilder.DropTable(
                name: "bus_Station");

            migrationBuilder.DropTable(
                name: "bus_Line");
        }
    }
}
