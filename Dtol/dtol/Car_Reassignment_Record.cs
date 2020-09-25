using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Car_Reassignment_Record
    {
        /// <summary>
        /// 改派记录ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 乘车人手机号
        /// </summary>
        public string Riderphone { get; set; }
        /// <summary>
        /// 用车事由
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 上车地点
        /// </summary>
        public string PickUpLocation { get; set; }

        /// <summary>
        /// 下车地点
        /// </summary>
        public string GetOffLocation { get; set; }

        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime? Docdate { get; set; }

        /// <summary>
        /// 改派前车牌号
        /// </summary>
        public string BeforeCxry { get; set; }
        /// <summary>
        /// 改派前司机姓名
        /// </summary>
        public string BeforeDriverName { get; set; }

        /// <summary>
        /// 改派前司机手机
        /// </summary>
        public string Beforephone { get; set; }
        /// <summary>
        /// 改派后车牌号
        /// </summary>
        public string AfterCxry { get; set; }
        /// <summary>
        /// 改派后司机姓名
        /// </summary>
        public string AfterDriverName { get; set; }
        /// <summary>
        /// 改派后司机手机
        /// </summary>
        public string Afterphone { get; set; }
        /// <summary>
        /// 状态 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 改派时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 删除标识  0-启用 1-禁用
        /// </summary>
        public string isdelete { get; set; }
    }
}
