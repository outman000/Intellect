﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_Procedure
    {
        public int Id { get; set; }
        public string status { get; set; }
        /// <summary>
        /// 表单id
        /// </summary>
        public int? Repair_InfoId { get; set; }
        public Repair_Info Repair_Info { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public string remark { get; set; }
    }
}
