using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserRoleUpdateViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 0为启用1为停用
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
