using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_Procedure
    {
        public int id { get; set; }
        public int User_RoleId { get; set; }
        public User_Role  User_Role { get; set; }
        public int status { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public string remark { get; set; }
    }
}
