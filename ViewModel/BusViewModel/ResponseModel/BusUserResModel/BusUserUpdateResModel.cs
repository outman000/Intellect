using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class BusUserUpdateResModel
    {
         public BusUserUpdateResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
