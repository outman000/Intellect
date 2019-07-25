using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowProcedureDefineSingleResModel
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public FlowProcedureDefineSingleResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
