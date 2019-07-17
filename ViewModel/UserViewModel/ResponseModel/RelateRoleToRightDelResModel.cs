using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class RelateRoleToRightDelResModel
    {

        public RelateRoleToRightDelResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int DelCount;

        public BaseViewModel baseViewModel;
    }
}
