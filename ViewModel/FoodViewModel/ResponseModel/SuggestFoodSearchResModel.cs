using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class SuggestFoodSearchResModel
    {
        public bool IsSuccess;
        public List<SuggestFoodSearchMiddleModel>  suggest_Foods;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public SuggestFoodSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
