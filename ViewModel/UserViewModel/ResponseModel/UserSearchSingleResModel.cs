using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserSearchSingleResModel
    {
        public bool isSuccess;
        public User_Info user_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public UserSearchSingleResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
