using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusPaymentUpdateViewModel
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public int User_DepartId { get; set; }

        ///// <summary>
        ///// 表单id
        ///// </summary>
        //public int Repair_InfoId { get; set; }

        /// <summary>
        /// 订单id
        /// </summary>
        public int Bus_Payment_OrderId { get; set; }
        

        // <summary>
        /// 乘车时间
        /// </summary>
        public DateTime carDate { get; set; }
    }
}
