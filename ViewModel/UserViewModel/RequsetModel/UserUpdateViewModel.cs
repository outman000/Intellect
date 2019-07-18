using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    public partial class UserUpdateViewModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户密码
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
        /// 状态 0-未删除   1-删除
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Levels { get; set; }
        /// <summary>
        /// 工作经验
        /// </summary>
        public string WorkExperience { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
