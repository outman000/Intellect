using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{

    /// <summary>
    /// 用户增加视图
    /// </summary>
    public partial class UserAddViewModel
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
        /// 状态0启用1停用
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 身份0普通身份1临时身份
        /// </summary>
        public string Levels { get; set; }
        /// <summary>
        /// 身份名称
        /// </summary>
        public string WorkExperience { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idcard { get; set; }

        ///// <summary>
        ///// 头像存储路径
        ///// </summary>
        //public string ImgName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }

    }
}
