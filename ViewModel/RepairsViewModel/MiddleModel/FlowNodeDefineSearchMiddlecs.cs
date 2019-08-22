using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class FlowNodeDefineSearchMiddlecs
    {


        /// <summary>
        /// 当前节点id
        /// </summary>
        public int Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 节点名
        /// </summary>
        public string NodeName { get; set; }


        /// <summary>
        /// 流程名
        /// </summary>
        public string FlowProcedureDefineName { get; set; }
        /// <summary>
        /// 流程id
        /// </summary>
        public int? Flow_ProcedureDefineId { get; set; }


        /// <summary>
        /// 节点类型
        /// </summary>

        public string NodeType { get; set; }

        /// <summary>
        /// 节点保持
        /// </summary>

        public string NodeKeep { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public string status { get; set; }

    }
}
