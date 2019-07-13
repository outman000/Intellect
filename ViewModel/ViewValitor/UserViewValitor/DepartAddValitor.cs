
using FluentValidation;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.RequsetModel;

namespace ViewModel.ViewValitor.UserViewValitor
{
    public class DepartAddValitor : AbstractValidator<DepartAddViewModel>
    {
        public DepartAddValitor()
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
