﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.OpinionInfoViewModel.ResponseModel
{
    public class OpinionInfoAddResModel
    {
        public OpinionInfoAddResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
