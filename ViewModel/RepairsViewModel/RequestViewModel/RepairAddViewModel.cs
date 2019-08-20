using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    /// <summary>
    /// 报修表单增加视图
    /// </summary>
    /// 
    public class RepairAddViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int User_InfoId { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int User_DepartId { get; set; }

        /// <summary>
        /// 报修标题  (意见箱的标题)
        /// </summary>
        public string RepairsTitle { get; set; }
        /// <summary>
        /// 报修类型（意见箱的类型）
        /// </summary>
        public string RepairsType { get; set; }
        /// <summary>
        /// 紧急情况( 意见箱是否匿名)
        /// </summary>
        public string RepairsEmergency { get; set; }
        /// <summary>
        /// 报修内容( 意见箱内容)
        /// </summary>
        public string RepairsContent { get; set; }
        /// <summary>
        /// 报修时间(意见箱填写时间)
        /// </summary>
        public DateTime? repairsDate { get; set; }

        /// <summary>
        /// 报修地址(联系地址)
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
        /// 表单类型（1-报修类型，2-意见类型，3-班车类型）
        /// </summary>
        public string isHandler { get; set; }

        /// <summary>
        /// 流程定义主键Id
        /// </summary>
        public int Flow_ProcedureDefineId { get; set; }
    }
}
