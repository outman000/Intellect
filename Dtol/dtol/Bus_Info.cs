using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dtol.dtol
{
    public class Bus_Info
    {
        /// <summary>
        /// 班车id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 车辆设备号
        /// </summary>
        public string deviceNumber { get; set; }
        /// <summary>
        /// 司机姓名
        /// </summary>
        public string DriverName { get; set; }
        /// <summary>
        /// 司机手机
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 车辆标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 车牌
        /// </summary>
        public string CarPlate { get; set; }
        /// <summary>
        /// 状态  0-启用 1-禁用
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 车座数量
        /// </summary>
        public string SeatNum { get; set; }
        /// <summary>
        /// 车辆所属公司
        /// </summary>
        public string OwnedCompany { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }
        /// <summary>
        /// 线路Id   ---外键
        /// </summary>
        public int? Bus_LineId { get; set; }

        public Bus_Line Bus_Line { get; set; }
    }
}
