using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
  
    public class FoodInfoDelResModel
    {
        public FoodInfoDelResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int DelCount;

        public BaseViewModel baseViewModel;

    }
}
