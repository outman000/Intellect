using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 根据角色查询用户
    /// </summary>
  public  class UserByRoleSearchViewModel
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        UserByRoleSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
