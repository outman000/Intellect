using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class ReminderInfoAddViewModel
    {
      
        /// <summary>
        /// 用户id
        /// </summary>
        public int User_InfoId { get; set; }

        /// <summary>
        /// 表单外键id
        /// </summary>
        public int Repair_InfoId { get; set; }

        /// <summary>
        /// 催单内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 备用
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
