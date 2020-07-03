using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class Bus_Scan_RecordAddViewModel
    {

        /// <summary>
        /// 班车设备号
        /// </summary>
        public string deviceNumber { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 线路名
        /// </summary>

        public string LineName { get; set; }

        /// <summary>
        /// 线路主键id
        /// </summary>

        public int LineId { get; set; }



        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime AddDate { get; set; }
    }
}
