using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserRoleAddResModel
    {
        public UserRoleAddResModel()
        {
            baseViewModel = new BaseViewModel();
        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
