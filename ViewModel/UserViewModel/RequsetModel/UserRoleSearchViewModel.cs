using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 角色查询视图
    /// </summary>
    public class UserRoleSearchViewModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色状态 0停用1启用
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public string RoleType { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public PageViewModel pageViewModel { get; set; }

        UserRoleSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
