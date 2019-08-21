using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SuggestBoxViewModel.MiddleModel;

namespace ViewModel.SuggestBoxViewModel.ResponseModel
{
    public class SuggestBoxSearchResModel
    {
        public bool IsSuccess;
        public List<SuggestInfoMiddlecs> suggestBoxInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public SuggestBoxSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
