using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class NextNodeByCurrentNodeSearchViewModel
    {
        /// <summary>
        /// 当前节点id
        /// </summary>

        public int Flow_NodeDefineId { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public NextNodeByCurrentNodeSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
