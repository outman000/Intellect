using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel
{
  public  class BusByLineAddViewModel
    {
        /// <summary>
        /// 班车id集合
        /// </summary>
        public List<RelateBusLineAddMiddlecs> relateBusIdAndLineIdList { get; set; }
    }
}
