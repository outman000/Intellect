using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class burelaterole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bulletin_Board_Relate_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bulletin_BoardId = table.Column<int>(nullable: false),
                    User_RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bulletin_Board_Relate_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bulletin_Board_Relate_Roles_bulletin_Boards_Bulletin_BoardId",
                        column: x => x.Bulletin_BoardId,
                        principalTable: "bulletin_Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bulletin_Board_Relate_Roles_user_Role_User_RoleId",
                        column: x => x.User_RoleId,
                        principalTable: "user_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bulletin_Board_Relate_Roles_Bulletin_BoardId",
                table: "bulletin_Board_Relate_Roles",
                column: "Bulletin_BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_bulletin_Board_Relate_Roles_User_RoleId",
                table: "bulletin_Board_Relate_Roles",
                column: "User_RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bulletin_Board_Relate_Roles");
        }
    }
}
