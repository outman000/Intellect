using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserRoleSearchViewModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public String RoleName { get; set; }
        /// <summary>
        /// 角色状态 0停用1启用
        /// </summary>
        public String Status { get; set; }
    }
}
