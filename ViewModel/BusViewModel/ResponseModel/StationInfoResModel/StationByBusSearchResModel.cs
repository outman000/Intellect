using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.StationInfoResModel
{
    public class StationByBusSearchResModel
    {
        public bool IsSuccess;
        public List<Bus_Station> busStation;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StationByBusSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
