using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowProcedureAddViewModel
    {

        /// <summary>
        /// 流程状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 表单id
        /// </summary>
        public int? Repair_InfoId { get; set; }
        /// <summary>
        /// 流程开始时间
        /// </summary>
        public DateTime? Starttime { get; set; }

    }
}
