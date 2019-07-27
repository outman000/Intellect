using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowNodeUpdateResModels
    {
        public FlowNodeUpdateResModels()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
