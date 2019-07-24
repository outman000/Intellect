using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class flow1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Flow_NodeDefineId",
                table: "user_Role",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Flow_ProcedureId",
                table: "user_Role",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "flow_Procedure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(nullable: true),
                    Starttime = table.Column<DateTime>(nullable: true),
                    Endtime = table.Column<DateTime>(nullable: true),
                    remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flow_Procedure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "flow_ProcedureDefine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcedureName = table.Column<string>(nullable: true),
                    ProcedureCode = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: true),
                    Updatetime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flow_ProcedureDefine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "repair_Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_InfoId = table.Column<int>(nullable: false),
                    User_DepartId = table.Column<int>(nullable: false),
                    RepairsTitle = table.Column<string>(nullable: true),
                    RepairsType = table.Column<string>(nullable: true),
                    RepairsEmergency = table.Column<string>(nullable: true),
                    RepairsContent = table.Column<string>(nullable: true),
                    repairsDate = table.Column<DateTime>(nullable: true),
                    RepairsAdress = table.Column<string>(nullable: true),
                    telephone = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    isHandler = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_repair_Info_user_Depart_User_DepartId",
                        column: x => x.User_DepartId,
                        principalTable: "user_Depart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_repair_Info_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flow_NodeDefine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NodeName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Flow_NextNodeDefineId = table.Column<int>(nullable: true),
                    Flow_ProcedureDefineId = table.Column<int>(nullable: true),
                    NodeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flow_NodeDefine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flow_NodeDefine_flow_NodeDefine_Flow_NextNodeDefineId",
                        column: x => x.Flow_NextNodeDefineId,
                        principalTable: "flow_NodeDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flow_NodeDefine_flow_ProcedureDefine_Flow_ProcedureDefineId",
                        column: x => x.Flow_ProcedureDefineId,
                        principalTable: "flow_ProcedureDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "flow_Node",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flow_NodeDefineId = table.Column<int>(nullable: true),
                    Parent_Flow_NodeDefineId = table.Column<int>(nullable: true),
                    Flow_ProcedureId = table.Column<int>(nullable: true),
                    Parent_Flow_ProcedureId = table.Column<int>(nullable: true),
                    operate = table.Column<string>(nullable: true),
                    User_InfoId = table.Column<int>(nullable: true),
                    Pre_User_InfoId = table.Column<int>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flow_Node", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flow_Node_flow_NodeDefine_Flow_NodeDefineId",
                        column: x => x.Flow_NodeDefineId,
                        principalTable: "flow_NodeDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flow_Node_flow_Procedure_Flow_ProcedureId",
                        column: x => x.Flow_ProcedureId,
                        principalTable: "flow_Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flow_Node_flow_NodeDefine_Parent_Flow_NodeDefineId",
                        column: x => x.Parent_Flow_NodeDefineId,
                        principalTable: "flow_NodeDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flow_Node_flow_Procedure_Parent_Flow_ProcedureId",
                        column: x => x.Parent_Flow_ProcedureId,
                        principalTable: "flow_Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flow_Node_user_Info_Pre_User_InfoId",
                        column: x => x.Pre_User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flow_Node_user_Info_User_InfoId",
                        column: x => x.User_InfoId,
                        principalTable: "user_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flow_Relate_NodeRole",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flow_NodeDefineId = table.Column<int>(nullable: false),
                    User_RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flow_Relate_NodeRole", x => x.id);
                    table.ForeignKey(
                        name: "FK_Flow_Relate_NodeRole_flow_NodeDefine_Flow_NodeDefineId",
                        column: x => x.Flow_NodeDefineId,
                        principalTable: "flow_NodeDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flow_Relate_NodeRole_user_Role_User_RoleId",
                        column: x => x.User_RoleId,
                        principalTable: "user_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_Role_Flow_NodeDefineId",
                table: "user_Role",
                column: "Flow_NodeDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Role_Flow_ProcedureId",
                table: "user_Role",
                column: "Flow_ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_Node_Flow_NodeDefineId",
                table: "flow_Node",
                column: "Flow_NodeDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_Node_Flow_ProcedureId",
                table: "flow_Node",
                column: "Flow_ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_Node_Parent_Flow_NodeDefineId",
                table: "flow_Node",
                column: "Parent_Flow_NodeDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_Node_Parent_Flow_ProcedureId",
                table: "flow_Node",
                column: "Parent_Flow_ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_Node_Pre_User_InfoId",
                table: "flow_Node",
                column: "Pre_User_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_Node_User_InfoId",
                table: "flow_Node",
                column: "User_InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_NodeDefine_Flow_NextNodeDefineId",
                table: "flow_NodeDefine",
                column: "Flow_NextNodeDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_flow_NodeDefine_Flow_ProcedureDefineId",
                table: "flow_NodeDefine",
                column: "Flow_ProcedureDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flow_Relate_NodeRole_Flow_NodeDefineId",
                table: "Flow_Relate_NodeRole",
                column: "Flow_NodeDefineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flow_Relate_NodeRole_User_RoleId",
                table: "Flow_Relate_NodeRole",
                column: "User_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_repair_Info_User_DepartId",
                table: "repair_Info",
                column: "User_DepartId");

            migrationBuilder.CreateIndex(
                name: "IX_repair_Info_User_InfoId",
                table: "repair_Info",
                column: "User_InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Role_flow_NodeDefine_Flow_NodeDefineId",
                table: "user_Role",
                column: "Flow_NodeDefineId",
                principalTable: "flow_NodeDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Role_flow_Procedure_Flow_ProcedureId",
                table: "user_Role",
                column: "Flow_ProcedureId",
                principalTable: "flow_Procedure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Role_flow_NodeDefine_Flow_NodeDefineId",
                table: "user_Role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Role_flow_Procedure_Flow_ProcedureId",
                table: "user_Role");

            migrationBuilder.DropTable(
                name: "flow_Node");

            migrationBuilder.DropTable(
                name: "Flow_Relate_NodeRole");

            migrationBuilder.DropTable(
                name: "repair_Info");

            migrationBuilder.DropTable(
                name: "flow_Procedure");

            migrationBuilder.DropTable(
                name: "flow_NodeDefine");

            migrationBuilder.DropTable(
                name: "flow_ProcedureDefine");

            migrationBuilder.DropIndex(
                name: "IX_user_Role_Flow_NodeDefineId",
                table: "user_Role");

            migrationBuilder.DropIndex(
                name: "IX_user_Role_Flow_ProcedureId",
                table: "user_Role");

            migrationBuilder.DropColumn(
                name: "Flow_NodeDefineId",
                table: "user_Role");

            migrationBuilder.DropColumn(
                name: "Flow_ProcedureId",
                table: "user_Role");
        }
    }
}
