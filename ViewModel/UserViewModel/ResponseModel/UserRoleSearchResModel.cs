using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class UserRoleSearchResModel
    {
        public bool isSuccess;
        public List<UserRoleSearChMiddles>  userRoles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public UserRoleSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
