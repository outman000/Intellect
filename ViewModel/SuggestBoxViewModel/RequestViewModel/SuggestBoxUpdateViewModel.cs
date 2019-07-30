using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SuggestBoxViewModel.RequestViewModel
{

    /// <summary>
    /// 意见箱表单修改视图
    /// </summary>
    public class SuggestBoxUpdateViewModel
    {
        /// <summary>
        ///主键id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 意见箱表单标题
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// 意见箱表单分类
        /// </summary>
        public string SuggestType { get; set; }

        /// <summary>
        /// 意见箱表单内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 意见箱表单附件内容
        /// </summary>
        public string AnnexFile { get; set; }



        /// <summary>
        /// 意见表单修改时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 意见箱表单匿名内容(两类：“匿名” 或者 用户真实姓名)
        /// </summary>
        public string Anonymous { get; set; }


        /// <summary>
        /// 删除标识
        /// </summary>
        public string status { get; set; }
    }
}
