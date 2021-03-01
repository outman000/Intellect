using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SuggestBoxViewModel.MiddleModel
{
    public class SuggestInfoMiddlecs
    {
        /// <summary>
        ///  id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 具体意见内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 意见表单填写时间
        /// </summary>
        public DateTime? SuggestDate { get; set; }

        /// <summary>
        /// 意见箱表单分类
        /// </summary>
        public string SuggestType { get; set; }
        /// <summary>
        /// 意见箱表单子分类
        /// </summary>
        public string SuggestChildenType { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        public string Name { get; set; }
    }
}
