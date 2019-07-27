using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowNodeSearchViewModel
    {


        /// <summary>
        /// 当前流程id
        /// </summary>
        public int? Flow_ProcedureId { get; set; }

        /// <summary>
        /// 表单id
        /// </summary>
        public int? Repair_InfoId { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        public string operate { get; set; }

        /// <summary>
        /// 当前节点操作人员
        /// </summary>
        public int? User_InfoId { get; set; }


        /// <summary>
        /// 是否删除
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        FlowNodeSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
