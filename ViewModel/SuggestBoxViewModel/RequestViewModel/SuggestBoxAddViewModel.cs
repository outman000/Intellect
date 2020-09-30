using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SuggestBoxViewModel.RequestViewModel
{
    public class SuggestBoxAddViewModel
    {
     

        /// <summary>
        /// 具体意见内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 意见箱表单分类
        /// </summary>
        public string SuggestType { get; set; }


        /// <summary>
        /// 用户id
        /// </summary>
        public int User_InfoId { get; set; }




    }
}
