using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserRegisterSearchViewModel
    {
        public string status { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? strDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        UserRegisterSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
