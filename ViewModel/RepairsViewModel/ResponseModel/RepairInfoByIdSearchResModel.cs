using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class RepairInfoByIdSearchResModel
    {
        public bool isSuccess;
        public RepairInfoSearchMiddlecs repair_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public RepairInfoByIdSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
