using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class RelateRoleToUserDelResModel
    {
        public RelateRoleToUserDelResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int DelCount;

        public BaseViewModel baseViewModel;
    }
}
