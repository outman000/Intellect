﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Relate_Info_Role
    {
      
        public int Id { get; set; }

        public int User_Info_ID { get; set; }

        public User_Info User_Info { get; set; }

        public int User_Role_ID { get; set; }

        public User_Role User_Role { get; set; }

    }
}
