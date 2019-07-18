using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class RelateDepartUserAddMiddlecs
    {
        /* public string Name { get; set; }
         public string ParentId { get; set; }
         public string Code { get; set; }
         public string Remark { get; set; }
         public int? Sort { get; set; }*/
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }
    }
}
