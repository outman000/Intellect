using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.OpinionInfoViewModel.MiddleModel;
using ViewModel.PublicViewModel;

namespace ViewModel.OpinionInfoViewModel.ResponseModel
{
    public class OpinionInfoSearchResModel
    {
        public bool IsSuccess;
        public List<OpinionInfoSearchMiddlecs> suggestBoxInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public OpinionInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
