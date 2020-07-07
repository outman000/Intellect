using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class Bank_Payment_RefundMiddle
    {


        /// <summary>
        ///商户号
        /// </summary>
        public string merchantNo { get; set; }

        /// <summary>
        ///返回操作类型
        /// </summary>
        public string returnActFlag { get; set; }

        /// <summary>
        ///处理状态
        /// </summary>
        public string dealStatus { get; set; }

        /// <summary>
        ///包体标志
        /// </summary>
        public string bodyFlag { get; set; }



        /// <summary>
        ///错误码
        /// </summary>
        public string exception { get; set; }




        /// <summary>
        ///商户退款交易流水号
        /// </summary>
        public string mRefundSeq { get; set; }




        /// <summary>
        ///币种
        /// </summary>
        public string curCode { get; set; }


        /// <summary>
        ///退款金额
        /// </summary>

        public string refundAmount { get; set; }


        /// <summary>
        ///商户订单号
        /// </summary>
        public string orderNo { get; set; }



        /// <summary>
        ///银行订单流水号
        /// </summary>
        public string orderSeq { get; set; }

        /// <summary>
        ///订单金额
        /// </summary>
        public string orderAmount { get; set; }

        /// <summary>
        ///银行交易流水号
        /// </summary>
        public string bankTranSeq { get; set; }


        /// <summary>
        ///银行交易时间
        /// </summary>
        public string tranTime { get; set; }


        /// <summary>
        ///银联订单号
        /// </summary>
        public string unionPaySeq { get; set; }


        /// <summary>
        ///中行签名数据
        /// </summary>
        public string signData { get; set; }


    }
}
