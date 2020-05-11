using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class Bus_Payment_OrderSearchViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

     

        /// <summary>
        /// 部门名称
        /// </summary>
        public string departName { get; set; }

        /// <summary>
        /// 确认标识
        /// </summary>
        public string confirmStatus { get; set; }

        /// <summary>
        /// 支付标识
        /// </summary>
        public string paymentStatus { get; set; }


        /// <summary>
        /// 删除状态  0-启用 1-禁用
        /// </summary>
        public string isDelete { get; set; }


        /// <summary>
        /// 公共状态  0-启用 1-禁用
        /// </summary>
        public string status { get; set; }
       
        /// <summary>
        /// 创建人
        /// </summary>
        public string createUser { get; set; }


        /// <summary>
        /// 表单id-----外键
        /// </summary>
        public int? Repair_InfoId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        Bus_Payment_OrderSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
