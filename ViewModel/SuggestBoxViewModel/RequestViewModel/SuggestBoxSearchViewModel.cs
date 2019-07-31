using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SuggestBoxViewModel.RequestViewModel
{
    /// <summary>
    /// 意见箱表单信息查询
    /// </summary>
    public class SuggestBoxSearchViewModel
    {
        /// <summary>
        /// 意见箱表单标题
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 意见箱表单分类
        /// </summary>
        public string SuggestType { get; set; }

        /// <summary>
        /// 意见表单填写时间
        /// </summary>
        public DateTime? SuggestDate { get; set; }
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
