using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.OpinionInfoViewModel.ResponseModel
{
    public class OpinionInfoUpdateResModel
    {
        public OpinionInfoUpdateResModel()
        {
            baseViewModel = new BaseViewModel();

        }

        public bool IsSuccess;
        public int AddCount;

        public BaseViewModel baseViewModel;
    }
}
