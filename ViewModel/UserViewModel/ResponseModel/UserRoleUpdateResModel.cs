using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserRoleUpdateResModel
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public UserRoleUpdateResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
