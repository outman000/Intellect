using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class Bus_OrderByRepairsSearchResModel
    {
        public bool isSuccess;
        public Bus_Payment_OrderSearchMiddle bus_Payment_OrderSearchMiddle;
        public BaseViewModel baseViewModel;
        public Bus_OrderByRepairsSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
