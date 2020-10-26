using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class unitdaxie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Commodityunit",
                table: "Integral_Commodity",
                newName: "CommodityUnit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommodityUnit",
                table: "Integral_Commodity",
                newName: "Commodityunit");
        }
    }
}
