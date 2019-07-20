using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel
{
    public class StationByLineSearchViewModel
    {
        /// <summary>
        /// 线路Id   ---外键
        /// </summary>
        public int Bus_LineId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        StationByLineSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
