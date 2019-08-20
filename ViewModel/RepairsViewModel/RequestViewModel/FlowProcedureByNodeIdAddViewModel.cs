using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowProcedureByNodeIdAddViewModel
    {
   
        /// <summary>
        /// 节点定义Id和流程定义Id集合
        /// </summary>
        public List<FlowProcedureByNodeIdAddMiddlecs> relateNodeIdAndProcedureIdList { get; set; }
    }
}
