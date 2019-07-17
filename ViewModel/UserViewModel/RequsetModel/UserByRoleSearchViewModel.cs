using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
  public  class UserByRoleSearchViewModel
    {
        public int RoleId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        UserByRoleSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
