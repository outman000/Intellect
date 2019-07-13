using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

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
