using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SuggestBoxViewModel.RequestViewModel
{
    /// <summary>
    /// 建议增加菜名信息查询
    /// </summary>
    public class SuggestBoxSearchViewModel
    {
        
        /// <summary>
        /// 建议增加的菜名
        /// </summary>
        public string Content { get; set; }

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
