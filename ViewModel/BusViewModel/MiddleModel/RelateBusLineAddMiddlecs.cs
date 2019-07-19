using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class RelateBusLineAddMiddlecs
    {
        /// <summary>
        /// 班车id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 线路Id   ---外键
        /// </summary>
        public int? Bus_LineId { get; set; }
    }
}
