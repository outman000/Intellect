using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class WorkFlowFistReturnIdList
    {
        /// <summary>
        /// 表单id
        /// </summary>
        public int Repair_InfoId { get; set; }

        /// <summary>
        /// 当前节点操作人员
        /// </summary>
        public int User_InfoId { get; set; }

        /// <summary>
        /// 当前节点id
        /// </summary>
        public int Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 当前流程id
        /// </summary>
        public int Flow_ProcedureId { get; set; }

        /// <summary>
        /// 表单类型
        /// </summary>
        public string RepairType { get; set; }
    }
}
