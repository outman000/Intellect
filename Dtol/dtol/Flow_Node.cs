using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_Node
    {
        public string Id;
        /// <summary>
        /// 当前节点id
        /// </summary>
        public int Flow_NodeDefineId;
        public Flow_NodeDefine Flow_NodeDefine;
        /// <summary>
        /// 父节点id
        /// </summary>
        public int Parent_Flow_NodeDefineId;
        public Flow_NodeDefine Parent_Flow_NodeDefine;
        /// <summary>
        /// 当前流程id
        /// </summary>
        public int Flow_ProcedureId;
        public Flow_Procedure  Flow_Procedure;
        /// <summary>
        /// 父流程id
        /// </summary>
        public int Parent_Flow_ProcedureId;
        public Flow_Procedure Parent_Flow_Procedure;
        public string status;
        public int User_InfoId;
        public User_Info User_Info;
        public int Pre_User_InfoId;
        public User_Info Pre_User_Info;
        public DateTime? StartTime;
        public DateTime? EndTime;
    }
}
