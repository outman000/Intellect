using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class gaipai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car_Reassignment_Record",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeforeCxry = table.Column<string>(nullable: true),
                    BeforeDriverName = table.Column<string>(nullable: true),
                    Beforephone = table.Column<string>(nullable: true),
                    AfterCxry = table.Column<string>(nullable: true),
                    AfterDriverName = table.Column<string>(nullable: true),
                    Afterphone = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    isdelete = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Reassignment_Record", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_Reassignment_Record");
        }
    }
}
