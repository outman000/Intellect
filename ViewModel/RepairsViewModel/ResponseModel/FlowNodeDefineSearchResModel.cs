using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowNodeDefineSearchResModel
    {
        public bool isSuccess;
        public List<FlowNodeDefineSearchMiddlecs> flowNodeDefine_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FlowNodeDefineSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
