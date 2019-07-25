using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowProcedureDefineSearchResModel
    {
        public bool isSuccess;
        public List<FlowProcedureDefineSearchMiddlecs> flowProcedureDefine_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FlowProcedureDefineSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
