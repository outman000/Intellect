using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;

namespace ViewModel.BusViewModel.RequestViewModel.BusUserViewModel
{
    public class BusUserUpdateViewModel
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 缴费状态-是否缴费
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 站点id
        /// </summary>
        public int? Bus_StationId { get; set; }

        /// <summary>
        /// 线路id
        /// </summary>
        public int? Bus_LineId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? User_InfoId { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }


        /// <summary>
        /// 班车Id 
        /// </summary>
        public int? Bus_InfoId { get; set; }


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
        public string Name { get; set; }

        /// <summary>
        /// 班车名
        /// </summary>
        public string BusName { get; set; }

        /// <summary>
        /// 站点费用
        /// </summary>
        public string Expense { get; set; }


        /// <summary>
        /// 表单id-----外键
        /// </summary>
        public int? Repair_InfoId { get; set; }

        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime? carDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? updateDate { get; set; }



    }
}
