using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class RepairInfoSearchViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 部门名
        /// </summary>
        public string Name{ get; set; }
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
        /// 报修时间
        /// </summary>
        public DateTime? repairsDate { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 报修状态
        /// </summary>
        public string isHandler { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        RepairInfoSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
