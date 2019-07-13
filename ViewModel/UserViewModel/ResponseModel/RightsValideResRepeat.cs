using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class RightsValideResRepeat
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public RightsValideResRepeat()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
