using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class Bank_Payment_SearchResModel
    {
        public bool isSuccess;
        public Bank_Payment_SearchMiddle  bank_Payment_SearchMiddle;
        public BaseViewModel baseViewModel;
        public Bank_Payment_SearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
