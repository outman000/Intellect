using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace ViewModel.UserViewModel.ResponseModel
{
    public class IntegralCommoditySearchResModel
    {
        public bool isSuccess;
        public List<IntegralCommodityMiddle>  integral_Commodities;
        public BaseViewModel baseViewModel;
        public int TotalNum;

        public IntegralCommoditySearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
