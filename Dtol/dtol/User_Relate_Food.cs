using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Relate_Food
    {
        public int Id { get; set; }

        public int User_InfoId { get; set; }

        public User_Info User_Info { get; set; }

        public int Food_InfoId { get; set; }

        public Food_Info Food_Info { get; set; }

    }
}
