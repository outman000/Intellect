using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BusUserTimeListSearchResModel
    {
        public bool isSuccess;
        public List<string> bus_user_time_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public BusUserTimeListSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
