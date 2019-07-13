﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
    public class RightsAddValitor : AbstractValidator<RightsAddViewModel>
    {
        public RightsAddValitor()
        {
            RuleFor(hr_info => hr_info.RightsName).NotNull()
                  .WithMessage("权限名称不能为空")
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
