using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class FoodByUserSearchResModel
    {
        public bool IsSuccess;
        public int food_User_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FoodByUserSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
