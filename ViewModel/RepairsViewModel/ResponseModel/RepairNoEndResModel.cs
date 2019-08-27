using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class RepairNoEndResModel
    {
        public bool isSuccess;
        public List<RepairNoEndMiddlecs> repair;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RepairNoEndResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
