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
        public String  UserName { get; set; }

        /// <summary>
        /// 站点id
        /// </summary>
        public String Bus_StationId { get; set; }
        /// <summary>
        /// 线路id
        /// </summary>
        public String Bus_LineId { get; set; }
        /// <summary>
        /// 人员id
        /// </summary>
        public String User_InfoId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public String User_DepartId { get; set; }
        /// <summary>
        /// 班车Id  
        /// </summary>
        public String Bus_InfoId { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public String Expense { get; set; }
        /// <summary>
        /// 缴费状态-是否缴费
        /// </summary>
        public string status { get; set; }
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
