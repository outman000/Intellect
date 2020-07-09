using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel
 {    
    
       /// <summary>
       /// 班车增加视图
       /// </summary>
       /// 
    public class BusAddViewModel
    { 
        
        /// <summary>
        /// 司机姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 车辆设备号
        /// </summary>
        public string deviceNumber { get; set; }
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
      
    }
}
