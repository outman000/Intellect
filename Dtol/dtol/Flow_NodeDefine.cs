using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Flow_NodeDefine
    {
        public int id{get;set;}
        public int Flow_ProcedureId{get;set;}
        public Flow_ProcedureDefine Flow_ProcedureDefine{get;set;}
        public int User_RoleId{get;set;}
        public List<User_Role> User_Role{get;set;}
        public string NodeName { get; set; }
        public string NextNodeName { get; set; }
        public int NextNodeId{ get; set; }
        public DateTime? CreateTime{get;set;}
        public DateTime? UpdateTime{get;set;}


    }
}
