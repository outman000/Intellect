using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel
{
    public class LineByBusAddViewModel
    {
        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 班车id
        /// </summary>
        public int Busid { get; set; }
      
    }
}
