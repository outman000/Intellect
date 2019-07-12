using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
  public class DepartValideResRepeat
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public DepartValideResRepeat()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
