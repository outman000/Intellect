using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.OpinionInfoViewModel.RequestViewModel
{
    public class OpinionInfoSearchViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 意见箱表单id
        /// </summary>
        public int? Suggest_BoxId { get; set; }

        /// <summary>
        /// 节点名
        /// </summary>
        public string FlowNodeName { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }


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
        OpinionInfoSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
