using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace ViewModel.ViewValitor.RepairsViewValitor
{
    public class ProcedureAddValitor : AbstractValidator<FlowProcedureDefineAddViewModel>
    {
        public ProcedureAddValitor()
        {
            RuleFor(hr_info => hr_info.ProcedureName).NotNull()
                 .WithMessage("流程名不能为空")
                  .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("流程名必须为中文");
            RuleFor(hr_info => hr_info.ProcedureCode).NotNull()
                 .WithMessage("流程标识不能为空")
                   .Matches("[a-zA-Z]")
                  .WithMessage("流程标识必须为英文");

            RuleFor(hr_info => hr_info.Type).NotNull()
                 .WithMessage("流程类型不能为空")
                  .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("流程类型必须为中文");
        }
    }
}
