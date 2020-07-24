using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusUserSearch2ViewModel
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }
        /// <summary>
        /// 站点名
        /// </summary>
        public string Bus_StationName { get; set; }
        /// <summary>
        /// 线路名
        /// </summary>
        public int? Bus_LineId { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string User_DepartName { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public string Expense { get; set; }
        /// <summary>
        /// 缴费状态-是否缴费
        /// </summary>
        public string status { get; set; }


        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime? carDate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        BusUserSearch2ViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
