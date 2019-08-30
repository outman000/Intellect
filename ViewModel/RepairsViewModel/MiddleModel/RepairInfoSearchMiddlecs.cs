using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.MiddleModel
{
    public class RepairInfoSearchMiddlecs
    {
        /// <summary>
        /// 报修id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary>
        /// 部门名
        /// </summary>
        public string Name { get; set; }
      
        /// <summary>
        /// 报修标题
        /// </summary>
        public string RepairsTitle { get; set; }
        /// <summary>
        /// 报修类型
        /// </summary>
        public string RepairsType { get; set; }
        /// <summary>
        /// 紧急情况
        /// </summary>
        public string RepairsEmergency { get; set; }
        /// <summary>
        /// 报修内容
        /// </summary>
        public string RepairsContent { get; set; }
        /// <summary>
        /// 报修时间
        /// </summary>
        public DateTime? repairsDate { get; set; }

        /// <summary>
        /// 报修地址
        /// </summary>
        public string RepairsAdress { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 表单类型  1-报修，2-意见，3-班车缴费
        /// </summary>
        public string isHandler { get; set; }
    }
}
