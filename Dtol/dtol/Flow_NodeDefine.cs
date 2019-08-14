using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_NodeDefine
    {
        /// <summary>
        /// 当前节点id
        /// </summary>
        public int Id { get;set;}
        /// <summary>
        /// 节点名
        /// </summary>
        public string NodeName { get; set; }
        public DateTime? CreateTime{get;set;}
        public DateTime? UpdateTime{get;set;}
        /// <summary>
        /// 下一节点id
        /// </summary>

        public int? Flow_NextNodeDefineId { get; set; }
        public Flow_NodeDefine Flow_NextNodeDefine { get; set; }
        /// <summary>
        /// 流程id
        /// </summary>
        public int? Flow_ProcedureDefineId { get; set; }
        public Flow_ProcedureDefine Flow_ProcedureDefine { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>

        public string NodeType { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 角色集合
        /// </summary>
        public ICollection<Flow_Relate_NodeRole> Flow_Relate_NodeRole { get; set; }
    }
}
