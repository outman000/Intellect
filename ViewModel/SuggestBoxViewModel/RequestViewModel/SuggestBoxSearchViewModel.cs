using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SuggestBoxViewModel.RequestViewModel
{
    /// <summary>
    /// 意见信息查询
    /// </summary>
    public class SuggestBoxSearchViewModel
    {

        /// <summary>
        /// 意见箱表单分类
        /// </summary>
        public string SuggestType { get; set; }

        /// <summary>
        /// 人名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? strDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        SuggestBoxSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
