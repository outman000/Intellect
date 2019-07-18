using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
   public class RightsByRoleSearchViewModel
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
        RightsByRoleSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
