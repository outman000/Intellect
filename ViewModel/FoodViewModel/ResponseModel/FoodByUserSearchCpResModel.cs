using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class FoodByUserSearchCpResModel
    {
        public bool IsSuccess;
        public List<FoodCpMiddlecs> CpInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FoodByUserSearchCpResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
