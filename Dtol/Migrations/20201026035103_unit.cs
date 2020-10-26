using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class unit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Commodityunit",
                table: "Product_List",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commodityunit",
                table: "Integral_Commodity",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commodityunit",
                table: "Product_List");

            migrationBuilder.DropColumn(
                name: "Commodityunit",
                table: "Integral_Commodity");
        }
    }
}
