using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel
{
    public class StationByBusSearchViewModel
    {
        /// <summary>
        /// 班车id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 线路Id   ---外键
        /// </summary>
        public int? Bus_LineId { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        StationByBusSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
