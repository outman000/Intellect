using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class Bank_PaymentViewModel
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string merchantNo { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>

        public string payType { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 订单币种
        /// </summary>
        public string curCode { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public string orderAmount { get; set; }
        /// <summary>
        /// 订单时间     格式：YYYYMMDDHHMISS 其中时间为24小时格式，例:2010年3月2日下午4点5分28秒表示为20100302160528
        /// </summary>
        public string orderTime { get; set; }
        /// <summary>
        /// 订单说明
        /// </summary>
        public string orderNote { get; set; }
        /// <summary>
        /// 商户接收通知URL
        /// </summary>
        public string orderUrl { get; set; }

        /// <summary>
        /// 交易终端类型
        /// </summary>
        public string terminalChnl { get; set; }

        /// <summary>
        /// 商户签名数据
        /// </summary>
        public string signData { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string tradeType { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string deviceInfo { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// 终端ip
        /// </summary>
        public string spbillCreateIp { get; set; }


    }
}
