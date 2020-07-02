using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Bus_Payment_Order
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>

        public string merchantNo { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string payType { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }
        
        /// <summary>
        /// 订单币种
        /// </summary>
        public string curCode { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? PlaceAnOrderDate { get; set; }

        /// <summary>
        ///订单时间
        /// </summary>
        public string orderTime { get; set; }

        /// <summary>
        ///订单说明
        /// </summary>
        public string orderNote { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string body { get; set; }

        /// <summary>
        ///交易终端类型
        /// </summary>
        public string terminalChnl { get; set; }

        /// <summary>
        ///交易类型
        /// </summary>
        public string tradeType { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string deviceInfo { get; set; }

        /// <summary>
        /// 终端ip
        /// </summary>
        public string spbillCreateIp { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string identityType { get; set; }


        /// <summary>
        /// 证件号
        /// </summary>
        public string identityNumb { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string identityName { get; set; }

        

        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? confirmDate { get; set; }






        /// <summary>
        /// 确认标识
        /// </summary>
        public string confirmStatus { get; set; }

        /// <summary>
        /// 支付标识 0-未支付，1-已支付，2-已确认
        /// </summary>
        public string paymentStatus { get; set; }

        /// <summary>
        /// 缴费金额
        /// </summary>
        public string orderAmount { get; set; }
        /// <summary>
        /// 删除状态  0-启用 1-禁用
        /// </summary>
        public string isDelete { get; set; }


        /// <summary>
        /// 公共状态  0-启用 1-禁用
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string departName { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string createUser { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string updateUser { get; set; }


        /// <summary>
        /// 表单id-----外键
        /// </summary>
        public int? Repair_InfoId { get; set; }
        public Repair_Info Repair_Info { get; set; }



    }
}
