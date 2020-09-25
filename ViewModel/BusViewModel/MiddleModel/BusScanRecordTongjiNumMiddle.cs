using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class BusScanRecordTongjiNumMiddle
    {
        /// <summary>
        /// 站点名
        /// </summary>
        public string StationName { get; set; }


        /// <summary>
        ///每个站点名的刷卡数量
        /// </summary>
        public int Num { get; set; }
    }
}
