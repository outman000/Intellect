using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.OpinionInfoViewModel.RequestViewModel
{
    public class OpinionInfoAddViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int? User_InfoId { get; set; }


        /// <summary>
        /// 意见箱表单id
        /// </summary>
        public int? Suggest_BoxId { get; set; }

        /// <summary>
        /// 节点id
        /// </summary>
        public int? Flow_NodeDefineId { get; set; }


        /// <summary>
        /// 意见内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

    
    }
}
