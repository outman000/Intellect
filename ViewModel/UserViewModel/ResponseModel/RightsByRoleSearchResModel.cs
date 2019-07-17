using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class RightsByRoleSearchResModel
    {
        public bool IsSuccess;
        public List<RightsSearchMiddlecs> userRights;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RightsByRoleSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
