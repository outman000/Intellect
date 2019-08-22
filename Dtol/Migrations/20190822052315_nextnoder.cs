using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class nextnoder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flow_NodeDefine_flow_NodeDefine_Flow_NextNodeDefineId",
                table: "flow_NodeDefine");

            migrationBuilder.DropIndex(
                name: "IX_flow_NodeDefine_Flow_NextNodeDefineId",
                table: "flow_NodeDefine");

            migrationBuilder.DropColumn(
                name: "Flow_NextNodeDefineId",
                table: "flow_NodeDefine");

            migrationBuilder.CreateTable(
                name: "flow_CurrentNodeAndNextNodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flow_NodeDefineId = table.Column<int>(nullable: true),
                    Flow_NextNodeDefineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flow_CurrentNodeAndNextNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flow_CurrentNodeAndNextNodes_flow_NodeDefine_Flow_NextNodeDefineId",
                        column: x => x.Flow_NextNodeDefineId,
                        principalTable: "flow_NodeDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flow_CurrentNodeAndNextNodes_flow_NodeDefine_Flow_NodeDefineId",
                        column: x => x.Flow_NodeDefineId,
                        principalTable: "flow_NodeDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flow_CurrentNodeAndNextNodes_Flow_NextNodeDefineId",
                table: "flow_CurrentNodeAndNextNodes",
                column: "Flow_NextNodeDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_CurrentNodeAndNextNodes_Flow_NodeDefineId",
                table: "flow_CurrentNodeAndNextNodes",
                column: "Flow_NodeDefineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flow_CurrentNodeAndNextNodes");

            migrationBuilder.AddColumn<int>(
                name: "Flow_NextNodeDefineId",
                table: "flow_NodeDefine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_flow_NodeDefine_Flow_NextNodeDefineId",
                table: "flow_NodeDefine",
                column: "Flow_NextNodeDefineId");

            migrationBuilder.AddForeignKey(
                name: "FK_flow_NodeDefine_flow_NodeDefine_Flow_NextNodeDefineId",
                table: "flow_NodeDefine",
                column: "Flow_NextNodeDefineId",
                principalTable: "flow_NodeDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
