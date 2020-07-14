using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class Bus_PaymentOrderSearchMiddle
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }

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
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Phone { get; set; }



        /// <summary>
        /// 部门名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 站点费用
        /// </summary>
        public string Expense { get; set; }




        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime? carDate { get; set; }

        /// <summary>
        /// 创建缴费时间
        /// </summary>
        public DateTime? createDate { get; set; }

    }
}
