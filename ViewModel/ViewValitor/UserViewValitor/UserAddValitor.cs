﻿using FluentValidation;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
    public class UserAddValitor : AbstractValidator<UserAddViewModel>
    {
        public UserAddValitor()
        {
            //RuleFor(hr_info => hr_info.UserName).NotNull()
            //      .WithMessage("用户姓名不能为空")
            //      .Matches("[\u4e00-\u9fa5]")
            //      .WithMessage("用户姓名必须为中文")
            //  ;

            //RuleFor(hr_info => hr_info.UserId).NotNull()
            //    .WithMessage("用户登录账号不能为空")
            //      .Matches("[a-zA-Z]")
            //      .WithMessage("登录账号必须为英文，不可以包含特殊符号")
            //      ;

            //RuleFor(hr_info => hr_info.UserPwd).NotNull()
            //        .WithMessage("用户密码不能为空")
            //       .Length(6, 12)
            //        .WithMessage("密码必须长度必须在6到12位之间");

            //RuleFor(hr_info => hr_info.PhoneCall).NotNull()
            //       .WithMessage("用户登录账号不能为空")
            //      .Must(phoneCall=>phoneCall.Length== 11)
            //      .WithMessage("手机号码长度必须为11位");


            //RuleFor(hr_info => hr_info.Email).NotNull()
            //       .WithMessage("邮箱不能为空")
            //       .EmailAddress()
            //       .When(m => !string.IsNullOrWhiteSpace(m.Email)).WithMessage("邮箱格式不正确");

            //RuleFor(hr_info => hr_info.Levels).NotNull()
            //                 .WithMessage("用户类别不能为空");

            //RuleFor(hr_info => hr_info.status).NotNull()
            //                 .WithMessage("账号状态不能为空");

            //RuleFor(hr_info => hr_info.WorkExperience).NotNull()
            //              .WithMessage("用户身份名称不能为空");


            //RuleFor(hr_info => hr_info.AddDate).NotNull()
            //    .WithMessage("上传时间不能为空")
            //    ;
        }

    }
}
