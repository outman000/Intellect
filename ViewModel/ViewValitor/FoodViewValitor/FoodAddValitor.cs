using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.RequestViewModel;

namespace ViewModel.ViewValitor.FoodViewValitor
{
    public class FoodAddValitor : AbstractValidator<FoodInfoAddViewModel>
    {
        public FoodAddValitor()
        {
            //RuleFor(hr_info => hr_info.FoodName).NotNull()
            //      .WithMessage("菜名不能为空")
            //      .Matches("[\u4e00-\u9fa5]")
            //      .WithMessage("菜名必须为中文")
            //  ;
           
            //RuleFor(hr_info => hr_info.Code).NotNull()
            //     .WithMessage("菜名标识不能为空")
            //     .Matches("[a-zA-Z]")
            //     .WithMessage("菜名标识必须为英文")
            // ;
          
        }
    }
}
