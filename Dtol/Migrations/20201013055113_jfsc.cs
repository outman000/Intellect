using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class jfsc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commodity_Attachs",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 50, nullable: false),
                    formid = table.Column<string>(nullable: true),
                    Catalog = table.Column<string>(nullable: true),
                    ImgIndex = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    InternalName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    creatorID = table.Column<string>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: true),
                    bak1 = table.Column<string>(nullable: true),
                    bak2 = table.Column<string>(nullable: true),
                    bak3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity_Attachs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Integral_Commodity",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CommodityName = table.Column<string>(maxLength: 50, nullable: true),
                    CommodityType = table.Column<string>(maxLength: 50, nullable: true),
                    IntegralNum = table.Column<string>(maxLength: 50, nullable: true),
                    CommodityIntroduction = table.Column<string>(maxLength: 50, nullable: true),
                    UnionName = table.Column<string>(maxLength: 50, nullable: true),
                    User_UnionId = table.Column<int>(maxLength: 50, nullable: true),
                    status = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<string>(maxLength: 50, nullable: true),
                    createUser = table.Column<string>(maxLength: 50, nullable: true),
                    updateUser = table.Column<string>(maxLength: 50, nullable: true),
                    AddDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    updateDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integral_Commodity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_List",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CommodityName = table.Column<string>(maxLength: 50, nullable: true),
                    CommodityType = table.Column<string>(maxLength: 50, nullable: true),
                    formid = table.Column<string>(maxLength: 50, nullable: true),
                    IntegralNum = table.Column<string>(maxLength: 50, nullable: true),
                    userid = table.Column<string>(maxLength: 50, nullable: true),
                    User_DepartId = table.Column<int>(maxLength: 50, nullable: true),
                    DeptName = table.Column<string>(maxLength: 50, nullable: true),
                    UnionName = table.Column<string>(maxLength: 50, nullable: true),
                    User_UnionId = table.Column<int>(maxLength: 50, nullable: true),
                    CommodityNum = table.Column<string>(maxLength: 50, nullable: true),
                    status = table.Column<string>(maxLength: 50, nullable: true),
                    Orderid = table.Column<string>(maxLength: 50, nullable: true),
                    createUser = table.Column<string>(maxLength: 50, nullable: true),
                    updateUser = table.Column<string>(maxLength: 50, nullable: true),
                    AddDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    updateDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_List", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commodity_Attachs");

            migrationBuilder.DropTable(
                name: "Integral_Commodity");

            migrationBuilder.DropTable(
                name: "Product_List");
        }
    }
}
