using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusInfoResModel
{
    public class BusByLineSearchResModel
    {
        public bool IsSuccess;
        public List<Bus_Info> busInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public BusByLineSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
