using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "food_Infos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    FoodType = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_Infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_Relate_Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_InfoId = table.Column<int>(nullable: false),
                    Food_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Relate_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_Relate_Foods_food_Infos_Food_InfoId",
                        column: x => x.Food_InfoId,
                        principalTable: "food_Infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_Relate_Foods_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_Relate_Foods_Food_InfoId",
                table: "user_Relate_Foods",
                column: "Food_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Relate_Foods_User_InfoId",
                table: "user_Relate_Foods",
                column: "User_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_Relate_Foods");

            migrationBuilder.DropTable(
                name: "food_Infos");
        }
    }
}
