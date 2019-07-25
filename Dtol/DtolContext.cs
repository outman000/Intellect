using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dtol.dtol;

namespace Dtol
{
    public class   DtolContext: DbContext
    {

        public DtolContext()
        {
        }

        public DtolContext(DbContextOptions<DtolContext> options)
            : base(options)
        {
        }

        //连接复原
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //    optionsBuilder
        //        .UseSqlServer(
        //            @"Server = DESKTOP - QEJHC80\\SQL2014; Database = User_DateBase; Trusted_Connection = True;ConnectRetryCount=0",
        //            options => options.EnableRetryOnFailure());


        //}


        public DbSet<User_Info> user_Info { get; set; }
        public DbSet<User_Rights> user_Rights { get; set; }
        public DbSet<User_Role> user_Role { get; set; }
        public DbSet<User_Relate_Role_Right> user_Relate_Role_Right { get; set; }
        public DbSet<User_Relate_Info_Role> user_Relate_Info_Role { get; set; }
        public DbSet<User_Depart>user_Depart { get; set; }
        public DbSet<Bus_Info> bus_Info { get; set; }
        public DbSet<Bus_Line> bus_Line { get; set; }
        public DbSet<Bus_Station> bus_Station { get; set; }
        public DbSet<Bus_Payment> bus_Payment { get; set; }
        public DbSet<Repair_Info> repair_Info { get; set; }
        public DbSet<Flow_Node> flow_Node { get; set; }
        public DbSet<Flow_NodeDefine> flow_NodeDefine { get; set; }
        public DbSet<Flow_Procedure> flow_Procedure { get; set; }
        public DbSet<Flow_ProcedureDefine> flow_ProcedureDefine { get; set; }
        public DbSet<Flow_Relate_NodeRole> flow_Relate_NodeRole { get; set; }










    }
}
