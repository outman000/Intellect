using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class Bank_Payment_SearchMiddle
    {
        /// <summary>
        ///商户号
        /// </summary>
        public string merchantNo { get; set; }

        /// <summary>
        ///错误码
        /// </summary>
        public string exception { get; set; }
        /// <summary>
        ///商户订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        ///银行订单流水号
        /// </summary>
        public string orderSeq { get; set; }


        /// <summary>
        ///订单状态
        /// </summary>
        public string orderStatus { get; set; }

        /// <summary>
        ///银行卡类别
        /// </summary>
        public string cardTyp { get; set; }

        /// <summary>
        ///支付时间
        /// </summary>
        public string payTime { get; set; }

        /// <summary>
        ///支付金额
        /// </summary>
        public string payAmount { get; set; }
        /// <summary>
        ///银联订单号
        /// </summary>
        public string unionPaySeq { get; set; }

    }
}
