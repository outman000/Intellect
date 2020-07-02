using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
   public class OrderUrlMiddle
    {
        /// <summary>
        ///订单主键Id
        /// </summary>
        public int OrderId { get; set; }


        /// <summary>
        ///订单金额
        /// </summary>
        public string orderAmount { get; set; }
    }
}
