using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowProcedureAddResModel
    {
        public FlowProcedureAddResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
