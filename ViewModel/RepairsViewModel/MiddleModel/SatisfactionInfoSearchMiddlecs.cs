using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class SatisfactionInfoSearchMiddlecs
    {
        /// <summary>
        /// 意见id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 拟稿人姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 拟稿人部门
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表单外键id
        /// </summary>
        public int Repair_InfoId { get; set; }

        /// <summary>
        /// 表单标题
        /// </summary>
        public string RepairsTitle { get; set; }

        /// <summary>
        /// 满意程度 0，1，2
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// 意见内容
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
