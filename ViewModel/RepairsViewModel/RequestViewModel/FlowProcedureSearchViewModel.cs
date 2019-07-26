using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    /// <summary>
    /// 流程查询视图
    /// </summary>
    /// 
    public class FlowProcedureSearchViewModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Starttime { get; set; }
 
        /// <summary>
        /// 描述
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        FlowProcedureSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
