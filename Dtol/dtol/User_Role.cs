using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public partial class User_Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RightsId { get; set; }
        public string Remark { get; set; }
        public string RightsName { get; set; }
        public string ParentId { get; set; }
        public string RoleType { get; set; }
        public string RoleCode { get; set; }
        public string Status { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? Level { get; set; }
        public int? Flow_NodeDefineId { get; set; }
        public Flow_NodeDefine Flow_NodeDefine { get; set; }

        public int? Flow_ProcedureId { get; set; }
        public Flow_Procedure Flow_Procedure { get; set; }

        public virtual ICollection<User_Relate_Role_Right> User_Relate_Role_Right { get; set; }

        public virtual ICollection<User_Relate_Info_Role> User_Relate_Info_Role { get; set; }
    }
}
