﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public partial class LoginViewModel: BaseViewModel
    {
      
        [Required(ErrorMessage = "账号不能为空")]
        [DisplayName("账户")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "密码长度应介于6-12个字符之间")]
        [DisplayName("密码")]
        public String Password { get; set; }

        public BaseViewModel baseViewModel; 
    }
}