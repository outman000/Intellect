using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.MiddleModel
{
    public class FoodInfoValideResRepeat
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public FoodInfoValideResRepeat()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
