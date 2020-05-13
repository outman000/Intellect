using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class FlowNodeSearchMiddlecs
    {

        public int Id { get; set; }
        /// <summary>
        /// 当前节点id
        /// </summary>
        public int? Flow_NodeDefineId { get; set; }
        /// <summary>
        /// 当前节点名称
        /// </summary>
        public string Flow_NodeDefineName { get; set; }
        /// <summary>
        /// 父节点id
        /// </summary>
        public int? Parent_Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 当前流程id
        /// </summary>
        public int? Flow_ProcedureId { get; set; }

        /// <summary>
        /// 父流程id
        /// </summary>  
        public int? Parent_Flow_ProcedureId { get; set; }
        /// <summary>
        /// 表单信息
        /// </summary>
        public FlowNodeRepaireInfoMiddle Repair_Info { get; set; }
        /// <summary>
        /// 表单id
        /// </summary>
        public int? Repair_InfoId { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        public string operate { get; set; }
        /// <summary>
        /// 当前操作人员信息
        /// </summary>
        public FlowNodeUserInfoMiddles User_Info{ get; set; }


        /// <summary>
        /// 当前节点操作人员
        /// </summary>
        public int? User_InfoId { get; set; }

        /// <summary>
        /// 父操作人员信息
        /// </summary>
        public FlowNodeUserInfoMiddles Pre_User_Info { get; set; }



        /// <summary>
        /// 父节点操作人员
        /// </summary>
        public int? Pre_User_InfoId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
