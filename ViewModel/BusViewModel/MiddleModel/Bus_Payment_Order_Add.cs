using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
   public class Bus_Payment_Order_Add
    {

        /// <summary>
        /// 订单币种
        /// </summary>
        public string curCode { get; set; }


        /// <summary>
        /// 支付类型
        /// </summary>
        public string payType { get; set; }



        /// <summary>
        ///设备号
        /// </summary>
        public string deviceInfo { get; set; }



        /// <summary>
        ///交易终端类型
        /// </summary>
        public string terminalChnl { get; set; }



        /// <summary>
        ///交易类型
        /// </summary>
        public string tradeType { get; set; }



        /// <summary>
        ///商户号
        /// </summary>
        public string merchantNo { get; set; }

    }
}
