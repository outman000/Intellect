﻿// <auto-generated />
using System;
using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dtol.Migrations
{
    [DbContext(typeof(DtolContext))]
    [Migration("20200630072128_jiaofeijr")]
    partial class jiaofeijr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dtol.dtol.Bulletin_Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate");

                    b.Property<string>("BulletinContent");

                    b.Property<string>("BulletinTitle");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<string>("StayNum");

                    b.Property<string>("UserName");

                    b.Property<int>("User_InfoId");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.HasIndex("Repair_InfoId");

                    b.ToTable("bulletin_Boards");
                });

            modelBuilder.Entity("Dtol.dtol.Bulletin_Board_Relate_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bulletin_BoardId");

                    b.Property<int>("User_RoleId");

                    b.HasKey("Id");

                    b.HasIndex("Bulletin_BoardId");

                    b.HasIndex("User_RoleId");

                    b.ToTable("bulletin_Board_Relate_Roles");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<int?>("Bus_LineId");

                    b.Property<string>("CarPlate");

                    b.Property<string>("Code");

                    b.Property<string>("DriverName");

                    b.Property<string>("OwnedCompany");

                    b.Property<string>("SeatNum");

                    b.Property<string>("deviceNumber");

                    b.Property<string>("phone");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.HasIndex("Bus_LineId");

                    b.ToTable("bus_Info");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("Code");

                    b.Property<string>("LineName");

                    b.Property<string>("Remark");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.ToTable("bus_Line");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusName");

                    b.Property<int?>("Bus_InfoId");

                    b.Property<int?>("Bus_LineId");

                    b.Property<int?>("Bus_Payment_OrderId");

                    b.Property<int?>("Bus_StationId");

                    b.Property<string>("Code");

                    b.Property<string>("Expense");

                    b.Property<string>("IDNumber");

                    b.Property<string>("LineName");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<string>("StationName");

                    b.Property<DateTime?>("UpdateCodeDate");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.Property<int?>("User_DepartId");

                    b.Property<int?>("User_InfoId");

                    b.Property<string>("Userpicture");

                    b.Property<DateTime?>("carDate");

                    b.Property<DateTime?>("createDate");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.HasIndex("Bus_Payment_OrderId");

                    b.HasIndex("Repair_InfoId");

                    b.ToTable("bus_Payment");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Payment_Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<DateTime?>("PlaceAnOrderDate");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<string>("body");

                    b.Property<DateTime?>("confirmDate");

                    b.Property<string>("confirmStatus");

                    b.Property<string>("createUser");

                    b.Property<string>("curCode");

                    b.Property<string>("departName");

                    b.Property<string>("deviceInfo");

                    b.Property<string>("identityName");

                    b.Property<string>("identityNumb");

                    b.Property<string>("identityType");

                    b.Property<string>("isDelete");

                    b.Property<string>("orderAmount");

                    b.Property<string>("orderNo");

                    b.Property<string>("orderNote");

                    b.Property<string>("orderTime");

                    b.Property<string>("payType");

                    b.Property<string>("paymentStatus");

                    b.Property<string>("spbillCreateIp");

                    b.Property<string>("status");

                    b.Property<string>("terminalChnl");

                    b.Property<string>("tradeType");

                    b.Property<DateTime?>("updateDate");

                    b.Property<string>("updateUser");

                    b.HasKey("Id");

                    b.HasIndex("Repair_InfoId");

                    b.ToTable("bus_Payment_Order");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<int?>("Bus_LineId");

                    b.Property<string>("Code");

                    b.Property<decimal?>("Expense");

                    b.Property<DateTime?>("OffWorkDate");

                    b.Property<DateTime?>("OnWorkDate");

                    b.Property<string>("StationName");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.HasIndex("Bus_LineId");

                    b.ToTable("bus_Station");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_CurrentNodeAndNextNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Flow_NextNodeDefineId");

                    b.Property<int?>("Flow_NodeDefineId");

                    b.HasKey("Id");

                    b.HasIndex("Flow_NextNodeDefineId");

                    b.HasIndex("Flow_NodeDefineId");

                    b.ToTable("flow_CurrentNodeAndNextNodes");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime");

                    b.Property<int?>("Flow_NodeDefineId");

                    b.Property<int?>("Flow_ProcedureId");

                    b.Property<int?>("Parent_Flow_NodeDefineId");

                    b.Property<int?>("Parent_Flow_ProcedureId");

                    b.Property<int?>("Pre_User_InfoId");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<DateTime?>("StartTime");

                    b.Property<int?>("User_InfoId");

                    b.Property<string>("operate");

                    b.Property<string>("status");

                    b.HasKey("Id");

                    b.HasIndex("Flow_NodeDefineId");

                    b.HasIndex("Flow_ProcedureId");

                    b.HasIndex("Parent_Flow_NodeDefineId");

                    b.HasIndex("Parent_Flow_ProcedureId");

                    b.HasIndex("Pre_User_InfoId");

                    b.HasIndex("Repair_InfoId");

                    b.HasIndex("User_InfoId");

                    b.ToTable("flow_Node");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_NodeDefine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<int?>("Flow_ProcedureDefineId");

                    b.Property<string>("NodeKeep");

                    b.Property<string>("NodeName");

                    b.Property<string>("NodeType");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("status");

                    b.HasKey("Id");

                    b.HasIndex("Flow_ProcedureDefineId");

                    b.ToTable("flow_NodeDefine");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Endtime");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<DateTime?>("Starttime");

                    b.Property<string>("remark");

                    b.Property<string>("status");

                    b.HasKey("Id");

                    b.HasIndex("Repair_InfoId");

                    b.ToTable("flow_Procedure");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_ProcedureDefine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Createtime");

                    b.Property<string>("ProcedureCode");

                    b.Property<string>("ProcedureName");

                    b.Property<string>("Remark");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("Updatetime");

                    b.HasKey("Id");

                    b.ToTable("flow_ProcedureDefine");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_Relate_NodeRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Flow_NodeDefineId");

                    b.Property<int>("User_RoleId");

                    b.HasKey("id");

                    b.HasIndex("Flow_NodeDefineId");

                    b.HasIndex("User_RoleId");

                    b.ToTable("flow_Relate_NodeRole");
                });

            modelBuilder.Entity("Dtol.dtol.Food_Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("Code");

                    b.Property<string>("FoodName");

                    b.Property<string>("FoodType");

                    b.Property<string>("Picture");

                    b.Property<decimal?>("Price");

                    b.Property<string>("Remark");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.ToTable("food_Infos");
                });

            modelBuilder.Entity("Dtol.dtol.Opinion_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<int?>("Flow_NodeDefineId");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<int?>("User_InfoId");

                    b.Property<string>("content");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("id");

                    b.HasIndex("Flow_NodeDefineId");

                    b.HasIndex("Repair_InfoId");

                    b.HasIndex("User_InfoId");

                    b.ToTable("opinion_Infos");
                });

            modelBuilder.Entity("Dtol.dtol.Reminder_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("Remark");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<int?>("User_InfoId");

                    b.Property<string>("content");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("id");

                    b.HasIndex("Repair_InfoId");

                    b.HasIndex("User_InfoId");

                    b.ToTable("reminder_Infos");
                });

            modelBuilder.Entity("Dtol.dtol.Repair_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RepairsAdress");

                    b.Property<string>("RepairsContent");

                    b.Property<string>("RepairsEmergency");

                    b.Property<string>("RepairsTitle");

                    b.Property<string>("RepairsType");

                    b.Property<int>("User_DepartId");

                    b.Property<int>("User_InfoId");

                    b.Property<string>("isEnd");

                    b.Property<string>("isHandler");

                    b.Property<DateTime?>("repairsDate");

                    b.Property<string>("status");

                    b.Property<string>("telephone");

                    b.HasKey("id");

                    b.HasIndex("User_DepartId");

                    b.HasIndex("User_InfoId");

                    b.ToTable("repair_Info");
                });

            modelBuilder.Entity("Dtol.dtol.Satisfaction_Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("Degree");

                    b.Property<string>("Remark");

                    b.Property<int?>("Repair_InfoId");

                    b.Property<int?>("User_InfoId");

                    b.Property<string>("content");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("id");

                    b.HasIndex("Repair_InfoId");

                    b.HasIndex("User_InfoId");

                    b.ToTable("satisfaction_Infos");
                });

            modelBuilder.Entity("Dtol.dtol.Suggest_Box", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnnexFile");

                    b.Property<string>("Anonymous");

                    b.Property<string>("Content");

                    b.Property<DateTime?>("SuggestDate");

                    b.Property<string>("SuggestType");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("User_InfoId");

                    b.Property<string>("isHandler");

                    b.Property<string>("status");

                    b.HasKey("id");

                    b.HasIndex("User_InfoId");

                    b.ToTable("suggest_Boxes");
                });

            modelBuilder.Entity("Dtol.dtol.UserBind", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Moblie");

                    b.Property<string>("OpenId");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser");

                    b.Property<string>("bak1");

                    b.Property<string>("bak2");

                    b.Property<string>("bak3");

                    b.Property<string>("bak4");

                    b.Property<string>("bak5");

                    b.Property<string>("isDelete");

                    b.Property<string>("passWord");

                    b.Property<string>("userId");

                    b.HasKey("ID");

                    b.ToTable("UserBind");
                });

            modelBuilder.Entity("Dtol.dtol.User_Depart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<string>("ParentId");

                    b.Property<string>("Remark");

                    b.Property<int?>("Sort");

                    b.HasKey("Id");

                    b.ToTable("user_Depart");
                });

            modelBuilder.Entity("Dtol.dtol.User_Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("AddInfoDate");

                    b.Property<string>("Address");

                    b.Property<string>("AwardAndPunish");

                    b.Property<string>("Birthdate");

                    b.Property<string>("BloodType");

                    b.Property<string>("ComputerLevel");

                    b.Property<string>("ContractMaturityDate");

                    b.Property<string>("ContractSignDate");

                    b.Property<string>("Degree");

                    b.Property<string>("Dept");

                    b.Property<string>("DeptId");

                    b.Property<string>("DeptLeaderId");

                    b.Property<string>("DeptLeaderName");

                    b.Property<string>("DriveLevel");

                    b.Property<string>("DzbId");

                    b.Property<string>("Email");

                    b.Property<string>("EmployNature");

                    b.Property<string>("EntryDate");

                    b.Property<string>("FamilyMembers");

                    b.Property<string>("Files");

                    b.Property<string>("FinalEducation");

                    b.Property<string>("FinalGraduated");

                    b.Property<string>("FinalSpecialty");

                    b.Property<string>("ForeignLanguageLevel");

                    b.Property<string>("Gender");

                    b.Property<string>("HomeAddress");

                    b.Property<string>("Idcard");

                    b.Property<string>("InitialEducation");

                    b.Property<string>("InitialGraduated");

                    b.Property<string>("InitialSpecialty");

                    b.Property<string>("Interest");

                    b.Property<string>("JobPerformance");

                    b.Property<string>("JoinPartyDate");

                    b.Property<string>("Levels");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("MobileCall");

                    b.Property<string>("Nation");

                    b.Property<string>("NativePlace");

                    b.Property<string>("Number");

                    b.Property<int?>("OrderId");

                    b.Property<string>("PhoneCall");

                    b.Property<string>("PoliticalBackground");

                    b.Property<string>("Post");

                    b.Property<string>("Remark");

                    b.Property<string>("RoleIdNiwen");

                    b.Property<string>("RoleIds");

                    b.Property<string>("RoleNameNiwen");

                    b.Property<string>("RoleNames");

                    b.Property<string>("ServiceExperience");

                    b.Property<string>("Title");

                    b.Property<string>("TrainSituation");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPwd");

                    b.Property<int?>("User_DepartId");

                    b.Property<string>("WorkExperience");

                    b.Property<string>("ZipCode");

                    b.Property<string>("status");

                    b.Property<DateTime?>("updateDate");

                    b.HasKey("Id");

                    b.HasIndex("User_DepartId");

                    b.ToTable("user_Info");
                });

            modelBuilder.Entity("Dtol.dtol.User_Relate_Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddDate");

                    b.Property<string>("Content");

                    b.Property<int>("Food_InfoId");

                    b.Property<int>("User_InfoId");

                    b.Property<string>("status");

                    b.HasKey("Id");

                    b.HasIndex("Food_InfoId");

                    b.HasIndex("User_InfoId");

                    b.ToTable("user_Relate_Foods");
                });

            modelBuilder.Entity("Dtol.dtol.User_Relate_Info_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("User_InfoId");

                    b.Property<int>("User_RoleId");

                    b.HasKey("Id");

                    b.HasIndex("User_InfoId");

                    b.HasIndex("User_RoleId");

                    b.ToTable("user_Relate_Info_Role");
                });

            modelBuilder.Entity("Dtol.dtol.User_Relate_Role_Right", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("User_RightsId");

                    b.Property<int>("User_RoleId");

                    b.HasKey("Id");

                    b.HasIndex("User_RightsId");

                    b.HasIndex("User_RoleId");

                    b.ToTable("user_Relate_Role_Right");
                });

            modelBuilder.Entity("Dtol.dtol.User_Rights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParentId");

                    b.Property<string>("Remark");

                    b.Property<string>("RightsName");

                    b.Property<string>("RightsValue");

                    b.Property<int?>("Sort");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("user_Rights");
                });

            modelBuilder.Entity("Dtol.dtol.User_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Createdate");

                    b.Property<int?>("Flow_NodeDefineId");

                    b.Property<int?>("Flow_ProcedureId");

                    b.Property<DateTime?>("Level");

                    b.Property<string>("ParentId");

                    b.Property<string>("Remark");

                    b.Property<string>("RightsId");

                    b.Property<string>("RightsName");

                    b.Property<string>("RoleCode");

                    b.Property<string>("RoleName");

                    b.Property<string>("RoleType");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("Flow_NodeDefineId");

                    b.HasIndex("Flow_ProcedureId");

                    b.ToTable("user_Role");
                });

            modelBuilder.Entity("Dtol.dtol.Bulletin_Board", b =>
                {
                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Bulletin_Board_Relate_Role", b =>
                {
                    b.HasOne("Dtol.dtol.Bulletin_Board", "Bulletin_Board")
                        .WithMany()
                        .HasForeignKey("Bulletin_BoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dtol.dtol.User_Role", "User_Role")
                        .WithMany("Bulletin_Board_Relate_Role")
                        .HasForeignKey("User_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Bus_Line", "Bus_Line")
                        .WithMany()
                        .HasForeignKey("Bus_LineId");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Payment", b =>
                {
                    b.HasOne("Dtol.dtol.Bus_Payment_Order", "Bus_Payment_Order")
                        .WithMany()
                        .HasForeignKey("Bus_Payment_OrderId");

                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Payment_Order", b =>
                {
                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Bus_Station", b =>
                {
                    b.HasOne("Dtol.dtol.Bus_Line", "Bus_Line")
                        .WithMany()
                        .HasForeignKey("Bus_LineId");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_CurrentNodeAndNextNode", b =>
                {
                    b.HasOne("Dtol.dtol.Flow_NodeDefine", "Flow_NextNodeDefine")
                        .WithMany()
                        .HasForeignKey("Flow_NextNodeDefineId");

                    b.HasOne("Dtol.dtol.Flow_NodeDefine", "Flow_NodeDefine")
                        .WithMany()
                        .HasForeignKey("Flow_NodeDefineId");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_Node", b =>
                {
                    b.HasOne("Dtol.dtol.Flow_NodeDefine", "Flow_NodeDefine")
                        .WithMany()
                        .HasForeignKey("Flow_NodeDefineId");

                    b.HasOne("Dtol.dtol.Flow_Procedure", "Flow_Procedure")
                        .WithMany()
                        .HasForeignKey("Flow_ProcedureId");

                    b.HasOne("Dtol.dtol.Flow_NodeDefine", "Parent_Flow_NodeDefine")
                        .WithMany()
                        .HasForeignKey("Parent_Flow_NodeDefineId");

                    b.HasOne("Dtol.dtol.Flow_Procedure", "Parent_Flow_Procedure")
                        .WithMany()
                        .HasForeignKey("Parent_Flow_ProcedureId");

                    b.HasOne("Dtol.dtol.User_Info", "Pre_User_Info")
                        .WithMany()
                        .HasForeignKey("Pre_User_InfoId");

                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");

                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany()
                        .HasForeignKey("User_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_NodeDefine", b =>
                {
                    b.HasOne("Dtol.dtol.Flow_ProcedureDefine", "Flow_ProcedureDefine")
                        .WithMany()
                        .HasForeignKey("Flow_ProcedureDefineId");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_Procedure", b =>
                {
                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Flow_Relate_NodeRole", b =>
                {
                    b.HasOne("Dtol.dtol.Flow_NodeDefine", "Flow_NodeDefine")
                        .WithMany("Flow_Relate_NodeRole")
                        .HasForeignKey("Flow_NodeDefineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dtol.dtol.User_Role", "User_Role")
                        .WithMany()
                        .HasForeignKey("User_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dtol.dtol.Opinion_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Flow_NodeDefine", "Flow_NodeDefine")
                        .WithMany()
                        .HasForeignKey("Flow_NodeDefineId");

                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");

                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany()
                        .HasForeignKey("User_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Reminder_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");

                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany()
                        .HasForeignKey("User_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Repair_Info", b =>
                {
                    b.HasOne("Dtol.dtol.User_Depart", "User_Depart")
                        .WithMany()
                        .HasForeignKey("User_DepartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany()
                        .HasForeignKey("User_InfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dtol.dtol.Satisfaction_Info", b =>
                {
                    b.HasOne("Dtol.dtol.Repair_Info", "Repair_Info")
                        .WithMany()
                        .HasForeignKey("Repair_InfoId");

                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany()
                        .HasForeignKey("User_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.Suggest_Box", b =>
                {
                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany()
                        .HasForeignKey("User_InfoId");
                });

            modelBuilder.Entity("Dtol.dtol.User_Info", b =>
                {
                    b.HasOne("Dtol.dtol.User_Depart", "User_Depart")
                        .WithMany()
                        .HasForeignKey("User_DepartId");
                });

            modelBuilder.Entity("Dtol.dtol.User_Relate_Food", b =>
                {
                    b.HasOne("Dtol.dtol.Food_Info", "Food_Info")
                        .WithMany()
                        .HasForeignKey("Food_InfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany()
                        .HasForeignKey("User_InfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dtol.dtol.User_Relate_Info_Role", b =>
                {
                    b.HasOne("Dtol.dtol.User_Info", "User_Info")
                        .WithMany("User_Relate_Info_Role")
                        .HasForeignKey("User_InfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dtol.dtol.User_Role", "User_Role")
                        .WithMany("User_Relate_Info_Role")
                        .HasForeignKey("User_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dtol.dtol.User_Relate_Role_Right", b =>
                {
                    b.HasOne("Dtol.dtol.User_Rights", "User_Rights")
                        .WithMany()
                        .HasForeignKey("User_RightsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dtol.dtol.User_Role", "User_Role")
                        .WithMany("User_Relate_Role_Right")
                        .HasForeignKey("User_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dtol.dtol.User_Role", b =>
                {
                    b.HasOne("Dtol.dtol.Flow_NodeDefine", "Flow_NodeDefine")
                        .WithMany()
                        .HasForeignKey("Flow_NodeDefineId");

                    b.HasOne("Dtol.dtol.Flow_Procedure", "Flow_Procedure")
                        .WithMany()
                        .HasForeignKey("Flow_ProcedureId");
                });
#pragma warning restore 612, 618
        }
    }
}
