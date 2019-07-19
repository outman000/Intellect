using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class BusValideResRepeat
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public BusValideResRepeat()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
