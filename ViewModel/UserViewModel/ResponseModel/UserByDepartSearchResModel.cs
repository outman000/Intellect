using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserByDepartSearchResModel
    {
        public bool IsSuccess;
        public List<UserSearchMiddlecs> userInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public UserByDepartSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
