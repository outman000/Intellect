﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SuggestBoxViewModel.ResponseModel
{
    public class SuggestBoxUpdateResModel
    {
        public SuggestBoxUpdateResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
