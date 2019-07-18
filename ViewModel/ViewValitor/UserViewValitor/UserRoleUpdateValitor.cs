using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
    public class UserRoleUpdateValitor : AbstractValidator<UserRoleUpdateViewModel>
    {
        public UserRoleUpdateValitor()
        {
            RuleFor(role => role.Status).NotNull()
                  .WithMessage("角色名称状态不嫩为空")
                  .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("角色名称必须为中文")
              ;
            RuleFor(role => role.RoleName).NotNull()
                  .WithMessage("角色名称不能为空")
                  .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("角色名称必须为中文")
              ;
            RuleFor(role => role.UpdateTime).NotNull()
                  .WithMessage("添加时间不能为空")
              ;

        }
    }
}
