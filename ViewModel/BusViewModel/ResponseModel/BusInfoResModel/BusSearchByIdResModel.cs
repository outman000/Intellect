using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusInfoResModel
{
    public class BusSearchByIdResModel
    {
        public bool isSuccess;
        public BaseViewModel baseViewModel;
        //public int TotalNum;
        public BusSearchByIdResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
