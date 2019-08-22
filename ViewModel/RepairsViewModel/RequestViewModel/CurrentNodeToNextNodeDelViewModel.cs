using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class CurrentNodeToNextNodeDelViewModel
    {
        /// <summary>
        /// 当前节点Id和下一节点Id集合
        /// </summary>
        public List<CurrentNodeToNextNodeDelMiddlecs> CurrentNodeAndNextNodeIdList { get; set; }
    }
}
