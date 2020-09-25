using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Integral_Log
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Idcard { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int? User_DepartId { get; set; }
        public string Dept { get; set; }
        public string Mobile { get; set; }
        public string Type { get; set; }
        public string Points { get; set; }

        public string PointsLocation { get; set; }

        /// <summary>
        /// 设备码
        /// </summary>
        public string sn { get; set; }

        public string status { get; set; }
        

        public string IsDelete { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string createUser { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

    }
}
