using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class FoodWeekOfMonthSearchResModel
    {
        public bool IsSuccess;
        public List<int>  vs;
        public BaseViewModel baseViewModel;
        public FoodWeekOfMonthSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
