using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.StationInfoViewModel;

namespace ViewModel.ViewValitor.BusViewValitor
{
    public class StationUpdateValitor : AbstractValidator<StationUpdateViewModel>
    {
        public StationUpdateValitor()
        {
            RuleFor(hr_info => hr_info.StationName).NotNull()
                            .WithMessage("站点名称不能为空")
                            .Matches("[\u4e00-\u9fa5]")
                            .WithMessage("站点名称必须为中文")
                        ;
            RuleFor(hr_info => hr_info.status).NotNull()
                 .WithMessage("状态不能为空")
                    .Matches("^[0-9]*$")
                 .WithMessage("状态必须为数字")
             ;
            RuleFor(hr_info => hr_info.Code).NotNull()
               .WithMessage("站点标识不能为空")
               .Matches("[a-zA-Z]")
               .WithMessage("站点标识必须为英文，不可以包含特殊符号")
                 ;

        }
    }
}
