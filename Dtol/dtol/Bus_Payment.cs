using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Bus_Payment
    {
        /// <summary>
        /// 主键id
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
        /// 更新码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 更新码的时间
        /// </summary>
        public DateTime? UpdateCodeDate { get; set; }


        /// <summary>
        /// 扫码的时间
        /// </summary>
        public DateTime? ScanCodeDate { get; set; }


        /// <summary>
        /// 用户照片
        /// </summary>
        public string Userpicture { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string Name{ get; set; }

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
        public Repair_Info Repair_Info { get; set; }

        /// <summary>
        /// 订单id-----外键
        /// </summary>
        public int? Bus_Payment_OrderId { get; set; }
        public Bus_Payment_Order Bus_Payment_Order { get; set; }

        /// <summary>
        /// 乘车时间
        /// </summary>
        public DateTime? carDate { get; set; }

        /// <summary>
        /// 创建缴费时间
        /// </summary>
        public DateTime? createDate{ get; set; }

        /// <summary>
        /// 修改缴费时间
        /// </summary>
        public DateTime? updateDate { get; set; }


    }
}
