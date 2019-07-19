using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel
{
    public class LineByBusSearchViewModel
    {
        /// <summary>
        /// 班车id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        LineByBusSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
