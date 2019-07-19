using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace ViewModel.ViewValitor.BusViewValitor
{
   public class LineUpdateValitor : AbstractValidator<LineUpdateViewModel>

    {
        public LineUpdateValitor()
        {
            RuleFor(hr_info => hr_info.LineName).NotNull()
                             .WithMessage("线路名不能为空")
                             .Matches("[\u4e00-\u9fa5]")
                             .WithMessage("线路名必须为中文")
                         ;
            RuleFor(hr_info => hr_info.status).NotNull()
                 .WithMessage("状态不能为空")
                    .Matches("^[0-9]*$")
                 .WithMessage("状态必须为数字")
             ;
            RuleFor(hr_info => hr_info.Code).NotNull()
               .WithMessage("线路标识不能为空")
               .Matches("[a-zA-Z]")
               .WithMessage("线路标识必须为英文，不可以包含特殊符号")
                 ;

        }
    }
}
