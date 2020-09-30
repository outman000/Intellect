using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserIntegralSearchResModel
    {
        public bool isSuccess;
        public int count;
        public List<UserIntegralSearchMiddle> user_Integrals;
        public BaseViewModel baseViewModel;
        public UserIntegralSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
