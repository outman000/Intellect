using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SuggestBoxViewModel.MiddleModel;

namespace ViewModel.SuggestBoxViewModel.ResponseModel
{
    public class SuggestBoxSearchByIdResModel
    {
        public bool IsSuccess;
        public SuggestInfoMiddlecs suggestBoxInfo;
        public BaseViewModel baseViewModel;
        public SuggestBoxSearchByIdResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
