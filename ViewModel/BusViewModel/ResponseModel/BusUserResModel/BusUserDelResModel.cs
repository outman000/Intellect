using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BusUserDelResModel
    {
        public BusUserDelResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int DelCount;

        public BaseViewModel baseViewModel;
    }
}
