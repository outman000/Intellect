using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel
{       /// <summary>
       /// 站点增加视图
       /// </summary>
       /// 
    public class StationAddViewModel
    {
       
        /// <summary>
        /// 站点名称
        /// </summary>
        public string StationName { get; set; }
        /// <summary>
        /// 站点状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 站点标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 站点描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 上班到达站点时间
        /// </summary>
        public DateTime? OnWorkDate { get; set; }
        /// <summary>
        /// 下班到达站点时间
        /// </summary>
        public DateTime? OffWorkDate { get; set; }
        /// <summary>
        /// 增加数据时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
