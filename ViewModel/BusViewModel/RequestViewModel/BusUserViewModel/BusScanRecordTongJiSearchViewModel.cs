using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusScanRecordTongJiSearchViewModel
    {

        /// <summary>
        /// 线路名
        /// </summary>

        public int? LineId { get; set; }



        /// <summary>
        /// 扫码时间
        /// </summary>
        public DateTime AddDate { get; set; }


    }
}
