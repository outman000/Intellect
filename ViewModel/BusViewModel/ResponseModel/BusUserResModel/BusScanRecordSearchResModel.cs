using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BusScanRecordSearchResModel
    {
        public bool isSuccess;
        public List<Bus_Scan_Record>  bus_Scan_Record;
        public int count;
        public BaseViewModel baseViewModel;
        public BusScanRecordSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
