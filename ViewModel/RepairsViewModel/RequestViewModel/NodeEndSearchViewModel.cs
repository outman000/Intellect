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
        /// 表单类型（1-报修类型，2-意见类型，3-班车缴费类型）
        /// </summary>
        public string isHandler { get; set; }

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
