using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class FlowNodeDefineSearchMiddlecs
    {

        /// <summary>
        /// 节点名
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 下一节点名
        /// </summary>

        public string FlowNextName { get; set; }
        /// <summary>
        /// 流程名
        /// </summary>
        public string FlowProcedureDefineName { get; set; }


        /// <summary>
        /// 节点类型
        /// </summary>

        public string NodeType { get; set; }

    }
}
