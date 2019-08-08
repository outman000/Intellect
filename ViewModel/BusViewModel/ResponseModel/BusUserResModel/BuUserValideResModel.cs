using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BuUserValideResModel
    {
        
        public bool isSuccess;
        public IDictionary<int, String> errorResult;
        public BaseViewModel baseViewModel;
        public BuUserValideResModel()
        {
            baseViewModel = new BaseViewModel();
        }

    }
}
