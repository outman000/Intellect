using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
    public   class UserRoleValitor : AbstractValidator<UserRoleAddViewModel>
    {
        public UserRoleValitor()
        {
            RuleFor(role=>role.RoleName).NotNull()
                  .WithMessage("角色名称不能为空")
                  .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("角色名称必须为中文")
              ;
            RuleFor(role => role.RoleCode).NotNull()
                  .WithMessage("角色标识不能为空")
                  .Matches("[a-zA-Z]")
                  .WithMessage("角色标识必须为英文")
              ;
            RuleFor(role => role.Createdate).NotNull()
                  .WithMessage("添加时间不能为空")
              ;

        }
    }
}
