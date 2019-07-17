using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
   public class RightsByRoleSearchViewModel
    {
        public int RoleId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        RightsByRoleSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
