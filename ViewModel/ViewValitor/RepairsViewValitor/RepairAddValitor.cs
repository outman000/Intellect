using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace ViewModel.ViewValitor.RepairsViewValitor
{
    public class RepairAddValitor : AbstractValidator<RepairAddViewModel>
    {
        public RepairAddValitor()
        {
            RuleFor(hr_info => hr_info.RepairsAdress).NotNull()
                 .WithMessage("报修地址不能为空");

            RuleFor(hr_info => hr_info.RepairsContent).NotNull()
                 .WithMessage("报修内容不能为空");

            RuleFor(hr_info => hr_info.RepairsTitle).NotNull()

                 .WithMessage("报修标题不能为空")
                 .Length(20)
                 .WithMessage("报修标题长度不能超过20个字符");

            RuleFor(hr_info => hr_info.RepairsType).NotNull()
                 .WithMessage("报修类型不能为空") ;

            RuleFor(hr_info => hr_info.RepairsEmergency).NotNull()
                 .WithMessage("紧急情况不能为空");

            RuleFor(hr_info => hr_info.telephone).NotNull()
                .WithMessage("联系电话不能为空")
                .Length(11)
                .WithMessage("联系电话长度最长为11位");
        }
    }
}
