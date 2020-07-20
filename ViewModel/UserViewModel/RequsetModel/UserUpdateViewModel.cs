using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 用户更新视图
    /// </summary>
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
        /// 身份证号
        /// </summary>
        public string Idcard { get; set; }

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

        ///// <summary>
        ///// 头像姓名
        ///// </summary>
        //public string Files { get; set; }

        ///// <summary>
        ///// 上传头像文件
        ///// </summary>
        //[Required]
        //[Display(Name = "身份证附件")]
        //[FileExtensions(Extensions = ".jpg,.png", ErrorMessage = "图片格式错误")]
        //public IFormFile formFile { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateDate { get; set; }
    }
}
