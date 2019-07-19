using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel
{
    /// <summary>
    /// 班车线路信息查询
    /// </summary>
    public class LineSearchViewModel
    {

        /// <summary>
        /// 线路id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 状态 0-启用  1-禁用
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 线路标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 线路描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        LineSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
