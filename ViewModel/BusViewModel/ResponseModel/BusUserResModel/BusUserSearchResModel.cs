using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BusUserSearchResModel
    {
        public bool isSuccess;
        public List<BusUserSearchMiddlecs> bus_user_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public int TotalExpen;
        public BusUserSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }

    }
}
