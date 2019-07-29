using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class FoodInfoSearchResModel
    {
        public bool IsSuccess;
        public List<Food_Info> foodInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FoodInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
