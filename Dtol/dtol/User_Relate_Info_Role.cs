using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Relate_Info_Role
    {
      
        public int Id { get; set; }

        public int User_InfoId { get; set; }

        public User_Info User_Info { get; set; }

        public int User_RoleId { get; set; }

        public User_Role User_Role { get; set; }

    }
}
