using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class FoodByFoodIdSearchResModel
    {
        public bool IsSuccess;
        public List<FoodPraiseNumMiddlecs> PraiseInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FoodByFoodIdSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
