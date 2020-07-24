using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusOrderSearchViewModel
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
        /// 支付标识
        /// </summary>
        public string paymentStatus { get; set; }


        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        BusOrderSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
