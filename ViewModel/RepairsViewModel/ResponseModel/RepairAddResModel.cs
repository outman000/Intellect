﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;

namespace ViewModel.RepairsViewModel.ResponseModel
{
    public class RepairAddResModel
    {
        public RepairAddResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public WorkFlowFistReturnIdList  workFlowFistReturnIdList;

        public BaseViewModel baseViewModel;
    }
}
