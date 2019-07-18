using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class RoleByRightsSearchViewModel
    {
        /// <summary>
        /// 权限id
        /// </summary>
        public int RightId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        RoleByRightsSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
