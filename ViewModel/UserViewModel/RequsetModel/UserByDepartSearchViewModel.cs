using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserByDepartSearchViewModel
    {
        /// <summary>
        /// 线路Id   ---外键
        /// </summary>
        public int User_DepartId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
       
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        UserByDepartSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
