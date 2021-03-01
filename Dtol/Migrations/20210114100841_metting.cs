using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dtol.Migrations
{
    public partial class metting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataBase_Type",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Parentid = table.Column<string>(maxLength: 50, nullable: true),
                    TypeName = table.Column<string>(maxLength: 50, nullable: true),
                    TypeCode = table.Column<string>(maxLength: 50, nullable: true),
                    Purview = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<string>(maxLength: 50, nullable: true),
                    Sort = table.Column<string>(maxLength: 50, nullable: true),
                    Property = table.Column<string>(maxLength: 500, nullable: true),
                    PropertyPhone = table.Column<string>(maxLength: 500, nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBase_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoom_Information",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    RoomNum = table.Column<string>(maxLength: 50, nullable: true),
                    RoomCapacity = table.Column<string>(maxLength: 50, nullable: true),
                    RoomDescription = table.Column<string>(maxLength: 500, nullable: true),
                    RoomEquipmentCode = table.Column<string>(maxLength: 50, nullable: true),
                    RoomEquipmentName = table.Column<string>(maxLength: 50, nullable: true),
                    Sort = table.Column<string>(maxLength: 50, nullable: true),
                    RoomStatus = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DataBase_TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoom_Information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingRoom_Information_DataBase_Type_DataBase_TypeId",
                        column: x => x.DataBase_TypeId,
                        principalTable: "DataBase_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoom_Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    DepartName = table.Column<string>(maxLength: 50, nullable: true),
                    Departid = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Idcard = table.Column<string>(maxLength: 50, nullable: true),
                    Meetingtime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Endingtime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    MeetingContent = table.Column<string>(maxLength: 500, nullable: true),
                    RoomStatus = table.Column<string>(maxLength: 50, nullable: true),
                    Floor = table.Column<string>(maxLength: 50, nullable: true),
                    Area = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<string>(maxLength: 50, nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    MeetingRoom_InformationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoom_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingRoom_Reservation_MeetingRoom_Information_MeetingRoom_InformationId",
                        column: x => x.MeetingRoom_InformationId,
                        principalTable: "MeetingRoom_Information",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoom_Information_DataBase_TypeId",
                table: "MeetingRoom_Information",
                column: "DataBase_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoom_Reservation_MeetingRoom_InformationId",
                table: "MeetingRoom_Reservation",
                column: "MeetingRoom_InformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingRoom_Reservation");

            migrationBuilder.DropTable(
                name: "MeetingRoom_Information");

            migrationBuilder.DropTable(
                name: "DataBase_Type");
        }
    }
}
