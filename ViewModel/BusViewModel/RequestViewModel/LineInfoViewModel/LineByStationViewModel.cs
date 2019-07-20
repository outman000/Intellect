using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel
{
    public class LineByStationViewModel
    {
        /// <summary>
        /// 站点id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        LineByStationViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
