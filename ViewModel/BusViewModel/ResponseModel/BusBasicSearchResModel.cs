using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel
{
    public class BusBasicSearchResModel
    {
        public bool isSuccess;
        public BusBasicSearchMiddle  busBasicSearchMiddle;
        public BaseViewModel baseViewModel;
        public BusBasicSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
