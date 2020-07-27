using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel
{
    public class BusLocationInformationSearchViewModel
    {


        /// <summary>
        /// 线路主键id
        /// </summary>

        public int LineId { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
