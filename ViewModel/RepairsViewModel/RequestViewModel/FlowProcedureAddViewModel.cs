using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    /// <summary>
    /// 流程增加视图
    /// </summary>
    /// 
    public class FlowProcedureAddViewModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Starttime { get; set; }
 
        /// <summary>
        /// 描述
        /// </summary>
        public string remark { get; set; }
    }
}
