using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowNodeDelResModel
    {
        public FlowNodeDelResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int DelCount;

        public BaseViewModel baseViewModel;
    }
}
