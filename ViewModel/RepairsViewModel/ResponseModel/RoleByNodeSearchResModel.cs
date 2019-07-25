using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class RoleByNodeSearchResModel
    {
        public bool IsSuccess;
        public List<UserRoleSearChMiddles> userRoles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RoleByNodeSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
