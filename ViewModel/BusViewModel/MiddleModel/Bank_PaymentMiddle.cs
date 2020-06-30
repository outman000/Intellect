using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class Bank_PaymentMiddle
    {
        /// <summary>
        ///状态
        /// </summary>
        public string hdlSts { get; set; }

        /// <summary>
        ///支付地址
        /// </summary>
        public string qrCode { get; set; }


        /// <summary>
        ///错误信息
        /// </summary>
        public string rtnMsg { get; set; }
        
    }
}
