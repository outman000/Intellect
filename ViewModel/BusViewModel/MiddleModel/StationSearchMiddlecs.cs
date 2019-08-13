using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class StationSearchMiddlecs
    {
        /// <summary>
        /// 站点id
        /// </summary>
        public int Id { get; set; }
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
        /// 站点费用
        /// </summary>
        public decimal? Expense { get; set; }
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
        /// <summary>
        /// 更新数据时间
        /// </summary>
        public DateTime? updateDate { get; set; }
        /// <summary>
        /// 线路Id   ---外键
        /// </summary>
        public int Bus_LineId { get; set; }
    }
}
