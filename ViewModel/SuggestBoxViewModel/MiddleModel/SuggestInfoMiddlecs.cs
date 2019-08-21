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
        /// 建议的菜名
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 意见表单填写时间
        /// </summary>
        public DateTime? SuggestDate { get; set; }

        /// <summary>
        /// 意见表单修改时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 部门名
        /// </summary>
        public string Name { get; set; }
    }
}
