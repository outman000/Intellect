using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class RelateDepartToUserAddResModel
    {
        public RelateDepartToUserAddResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
