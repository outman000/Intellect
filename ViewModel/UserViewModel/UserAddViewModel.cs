using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel.UserViewModel
{
    public partial class UserAddViewModel
    {

        [Required(ErrorMessage = "账号不能为空")]
        [DisplayName("账户")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "密码长度应介于6-12个字符之间")]
        [DisplayName("密码")]
        public String Password { get; set; }
        [Required(ErrorMessage = "手机号码不能为空")]
        [StringLength(11, MinimumLength =11, ErrorMessage = "手机号码长度应为11位")]
        [DisplayName("手机号码")]
        public string PhoneCall { get; set; }


        //角色 
        //部门  public String User_Depart

    }
}
