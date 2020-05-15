using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    /// <summary>
    /// 流程信息视图模型
    /// </summary>
    public class FlowNodeSearchViewModel
    {


        /// <summary>
        /// 当前流程id(此属性可以为空)
        /// </summary>
        public int? Flow_ProcedureId { get; set; }

        /// <summary>
        /// 表单id(此属性可以为空)
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
        /// 表单类型（1-报修类型，2-意见类型,3-班车类型）
        /// </summary>
        public string isHandler { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public FlowNodeSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
