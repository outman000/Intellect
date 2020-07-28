using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class BusLocationInformationSearchMiddle
    {

      

        /// <summary>
        /// 班车位置信息经度
        /// </summary>
        public string latitude { get; set; }

      

        /// <summary>
        /// 班车位置信息纬度
        /// </summary>
        public string longitude { get; set; }


        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime AddDate { get; set; }
    }
}
