using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.RequestViewModel;

namespace ViewModel.ViewValitor.BulletinBoardViewValitor
{
    public class BulletinBoardAddValitor : AbstractValidator<BulletinBoardAddViewModel>
    {
        public BulletinBoardAddValitor()
        {
            RuleFor(hr_info => hr_info.StayNum).NotNull()
                  .WithMessage("停留小时不能为空")
                  .Matches("^[0-9]{1,}$")
                  .WithMessage("停留小时必须为数字")
              ;

            RuleFor(hr_info => hr_info.BulletinTitle).NotNull()
                 .WithMessage("公告标题不能为空")
               
             ;
            RuleFor(hr_info => hr_info.UserName).NotNull()
              .WithMessage("发布人不能为空")

          ;
            RuleFor(hr_info => hr_info.User_InfoId).NotNull()
            .WithMessage("发布人Id不能为空")

        ;
        }
    }
}
