using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public  class RoleByUserSearchResModel
    {
        public bool IsSuccess;
        public List<UserRoleSearChMiddles>  userRoles ;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RoleByUserSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
