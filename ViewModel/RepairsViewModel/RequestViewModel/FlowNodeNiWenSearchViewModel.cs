using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowNodeNiWenSearchViewModel
    {
       

        /// <summary>
        /// 表单id
        /// </summary>
        public int Repair_InfoId { get; set; }


        /// <summary>
        /// 父节点id（***开始节点的时候可不传***，查询当前未办方法给前台返回（Flow_NodeDefineId））
        /// </summary>
        public int? Parent_Flow_NodeDefineId { get; set; }

    }
}
