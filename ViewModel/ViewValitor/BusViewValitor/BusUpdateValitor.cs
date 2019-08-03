using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace ViewModel.ViewValitor.BusViewValitor
{
    public class BusUpdateValitor : AbstractValidator<BusUpdateViewModel>
    {
        public BusUpdateValitor()
        {
            RuleFor(hr_info => hr_info.DriverName).NotNull()
                .WithMessage("司机姓名不能为空")
                .Matches("[\u4e00-\u9fa5]")
                .WithMessage("司机姓名必须为中文")
            ;

            RuleFor(hr_info => hr_info.Code).NotNull()
                .WithMessage("班车标识不能为空")
                  .Matches("[a-zA-Z]")
                  .WithMessage("班车标识必须为英文，不可以包含特殊符号")
                  ;

            RuleFor(hr_info => hr_info.CarPlate).NotNull()
                    .WithMessage("车牌不能为空")
                   .Length(6)
                    .WithMessage("车牌为6位");

            RuleFor(hr_info => hr_info.phone).NotNull()
                   .WithMessage("司机手机号不能为空")
                  .Length(11)
                  .WithMessage("手机号码长度必须为11位");
            RuleFor(hr_info => hr_info.SeatNum).NotNull()
                  .WithMessage("座位数不能为空")
                  .Matches("^[0-9]{1,}$")
                 .WithMessage("座位数必须为数字");
            RuleFor(hr_info => hr_info.status).NotNull()
                 .WithMessage("状态数不能为空")
                 .Matches("^[0-9]$")
                .WithMessage("状态数必须为数字");
            RuleFor(hr_info => hr_info.OwnedCompany).NotNull()
               .WithMessage("公司不能为空")
               .Matches("[\u4e00-\u9fa5]")
                 .WithMessage("公司姓名必须为中文");

        }
    }
}
