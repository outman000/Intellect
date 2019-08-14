using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowProcedureDefineUpdateViewModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 流程名
        /// </summary>
        public string ProcedureName { get; set; }
        /// <summary>
        /// 流程标识
        /// </summary>
        public string ProcedureCode { get; set; }
     
        /// <summary>
        /// 流程类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 流程描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? Updatetime { get; set; }
    }
}
