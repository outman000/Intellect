using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel
{
    /// <summary>
    /// 站点信息查询
    /// </summary>
    public class StationSearchViewModel
    {
       
        /// <summary>
        /// 站点名称
        /// </summary>
        public string StationName { get; set; }
        /// <summary>
        /// 站点状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 站点标识
        /// </summary>
        public string Code { get; set; }
        ///// <summary>
        ///// 站点费用
        ///// </summary>
        //public decimal? Expense { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        StationSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
