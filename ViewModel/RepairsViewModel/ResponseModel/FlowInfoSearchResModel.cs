using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowInfoSearchResModel
    {
        public FlowInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public FlowNodePreMiddlecs flowNodePreMiddlecs;

        public BaseViewModel baseViewModel;
    }
}
