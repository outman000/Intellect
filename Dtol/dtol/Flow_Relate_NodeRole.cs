using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_Relate_NodeRole
    {
        public int id { get; set; }
        public int Flow_NodeDefineId { get; set; }
        public Flow_NodeDefine  Flow_NodeDefine { get; set; }
        public int User_RoleId { get; set; }
        public User_Role  User_Role { get; set; }


    }
}
