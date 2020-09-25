using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowNodeKeepSearchViewModel
    {
        /// <summary>
        /// 当前节点id
        /// </summary>
        public int Flow_NodeDefineId { get; set; }


        /// <summary>
        /// 节点id
        /// </summary>
        public int Flow_NextNodeDefineId { get; set; }


        /// <summary>
        /// 表单id(此属性可以为空)
        /// </summary>
        public int Repair_InfoId { get; set; }


    }
}
