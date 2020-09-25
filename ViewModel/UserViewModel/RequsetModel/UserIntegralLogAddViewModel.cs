using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserIntegralLogAddViewModel
    {
        public string UserName { get; set; }
        public string Idcard { get; set; }

        public string Dept { get; set; }
        public string Mobile { get; set; }
        public int? User_DepartId { get; set; }
        public string Type { get; set; }
        public string Points { get; set; }
        public string status { get; set; }
        public string PointsLocation { get; set; }
        /// <summary>
        /// 设备码
        /// </summary>
        public string sn { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string createUser { get; set; }

    }
}
