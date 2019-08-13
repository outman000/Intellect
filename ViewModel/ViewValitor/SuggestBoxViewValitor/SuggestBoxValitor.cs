using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SuggestBoxViewModel.RequestViewModel;

namespace ViewModel.ViewValitor.SuggestBoxViewValitor
{
    public class SuggestBoxValitor : AbstractValidator<SuggestBoxAddViewModel>
    {
        public SuggestBoxValitor()
        {
            //RuleFor(hr_info => hr_info.Title).NotNull()
            //      .WithMessage("意见箱表单标题不能为空")
            //      .Matches("[\u4e00-\u9fa5]")
            //      .WithMessage("意见箱表单标题必须为中文")
            //  ;
           
        }
    }
}
