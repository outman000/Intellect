using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Relate_Role_Right
    {
        public int Id { get; set; }

        public int User_RightsId { get; set; }

        public User_Rights User_Rights { get; set; }

        public int User_RoleId { get; set; }

        public User_Role User_Role { get; set; }
    }
}
