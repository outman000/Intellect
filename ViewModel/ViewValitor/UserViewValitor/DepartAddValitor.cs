﻿
using FluentValidation;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
    public class DepartAddValitor : AbstractValidator<DepartAddViewModel>
    {
        public DepartAddValitor()
        {
            RuleFor(hr_info => hr_info.Name).NotNull()
                  .WithMessage("部门名称不能为空")
                  .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("部门名称必须为中文")
              ;
            RuleFor(hr_info => hr_info.Code).NotNull()
                 .WithMessage("部门id不能为空")
                      .Matches("[a-zA-Z]")
                  .WithMessage("部门id必须为英文")
             ;
            RuleFor(hr_info => hr_info.Sort).NotNull()
                 .WithMessage("部门名称排序")
             ;
            RuleFor(hr_info => hr_info.ParentId).NotNull()
                             .WithMessage("部门所属不能为空,最大为0");

            ;
        }

    }
}
