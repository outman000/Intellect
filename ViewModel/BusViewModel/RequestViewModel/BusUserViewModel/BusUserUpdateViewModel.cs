using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusUserUpdateViewModel
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
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
        /// 缴费状态-是否缴费
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? updateDate { get; set; }

    }
}
