using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel.BusUserResModel
{
    public class CarOccupyResModel
    {
        public bool isSuccess;
        public List<CarOccupyMiddle>  carOccupyMiddles;
        public BaseViewModel baseViewModel;
        public CarOccupyResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
