using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class foodsuggest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suggest_Food",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SuggestType = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Anonymous = table.Column<string>(nullable: true),
                    isDelete = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    updateUser = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    User_InfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggest_Food", x => x.id);
                    table.ForeignKey(
                        name: "FK_Suggest_Food_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suggest_Food_User_InfoId",
                table: "Suggest_Food",
                column: "User_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suggest_Food");
        }
    }
}
