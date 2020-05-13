using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class Bus_OrderIsPassSearchViewModel
    { 
        /// <summary>
         /// 用户id
         /// </summary>
        public string User_InfoId { get; set; }
        /// <summary>
        /// 是否通过（通过，未通过）
        /// </summary>
        public string isPass { get; set; }
    }
}
