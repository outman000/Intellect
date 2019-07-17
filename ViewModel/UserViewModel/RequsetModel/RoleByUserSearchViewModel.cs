using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
   public  class RoleByUserSearchViewModel
    {
        public int UserId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        RoleByUserSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
