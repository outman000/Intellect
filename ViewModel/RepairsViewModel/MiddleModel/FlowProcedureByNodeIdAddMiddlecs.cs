using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class FlowProcedureByNodeIdAddMiddlecs
    {
        /// <summary>
        /// 流程定义Id
        /// </summary>
        public int? Flow_ProcedureDefineId { get; set; }
        /// <summary>
        /// 节点定义Id
        /// </summary>
        public int Flow_NodeDefineId { get; set; }
    }
}
