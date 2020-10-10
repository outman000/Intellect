using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuggestChildenType",
                table: "suggest_Boxes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suggest_Box_Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggest_Box_Type", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suggest_Box_Type");

            migrationBuilder.DropColumn(
                name: "SuggestChildenType",
                table: "suggest_Boxes");
        }
    }
}
