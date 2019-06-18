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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=EFMiscellanous.ConnectionResiliency;Trusted_Connection=True;ConnectRetryCount=0",
                    options => options.EnableRetryOnFailure());


        }


        public DbSet<User_Info> user_Info { get; set; }
        public DbSet<User_Rights> user_Rights { get; set; }
        public DbSet<User_Role> user_Role { get; set; }






    }
}
