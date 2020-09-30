using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.MiddleModel
{
    public class UserRegisterMiddle
    {

        /// <summary>
        /// 用户登录账号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneCall { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

    }
}
