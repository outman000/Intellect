using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel
{
    public class ReassignmentRecordSearchResModel
    {
        public bool IsSuccess;
        public List<Car_Reassignment_Record>  car_Reassignment_Records;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public ReassignmentRecordSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
