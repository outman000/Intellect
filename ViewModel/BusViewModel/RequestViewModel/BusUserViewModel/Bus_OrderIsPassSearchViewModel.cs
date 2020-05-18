using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class Bus_OrderIsPassSearchViewModel
    { 
        /// <summary>
         /// 用户id
         /// </summary>
        public string User_InfoId { get; set; }
        /// <summary>
        /// 是否通过（通过，未通过）
        /// </summary>
        public string isPass { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        Bus_OrderIsPassSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
