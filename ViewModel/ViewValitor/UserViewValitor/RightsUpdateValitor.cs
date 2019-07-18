using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
   public class RightsUpdateValitor : AbstractValidator<RightsUpdateViewModel>
    {
        public RightsUpdateValitor()
        {

            RuleFor(hr_info => hr_info.RightsName).NotNull()
                  .WithMessage("权限名称不能为空")
                    .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("权限必须为中文")
              ;
            RuleFor(hr_info => hr_info.RightsValue).NotNull()
            .WithMessage("权限id不能为空")
             .Matches("[a-zA-Z]")
                  .WithMessage("权限id，不可以包含特殊符号")
        ;


            RuleFor(hr_info => hr_info.ParentId).NotNull()
                                 .WithMessage("权限所属不能为空");

            ;
            RuleFor(hr_info => hr_info.Type).NotNull()
                         .WithMessage("权限类型不能为空");

            ;

            RuleFor(hr_info => hr_info.Url).NotNull()
                                    .WithMessage("权限url地址不能为空");

            ;
        }
        
    }
}
