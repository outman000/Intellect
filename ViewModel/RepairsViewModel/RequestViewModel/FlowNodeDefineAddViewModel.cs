using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    /// <summary>
    /// 报修表单增加视图
    /// </summary>
    /// 
    public class FlowNodeDefineAddViewModel
    {
        /// <summary>
        /// 节点名
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 下一节点id
        /// </summary>
        public int? Flow_NextNodeDefineId { get; set; }

        /// <summary>
        /// 流程id
        /// </summary>
        public int? Flow_ProcedureDefineId { get; set; }


        /// <summary>
        /// 节点类型
        /// </summary>

        public string NodeType { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public string status { get; set; }

     
    }
}
