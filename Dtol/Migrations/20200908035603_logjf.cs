using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class logjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Integral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Idcard = table.Column<string>(nullable: true),
                    Dept = table.Column<string>(nullable: true),
                    User_DepartId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    TotalPoints = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    IsDelete = table.Column<string>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    updateUser = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Integral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Integral_Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Idcard = table.Column<string>(nullable: true),
                    User_DepartId = table.Column<int>(nullable: true),
                    Dept = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Points = table.Column<string>(nullable: true),
                    PointsLocation = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    IsDelete = table.Column<string>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Integral_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Integral");

            migrationBuilder.DropTable(
                name: "User_Integral_Log");
        }
    }
}
