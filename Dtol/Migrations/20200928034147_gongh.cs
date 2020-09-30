using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class gongh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnionName",
                table: "user_Info",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_UnionId",
                table: "user_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User_Union",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Union", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Register",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    UserPwd = table.Column<string>(nullable: true),
                    Dept = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Idcard = table.Column<string>(nullable: true),
                    PhoneCall = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    User_DepartId = table.Column<int>(nullable: true),
                    UnionName = table.Column<string>(nullable: true),
                    User_UnionId = table.Column<int>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    updateDate = table.Column<DateTime>(nullable: true),
                    createUser = table.Column<string>(nullable: true),
                    updateUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Register", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Register_user_Depart_User_DepartId",
                        column: x => x.User_DepartId,
                        principalTable: "user_Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Register_User_Union_User_UnionId",
                        column: x => x.User_UnionId,
                        principalTable: "User_Union",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_Info_User_UnionId",
                table: "user_Info",
                column: "User_UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Register_User_DepartId",
                table: "User_Register",
                column: "User_DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Register_User_UnionId",
                table: "User_Register",
                column: "User_UnionId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Info_User_Union_User_UnionId",
                table: "user_Info",
                column: "User_UnionId",
                principalTable: "User_Union",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Info_User_Union_User_UnionId",
                table: "user_Info");

            migrationBuilder.DropTable(
                name: "User_Register");

            migrationBuilder.DropTable(
                name: "User_Union");

            migrationBuilder.DropIndex(
                name: "IX_user_Info_User_UnionId",
                table: "user_Info");

            migrationBuilder.DropColumn(
                name: "UnionName",
                table: "user_Info");

            migrationBuilder.DropColumn(
                name: "User_UnionId",
                table: "user_Info");
        }
    }
}
