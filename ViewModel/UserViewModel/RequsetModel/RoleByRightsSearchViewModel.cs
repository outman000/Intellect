using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class RoleByRightsSearchViewModel
    {

        public int RightId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        RoleByRightsSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
