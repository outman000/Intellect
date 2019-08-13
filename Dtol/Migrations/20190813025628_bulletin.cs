using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class bulletin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bulletin_Boards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BulletinTitle = table.Column<string>(nullable: true),
                    BulletinContent = table.Column<string>(nullable: true),
                    StayNum = table.Column<string>(nullable: true),
                    User_InfoId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    Repair_InfoId = table.Column<int>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bulletin_Boards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bulletin_Boards_repair_Info_Repair_InfoId",
                        column: x => x.Repair_InfoId,
                        principalTable: "repair_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bulletin_Boards_Repair_InfoId",
                table: "bulletin_Boards",
                column: "Repair_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bulletin_Boards");
        }
    }
}
