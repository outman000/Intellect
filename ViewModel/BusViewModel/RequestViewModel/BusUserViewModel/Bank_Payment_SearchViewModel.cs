using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel
{
    public class Bank_Payment_SearchViewModel
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string merchantNo { get; set; }


        /// <summary>
        /// 商户订单号字符串
        /// </summary>

        public string orderNos { get; set; }


        ///// <summary>
        ///// 商户签名信息
        ///// </summary>

        //public string signData { get; set; }

    }
}
