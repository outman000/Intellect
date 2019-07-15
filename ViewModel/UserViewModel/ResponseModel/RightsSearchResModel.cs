using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class RightsSearchResModel
    {
        public bool isSuccess;
        public List<RightsSearchMiddlecs> user_Rights;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RightsSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
