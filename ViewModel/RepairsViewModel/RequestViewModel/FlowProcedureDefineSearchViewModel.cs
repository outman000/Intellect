using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowProcedureDefineSearchViewModel
    {
        /// <summary>
        /// 流程名
        /// </summary>
        public string ProcedureName { get; set; }
        /// <summary>
        /// 流程标识
        /// </summary>
        public string ProcedureCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 流程类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        FlowProcedureDefineSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
