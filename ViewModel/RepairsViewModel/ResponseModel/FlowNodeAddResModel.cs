using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowNodeAddResModel
    {
        public FlowNodeAddResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
