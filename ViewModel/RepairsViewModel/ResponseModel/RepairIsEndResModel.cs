using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class RepairIsEndResModel
    {
        public bool isSuccess;
        public List<RepairIsEndMiddlecs> repair;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RepairIsEndResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
