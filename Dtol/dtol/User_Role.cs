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
        public virtual ICollection<User_Rights> SMUserRights{ get; set; }
    }
}
