using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.ViewValitor.PublicViewValitor
{

    public class PageViewValitor : AbstractValidator<PageViewModel>
    {

        public PageViewValitor()
        {
            RuleFor(page => page.PageSize).NotNull()
                .WithMessage("篇幅不能为空")
                . GreaterThan(0)
                .WithMessage("篇幅必须大于0")
            ;


        }
    }
}
