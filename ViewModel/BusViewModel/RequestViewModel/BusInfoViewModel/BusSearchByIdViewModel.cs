using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel
{
    public class BusSearchByIdViewModel
    {
        /// <summary>
        /// 线路id
        /// </summary>
        public int Bus_LineId { get; set; }

        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime carDate { get; set; }

    }
}
