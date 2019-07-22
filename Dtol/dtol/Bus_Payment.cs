using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Bus_Payment
    {
        public int Id { get; set; }
        public int? Bus_StationId { get; set; }
        public Bus_Station Bus_Station { get; set; }
        public int? Bus_LineId { get; set; }
        public Bus_Line Bus_Line { get; set; }
        public int? User_InfoId { get; set; }
        public User_Info User_Info { get; set; }
        public int? User_DepartId { get; set; }
        public User_Depart User_Depart { get; set; }
        public DateTime? createDate{ get; set; }

    }
}
