using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Bus_Station
    {
        public int Id { get; set; }
        public string StationName { get; set; }

        public string status { get; set; }
        public string Code { get; set; }
        public decimal? Expense { get; set; }
        public DateTime? OnWorkDate { get; set; }
        public DateTime? OffWorkDate { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? updateDate { get; set; }
        /// <summary>
        /// 线路Id   ---外键
        /// </summary>
        public int? Bus_LineId { get; set; }

        public Bus_Line Bus_Line { get; set; }
    }
}
