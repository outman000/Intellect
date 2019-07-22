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
        /// 站点id
        /// </summary>
        public int? Bus_StationId { get; set; }
        /// <summary>
        /// 线路id
        /// </summary>
        public int? Bus_LineId { get; set; }
        /// <summary>
        /// 人员id
        /// </summary>
        public int? User_InfoId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime? createDate { get; set; }

    }
}
