using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class SatisfactionInfoSearchResModel
    {
        public bool isSuccess;
        public List<SatisfactionInfoSearchMiddlecs> SatisfactionInfo_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public int Temp;
        public SatisfactionInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
