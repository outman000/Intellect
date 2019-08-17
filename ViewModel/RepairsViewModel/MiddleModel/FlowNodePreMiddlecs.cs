using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class FlowNodePreMiddlecs
    {

        /// <summary>
        /// 当前节点id（开始节点为增加表单方法返回的（Flow_NodeDefineId），其他节点为上次调用本方法给前台返回（Flow_NextNodeDefineId））
        /// </summary>
        public int Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 下一节点id
        /// </summary>
        public int? Flow_NextNodeDefineId { get; set; }
        /// <summary>
        /// 流程id
        /// </summary>
        public int? Flow_ProcedureId { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>

        public string NodeType { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 父节点操作人员
        /// </summary>
        public int? Pre_User_InfoId { get; set; }

        /// <summary>
        /// 到达时间（开始节点，数据默认为当前提交时间；其他节点为上一节点的提交时间（EndTime））
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 提交时间（开始和拟文节点 StartTime=EndTime；其他节点数据默认为当前提交时间）
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
