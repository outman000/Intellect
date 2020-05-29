using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class PhoneSearchResModel
    {
        public bool isSuccess;
      
        public BaseViewModel baseViewModel;
        public string phone;

        public PhoneSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
