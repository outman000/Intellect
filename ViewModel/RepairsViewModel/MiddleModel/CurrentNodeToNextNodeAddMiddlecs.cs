using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class CurrentNodeToNextNodeAddMiddlecs
    {
        /// <summary>
        /// 当前节点id
        /// </summary>

        public int? Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 下一节点id
        /// </summary>

        public int? Flow_NextNodeDefineId { get; set; }
    }
}
