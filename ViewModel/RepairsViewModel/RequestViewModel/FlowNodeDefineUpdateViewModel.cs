using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowNodeDefineUpdateViewModel
    {
        /// <summary>
        /// 节点id
        /// </summary>
        public int Id { get; set; }

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
       /// 修改时间
       /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
