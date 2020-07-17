using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class com : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "user_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComAttachs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    Physicsname = table.Column<string>(nullable: true),
                    Createdate = table.Column<DateTime>(nullable: true),
                    Updatedate = table.Column<DateTime>(nullable: true),
                    Employeename = table.Column<string>(nullable: true),
                    Employeeid = table.Column<string>(nullable: true),
                    Formid = table.Column<string>(nullable: true),
                    Formtablename = table.Column<string>(nullable: true),
                    Isdelete = table.Column<string>(nullable: true),
                    Filesize = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    Createmodifytime = table.Column<string>(nullable: true),
                    Lastmodifytime = table.Column<string>(nullable: true),
                    HrDeptId = table.Column<int>(nullable: true),
                    UploadUserId = table.Column<string>(nullable: true),
                    UploadUserId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComAttachs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComAttachs_user_Depart_HrDeptId",
                        column: x => x.HrDeptId,
                        principalTable: "user_Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComAttachs_user_Depart_UploadUserId1",
                        column: x => x.UploadUserId1,
                        principalTable: "user_Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComAttachs_HrDeptId",
                table: "ComAttachs",
                column: "HrDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_ComAttachs_UploadUserId1",
                table: "ComAttachs",
                column: "UploadUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComAttachs");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "user_Info");
        }
    }
}
