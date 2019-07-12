using ViewModel.UserViewModel.RequsetModel;
using FluentValidation;


namespace ViewModel.ViewValitor.UserViewValitor
{
    public class DepartUpdateValitor : AbstractValidator<DepartUpdateViewModel>
    {
        public DepartUpdateValitor()
        {
            RuleFor(hr_info => hr_info.Name).NotNull()
                  .WithMessage("部门名称不能为空")
              ;


            RuleFor(hr_info => hr_info.ParentId).NotNull()
                                 .WithMessage("部门所属不能为空");

            ;
        }
    }
}
