using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SuggestBoxViewModel.RequestViewModel
{
    public class SuggestBoxAddViewModel
    {
     

        /// <summary>
        /// 建议增加的菜名
        /// </summary>
        public string Content { get; set; }

 
        /// <summary>
        /// 删除标识
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int User_InfoId { get; set; }


        /// <summary>
        /// 意见填写时间
        /// </summary>
        public DateTime? SuggestDate { get; set; }

    }
}
