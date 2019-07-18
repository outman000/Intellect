using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel
{
    /// <summary>
    /// 线路增加视图
    /// </summary>
    /// 
    public class LineAddViewModel
    {
        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 线路状态 0-启用  1-禁用
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 线路标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 线路描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
