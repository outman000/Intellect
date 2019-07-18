using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 角色增加视图
    /// </summary>
    public partial class UserRoleAddViewModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 角色状态0启用1停用
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Createdate { get; set; }
    }
}
