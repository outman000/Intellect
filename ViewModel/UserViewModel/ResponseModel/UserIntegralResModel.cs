using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserIntegralResModel
    {
        public bool isSuccess;
        public int count;
        public List<User_Integral>  user_Integrals;
        public BaseViewModel baseViewModel;
        public UserIntegralResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
