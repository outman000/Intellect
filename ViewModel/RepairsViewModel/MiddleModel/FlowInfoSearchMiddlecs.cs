using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class FlowInfoSearchMiddlecs
    {
        /// <summary>
        /// 当前节点id
        /// </summary>
        public int Flow_NodeDefineId { get; set; }



        /// <summary>
        /// 当前流程id
        /// </summary>
        public int Flow_ProcedureId { get; set; }

        /// <summary>
        /// 当前节点操作人员
        /// </summary>
        public int User_InfoId { get; set; }


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
    }
}
