using Dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellUser.BaseClass
{
    public class EFBaseClass
    {
        public static string connection = "";


        static DbContextOptions<DtolContext> dbContextOption = new DbContextOptions<DtolContext>();
        static DbContextOptionsBuilder<DtolContext> dbContextOptionBuilder = new DbContextOptionsBuilder<DtolContext>(dbContextOption);
        public DtolContext _dbContext = new DtolContext(dbContextOptionBuilder.UseSqlServer(connection).Options);


    }
}
