using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel
{
    public class BusByLineSearchViewModel
    {
        /// <summary>
        /// 部门Id   ---外键
        /// </summary>
        public int Bus_LineId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        BusByLineSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
