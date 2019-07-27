using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_Node
    {
 
        public int Id{get;set;}
        /// <summary>
        /// 当前节点id
        /// </summary>
        [InverseProperty("Flow_NodeDefineId")]
        public int? Flow_NodeDefineId{get;set;}
        public Flow_NodeDefine Flow_NodeDefine{get;set;}
        /// <summary>
        /// 父节点id
        /// </summary>
        [InverseProperty("Parent_Flow_NodeDefineId")]
        public int? Parent_Flow_NodeDefineId{get;set;}
        public Flow_NodeDefine Parent_Flow_NodeDefine{get;set;}
        /// <summary>
        /// 当前流程id
        /// </summary>

        [InverseProperty("Flow_ProcedureId")]
        public int? Flow_ProcedureId{get;set;}
        public Flow_Procedure  Flow_Procedure{get;set;}
        /// <summary>
        /// 父流程id
        /// </summary>
       [InverseProperty("Flow_ProcedureId")]
        public int? Parent_Flow_ProcedureId{get;set;}
        public Flow_Procedure Parent_Flow_Procedure{get;set;}
        /// <summary>
        /// 操作状态
        /// </summary>
        public string operate{get;set;}
        /// <summary>
        /// 当前节点操作人员
        /// </summary>

        public int? User_InfoId{get;set;}
        public User_Info User_Info{get;set;}
        /// <summary>
        /// 父节点操作人员
        /// </summary>
     
        public int? Pre_User_InfoId{get;set;}
        public User_Info Pre_User_Info{get;set;}


        /// <summary>
        /// 表单id
        /// </summary>
        public int? Repair_InfoId { get; set; }
        public Repair_Info Repair_Info { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public string status{get;set;}
        public DateTime? StartTime{get;set;}
        public DateTime? EndTime{get;set;}
    }
}
