using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.OpinionInfoViewModel.RequestViewModel
{
    public class OpinionInfoUpdateViewModel
    {
        /// <summary>
        ///主键id
        /// </summary>
        public int Id { get; set; }

        // <summary>
        /// 意见内容
        /// </summary>
        public string content { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }
    }
}
