using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SuggestBoxViewModel.ResponseModel
{
    public class SuggestBoxSearchResModel
    {
        public bool IsSuccess;
        public List<Suggest_Box> suggestBoxInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public SuggestBoxSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
