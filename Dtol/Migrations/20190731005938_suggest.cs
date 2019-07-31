using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class suggest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "suggest_Boxes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    SuggestType = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AnnexFile = table.Column<string>(nullable: true),
                    SuggestDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Anonymous = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    isHandler = table.Column<string>(nullable: true),
                    User_InfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suggest_Boxes", x => x.id);
                    table.ForeignKey(
                        name: "FK_suggest_Boxes_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opinion_Infos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_InfoId = table.Column<int>(nullable: true),
                    Suggest_BoxId = table.Column<int>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    Flow_NodeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opinion_Infos", x => x.id);
                    table.ForeignKey(
                        name: "FK_opinion_Infos_flow_Node_Flow_NodeId",
                        column: x => x.Flow_NodeId,
                        principalTable: "flow_Node",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_opinion_Infos_suggest_Boxes_Suggest_BoxId",
                        column: x => x.Suggest_BoxId,
                        principalTable: "suggest_Boxes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_opinion_Infos_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_opinion_Infos_Flow_NodeId",
                table: "opinion_Infos",
                column: "Flow_NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_opinion_Infos_Suggest_BoxId",
                table: "opinion_Infos",
                column: "Suggest_BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_opinion_Infos_User_InfoId",
                table: "opinion_Infos",
                column: "User_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_suggest_Boxes_User_InfoId",
                table: "suggest_Boxes",
                column: "User_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "opinion_Infos");

            migrationBuilder.DropTable(
                name: "suggest_Boxes");
        }
    }
}
