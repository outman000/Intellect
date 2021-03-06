﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.WeChatViewModel.RequestViewModel
{
    public class LoginUpdateViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewUserPwd { get; set; }
    }
}
