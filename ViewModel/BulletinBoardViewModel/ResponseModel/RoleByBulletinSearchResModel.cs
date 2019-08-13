using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.BulletinBoardViewModel.ResponseModel
{
    public class RoleByBulletinSearchResModel
    {
        public bool IsSuccess;
        public List<UserRoleSearChMiddles> userRoles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RoleByBulletinSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
