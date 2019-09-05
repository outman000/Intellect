using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.WeChatViewModel.ResponseModel
{
    public class WeChatTokenResModel
    {
        /// <summary>
        /// token
        /// </summary>
       public String access_token { get; set; }
       public String expires_in { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
       public String errcode { get; set; }
        /// <summary>
        /// 错误详细信息
        /// </summary>
       public String errmsg { get; set; }
    }
}
