using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BusUserSearchByCodeResModel
    {
        public bool isSuccess;
        public Bus_Payment bus_user_Info;
        //public string code;
        public BaseViewModel baseViewModel;

        public BusUserSearchByCodeResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
