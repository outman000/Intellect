using FluentValidation;

using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace ViewModel.ViewValitor.BusViewValitor
{
    public class BusAddValitor : AbstractValidator<BusAddViewModel>
    {
        public BusAddValitor()
        {
            RuleFor(hr_info => hr_info.DriverName).NotNull()
                  .WithMessage("司机姓名不能为空")
                  .Matches("[\u4e00-\u9fa5]")
                  .WithMessage("司机姓名必须为中文")
              ;
            RuleFor(hr_info => hr_info.CarPlate).NotNull()
                 .WithMessage("车牌不能为空")
                // .Matches("^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A - Z]{ 1}[A-Z]{1}[警京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼]{ 0,1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}[黑黄蓝绿]{1}$")
                 .WithMessage("车牌必须符合要求")
             ;
            RuleFor(hr_info => hr_info.OwnedCompany).NotNull()
                 .WithMessage("公司姓名不能为空")
                 .Matches("[\u4e00-\u9fa5]")
                 .WithMessage("公司姓名必须为中文")
             ;
            RuleFor(hr_info => hr_info.SeatNum).NotNull()
                 .WithMessage("车座数量不能为空")
                 .Matches("^[0-9]$")
                 .WithMessage("车座数量必须为数字")
             ;

            RuleFor(hr_info => hr_info.phone).NotNull()
                 .WithMessage("司机手机号不能为空")
                .Length(11)
                .WithMessage("手机号码长度必须为11位");
        }
    }
}