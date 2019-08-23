using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.RequestViewModel
{
    public class FlowNodeDefineSearchViewModel
    {

        /// <summary>
        /// 主键
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 节点名
        /// </summary>
        public string NodeName { get; set; }


        /// <summary>
        /// 流程id
        /// </summary>
        public int? Flow_ProcedureDefineId { get; set; }

        /// <summary>
        /// 流程名
        /// </summary>
        public string ProcedureName { get; set; }


        /// <summary>
        /// 节点类型
        /// </summary>

        public string NodeType { get; set; }

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
        public FlowNodeDefineSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }

    }
}
