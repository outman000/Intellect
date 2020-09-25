using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class CarOccupyMiddle
    {

        /// <summary>
        /// 用车时间
        /// </summary>
        public string docdate { get; set; }


        /// <summary>
        /// 乘车人
        /// </summary>
        public string hyjylx { get; set; }

        /// <summary>
        /// 上车地点
        /// </summary>
        public string spzt { get; set; }

        /// <summary>
        /// 下车地点
        /// </summary>
        public string yylb { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        public string cxry { get; set; }


        /// <summary>
        /// 车牌号
        /// </summary>
        public string FWJG { get; set; }


        /// <summary>
        /// 用车状态
        /// </summary>
        public string status;

    }
}
