using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.ResponseModel
{
    public class SearchCarMileageResModel
    {
        public bool isSuccess;
        public string  searchCarMileageMiddles;
        public BaseViewModel baseViewModel;
        public SearchCarMileageResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
