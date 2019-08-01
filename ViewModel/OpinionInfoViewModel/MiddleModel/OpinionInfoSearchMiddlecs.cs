using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.OpinionInfoViewModel.MiddleModel
{
    public class OpinionInfoSearchMiddlecs
    {
        /// <summary>
        /// 意见id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? User_InfoId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }



        /// <summary>
        /// 意见箱表单id
        /// </summary>
        public int? Suggest_BoxId { get; set; }
    


        /// <summary>
        /// 节点id
        /// </summary>
        public int? Flow_NodeDefineId { get; set; }

        /// <summary>
        /// 节点名
        /// </summary>
        public string NodeName { get; set; } 


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
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }

    }
}
