using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class BusUserSearchMiddlecs
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 线路名
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 表单id-----外键
        /// </summary>
        public int? Repair_InfoId { get; set; }
        /// <summary>
        /// 站点名
        /// </summary>
        public string StationName { get; set; }
        /// <summary>
        /// 站点费用
        /// </summary>
        public string Expense { get; set; }

        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime? carDate { get; set; }

        /// <summary>
        /// 缴费状态-是否缴费
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 用户照片
        /// </summary>
        public string Userpicture { get; set; }
    }
}
