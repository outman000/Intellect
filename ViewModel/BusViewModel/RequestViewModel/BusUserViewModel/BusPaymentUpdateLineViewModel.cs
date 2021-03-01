using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusPaymentUpdateLineViewModel
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 站点id
        /// </summary>
        public int? Bus_StationId { get; set; }

        /// <summary>
        /// 线路id
        /// </summary>
        public int? Bus_LineId { get; set; }


        /// <summary>
        /// 站点名
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 线路名
        /// </summary>
        public string LineName { get; set; }

      
    }
}
