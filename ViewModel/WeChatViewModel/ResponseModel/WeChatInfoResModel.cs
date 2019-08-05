using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.WeChatViewModel.MiddleModel;

namespace ViewModel.WeChatViewModel.ResponseModel
{
    public class WeChatInfoResModel
    {
        public bool IsSuccess;
        public WeChatIndexMiddlecs userInfo;
        public BaseViewModel baseViewModel;
        public WeChatInfoResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
