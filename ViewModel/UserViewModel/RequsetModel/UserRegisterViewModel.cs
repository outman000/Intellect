using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public class UserRegisterViewModel
    {
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserName { get; set; }
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

        /// <summary>
        /// 部门名
        /// </summary>
        public string Dept { get; set; }
        public int? User_DepartId { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idcard { get; set; }

    }
}
