using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserValideResRepeat
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public UserValideResRepeat()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
