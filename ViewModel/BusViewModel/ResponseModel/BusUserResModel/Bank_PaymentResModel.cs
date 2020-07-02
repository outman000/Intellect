using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class Bank_PaymentResModel
    {
        public bool isSuccess;
        public Bank_PaymentMiddle  bank_PaymentMiddle;
        public BaseViewModel baseViewModel;
      //  public string ip;
        public Bank_PaymentResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
