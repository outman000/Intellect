using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowProcedureSearchResModel
    {
        public bool isSuccess;
        public List<FlowProcedureSearchMiddlecs> procedure_Infos;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FlowProcedureSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
