using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserRegisterSearchResModel
    {
        public bool isSuccess;
        public List<User_Register>  user_Registers;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public UserRegisterSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
