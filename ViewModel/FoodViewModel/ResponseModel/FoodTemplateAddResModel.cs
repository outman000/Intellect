﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.FoodViewModel.ResponseModel
{
    public class FoodTemplateAddResModel
    {
        public FoodTemplateAddResModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
