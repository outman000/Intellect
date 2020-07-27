using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BusLocationInformationSearchResModel
    {

        public bool isSuccess;
        public BusLocationInformationSearchMiddle  busLocationInformationSearchMiddle;
        public BaseViewModel baseViewModel;
        public BusLocationInformationSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
