using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    /// <summary>
    /// 添加缴费人员信息视图模型
    /// </summary>
    public  class BusUserAddViewModel
    {

        /// <summary>
        /// 站点名
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 线路名
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 用户照片
        /// </summary>
        public string Userpicture { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string DepartName { get; set; }

        /// <summary>
        /// 班车名
        /// </summary>
        public string BusName { get; set; }

        /// <summary>
        /// 缴费状态-是否缴费
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime? createDate { get; set; }

    }
}
