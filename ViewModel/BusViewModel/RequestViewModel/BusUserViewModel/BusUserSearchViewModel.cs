using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusUserSearchViewModel
    {

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 站点id
        /// </summary>
        public string Bus_StationId { get; set; }
        /// <summary>
        /// 线路id
        /// </summary>
        public string Bus_LineId { get; set; }
        /// <summary>
        /// 人员id
        /// </summary>
        public string User_InfoId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public string User_DepartId { get; set; }
        /// <summary>
        /// 班车Id  
        /// </summary>
        public string Bus_InfoId { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public string Expense { get; set; }
        /// <summary>
        /// 缴费状态-是否缴费
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 表单id-----外键
        /// </summary>
        public int? Repair_InfoId { get; set; }

        /// <summary>
        /// 订单id-----外键
        /// </summary>
        public int? Bus_Payment_OrderId { get; set; }
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
        BusUserSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
