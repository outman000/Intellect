using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class RepairInfoSearchResModel
    {
        public bool isSuccess;
        public List<RepairInfoSearchMiddlecs> repair_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RepairInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
