using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class userbind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBind",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    OpenId = table.Column<string>(nullable: true),
                    Moblie = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    passWord = table.Column<string>(nullable: true),
                    bak1 = table.Column<string>(nullable: true),
                    bak2 = table.Column<string>(nullable: true),
                    bak3 = table.Column<string>(nullable: true),
                    bak4 = table.Column<string>(nullable: true),
                    bak5 = table.Column<string>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    isDelete = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBind", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBind");
        }
    }
}
