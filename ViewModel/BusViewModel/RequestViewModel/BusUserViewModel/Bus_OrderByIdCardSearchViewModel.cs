using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class Bus_OrderByIdCardSearchViewModel
    {

        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string IDNumber { get; set; }


        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime CarDate { get; set; }
    }
}
