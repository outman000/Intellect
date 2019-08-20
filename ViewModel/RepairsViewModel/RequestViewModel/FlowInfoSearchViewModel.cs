using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowInfoSearchViewModel
    {

        /// <summary>
        /// 当前节点id（调用查询节点定义方法给前台返回（Flow_NextNodeDefineId））
        /// </summary>
        public int Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 父节点id（***开始节点的时候可不传***，查询当前未办方法给前台返回（Flow_NodeDefineId））
        /// </summary>
        public int? Parent_Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 当前流程id（查询当前未办方法给前台返回）
        /// </summary>
        public int Flow_ProcedureId { get; set; }

        /// <summary>
        /// 当前节点操作人员（***结束节点的时候可不传***，开始和拟文节点的时候该值为调用增加表单的时候获取的表单上用户Id,其他的节点是根据节点查人员列表获取的）
        /// </summary>
        public int? User_InfoId { get; set; }

        /// <summary>
        /// 父节点操作人员(***开始节点的时候可不传***，开始节点的时候该值为空（查询当前未办方法给前台返回（User_InfoId））)
        /// </summary>
        public int? Pre_User_InfoId { get; set; }

        /// <summary>
        /// 表单id（调用增加表单的时候获取的）
        /// </summary>
        public int Repair_InfoId { get; set; }

        /// <summary>
        /// 操作状态（数据设置为默认为1）
        /// </summary>
        public string operate { get; set; }

        /// <summary>
        /// 是否删除（数据设置为默认为0）
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 到达时间（数据默认为当前提交时间）
        /// </summary>
        public DateTime? StartTime { get; set; }
        ///// <summary>
        ///// 提交时间（开始节点 StartTime=EndTime，其他节点不传）
        ///// </summary>
        //public DateTime? EndTime { get; set; }
    }
}
