using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserByRoleSearchResModel
    {
        public bool IsSuccess;
        public List<UserSearchMiddlecs> userInfos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public UserByRoleSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
