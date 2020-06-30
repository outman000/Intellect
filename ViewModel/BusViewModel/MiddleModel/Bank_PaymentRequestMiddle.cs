using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class Bank_PaymentRequestMiddle
    {
        /// <summary>
        ///订单主键Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 支付标识 0-未支付，1-已支付，2-已确认
        /// </summary>
        public string paymentStatus { get; set; }

    }
}
