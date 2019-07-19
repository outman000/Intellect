using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;

namespace ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel
{
    public class StationByLineAddViewModel
    {
        /// <summary>
        /// 站点id集合
        /// </summary>
        public List<RelateLineStationAddMiddlecs> relateLineIdAndStationIdList{ get; set; }
    }
}
