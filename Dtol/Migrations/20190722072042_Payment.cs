using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class Payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bus_Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bus_StationId = table.Column<int>(nullable: true),
                    Bus_LineId = table.Column<int>(nullable: true),
                    User_InfoId = table.Column<int>(nullable: true),
                    User_DepartId = table.Column<int>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bus_Payment_bus_Line_Bus_LineId",
                        column: x => x.Bus_LineId,
                        principalTable: "bus_Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bus_Payment_bus_Station_Bus_StationId",
                        column: x => x.Bus_StationId,
                        principalTable: "bus_Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bus_Payment_user_Depart_User_DepartId",
                        column: x => x.User_DepartId,
                        principalTable: "user_Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bus_Payment_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bus_Payment");
        }
    }
}
