using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SuggestBoxViewModel.ResponseModel
{
    public class SuggestBoxTypeSearchResModel
    {
        public bool IsSuccess;
        public List<Suggest_Box_Type> suggestBoxTypeInfo;
        public BaseViewModel baseViewModel;
        public SuggestBoxTypeSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
