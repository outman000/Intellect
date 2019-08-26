using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class NodeEndSearchViewModel
    {
        /// <summary>
        /// 当前节点操作人员
        /// </summary>
        public int User_InfoId { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        NodeEndSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
