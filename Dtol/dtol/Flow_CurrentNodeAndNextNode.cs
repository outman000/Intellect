using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_CurrentNodeAndNextNode
    {
        public int Id { get; set; }
        /// <summary>
        /// 当前节点id
        /// </summary>
        public int? Flow_NodeDefineId { get; set; }
        public Flow_NodeDefine Flow_NodeDefine { get; set; }

        /// <summary>
        /// 下一节点id
        /// </summary>

        public int? Flow_NextNodeDefineId { get; set; }
        public Flow_NodeDefine Flow_NextNodeDefine { get; set; }

        /// <summary>
        /// 节点保持
        /// </summary>

        public string NodeKeep { get; set; }


    }
}
