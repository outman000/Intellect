using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Depart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Depart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_Rights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RightsName = table.Column<string>(nullable: true),
                    RightsValue = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Rights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true),
                    RightsId = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    RightsName = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    RoleType = table.Column<string>(nullable: true),
                    RoleCode = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Createdate = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Level = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_Info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    UserPwd = table.Column<string>(nullable: true),
                    RoleNames = table.Column<string>(nullable: true),
                    RoleIds = table.Column<string>(nullable: true),
                    Dept = table.Column<string>(nullable: true),
                    DeptId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    AddInfoDate = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    Idcard = table.Column<string>(nullable: true),
                    NativePlace = table.Column<string>(nullable: true),
                    PoliticalBackground = table.Column<string>(nullable: true),
                    JoinPartyDate = table.Column<string>(nullable: true),
                    BloodType = table.Column<string>(nullable: true),
                    HomeAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneCall = table.Column<string>(nullable: true),
                    MobileCall = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Interest = table.Column<string>(nullable: true),
                    InitialEducation = table.Column<string>(nullable: true),
                    InitialGraduated = table.Column<string>(nullable: true),
                    InitialSpecialty = table.Column<string>(nullable: true),
                    FinalEducation = table.Column<string>(nullable: true),
                    FinalGraduated = table.Column<string>(nullable: true),
                    FinalSpecialty = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ForeignLanguageLevel = table.Column<string>(nullable: true),
                    ComputerLevel = table.Column<string>(nullable: true),
                    DriveLevel = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    EmployNature = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    ContractSignDate = table.Column<string>(nullable: true),
                    ContractMaturityDate = table.Column<string>(nullable: true),
                    WorkExperience = table.Column<string>(nullable: true),
                    TrainSituation = table.Column<string>(nullable: true),
                    FamilyMembers = table.Column<string>(nullable: true),
                    JobPerformance = table.Column<string>(nullable: true),
                    AwardAndPunish = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: true),
                    MasterId = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DeptLeaderId = table.Column<string>(nullable: true),
                    DeptLeaderName = table.Column<string>(nullable: true),
                    Levels = table.Column<string>(nullable: true),
                    Files = table.Column<string>(nullable: true),
                    ServiceExperience = table.Column<string>(nullable: true),
                    RoleNameNiwen = table.Column<string>(nullable: true),
                    RoleIdNiwen = table.Column<string>(nullable: true),
                    DzbId = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    User_DepartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_Info_User_Depart_User_DepartId",
                        column: x => x.User_DepartId,
                        principalTable: "User_Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Relate_Role_Right",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_Rights_ID = table.Column<int>(nullable: false),
                    User_RightsId = table.Column<int>(nullable: true),
                    User_Role_ID = table.Column<int>(nullable: false),
                    User_RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Relate_Role_Right", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Relate_Role_Right_user_Rights_User_RightsId",
                        column: x => x.User_RightsId,
                        principalTable: "user_Rights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Relate_Role_Right_user_Role_User_RoleId",
                        column: x => x.User_RoleId,
                        principalTable: "user_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Relate_Info_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_Info_ID = table.Column<int>(nullable: false),
                    User_InfoId = table.Column<int>(nullable: true),
                    User_Role_ID = table.Column<int>(nullable: false),
                    User_RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Relate_Info_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Relate_Info_Role_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Relate_Info_Role_user_Role_User_RoleId",
                        column: x => x.User_RoleId,
                        principalTable: "user_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_Info_User_DepartId",
                table: "user_Info",
                column: "User_DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Info_Role_User_InfoId",
                table: "User_Relate_Info_Role",
                column: "User_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Info_Role_User_RoleId",
                table: "User_Relate_Info_Role",
                column: "User_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Role_Right_User_RightsId",
                table: "User_Relate_Role_Right",
                column: "User_RightsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Relate_Role_Right_User_RoleId",
                table: "User_Relate_Role_Right",
                column: "User_RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Relate_Info_Role");

            migrationBuilder.DropTable(
                name: "User_Relate_Role_Right");

            migrationBuilder.DropTable(
                name: "user_Info");

            migrationBuilder.DropTable(
                name: "user_Rights");

            migrationBuilder.DropTable(
                name: "user_Role");

            migrationBuilder.DropTable(
                name: "User_Depart");
        }
    }
}
