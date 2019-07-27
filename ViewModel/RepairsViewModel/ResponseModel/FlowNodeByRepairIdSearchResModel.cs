﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class FlowNodeByRepairIdSearchResModel
    {
        public bool isSuccess;
        public List<FlowNodeSearchMiddlecs> flowNodeDefine_Info;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FlowNodeByRepairIdSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
