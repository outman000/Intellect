using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel
{
    public class BusScanRecordTongJiSearchResModel
    {
        public bool isSuccess;
        public List<BusScanRecordTongjiNumMiddle> bus_Scan_Record;
        public BaseViewModel baseViewModel;
        public BusScanRecordTongJiSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
