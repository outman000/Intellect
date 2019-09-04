using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class satisandremin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reminder_Infos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_InfoId = table.Column<int>(nullable: true),
                    Repair_InfoId = table.Column<int>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminder_Infos", x => x.id);
                    table.ForeignKey(
                        name: "FK_reminder_Infos_repair_Info_Repair_InfoId",
                        column: x => x.Repair_InfoId,
                        principalTable: "repair_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reminder_Infos_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "satisfaction_Infos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_InfoId = table.Column<int>(nullable: true),
                    Repair_InfoId = table.Column<int>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satisfaction_Infos", x => x.id);
                    table.ForeignKey(
                        name: "FK_satisfaction_Infos_repair_Info_Repair_InfoId",
                        column: x => x.Repair_InfoId,
                        principalTable: "repair_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_satisfaction_Infos_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reminder_Infos_Repair_InfoId",
                table: "reminder_Infos",
                column: "Repair_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_Infos_User_InfoId",
                table: "reminder_Infos",
                column: "User_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_satisfaction_Infos_Repair_InfoId",
                table: "satisfaction_Infos",
                column: "Repair_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_satisfaction_Infos_User_InfoId",
                table: "satisfaction_Infos",
                column: "User_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reminder_Infos");

            migrationBuilder.DropTable(
                name: "satisfaction_Infos");
        }
    }
}
