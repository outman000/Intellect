using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
    public  class RightsRepeatValitor : AbstractValidator<RightsValideRepeat>
    {
        public RightsRepeatValitor()
        {
            RuleFor(u => u.RightsValue).NotNull()
                  .WithMessage("权限不能为空")
              ;
        }
    }
}
