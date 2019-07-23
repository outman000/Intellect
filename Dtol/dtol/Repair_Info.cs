using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public  class Repair_Info
    {
        public int id{get;set;}
        public int User_InfoId { get; set; }
        public User_Info User_Info { get; set; }
        public int User_DepartId{get;set;}
        public User_Depart User_Depart{get;set;}
        public string RepairsTitle{ get; set; }
        public string RepairsType{get;set;}
        public string RepairsEmergency{get;set;}
        public string RepairsContent{get;set;}
        public DateTime? repairsDate{get;set;}
        public string RepairsAdress{get;set;}
        public string telephone{get;set;}
        public string status { get; set; }
    }
}
