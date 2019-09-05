using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class ReminderInfoSearchMiddlecs
    {
        /// <summary>
        /// 催单id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 表单外键id
        /// </summary>
        public int Repair_InfoId { get; set; }

        /// <summary>
        /// 表单标题
        /// </summary>
        public string RepairTitle { get; set; }


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
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }
    }
}
