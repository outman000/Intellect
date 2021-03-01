using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class FoodInfoSearchResModel
    {
        public bool IsSuccess;
        public List<string> foodType;
        public List<FoodInfoSearchMiddle> foodInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FoodInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
