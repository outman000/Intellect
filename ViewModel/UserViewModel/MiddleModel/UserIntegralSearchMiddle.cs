using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class UserIntegralSearchMiddle
    {
        public string UserName { get; set; }
        public string Idcard { get; set; }

        public string Dept { get; set; }

        public string Type { get; set; }
        public string TotalPoints { get; set; }
        public string Mobile { get; set; }

        /// <summary>
        /// 工会名称
        /// </summary>
        public string UnionName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }
    }
}
