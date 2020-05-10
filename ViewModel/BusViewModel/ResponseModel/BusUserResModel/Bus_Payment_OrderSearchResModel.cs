using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class Bus_Payment_OrderSearchResModel
    {
        public bool isSuccess;
        public List<Bus_Payment_Order>  bus_Payment_Orders;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public Bus_Payment_OrderSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
