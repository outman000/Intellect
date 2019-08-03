using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.WeChatViewModel.MiddleModel;

namespace ViewModel.WeChatViewModel.ResponseModel
{
    public class WeChatLoginResModel
    {
        public bool IsSuccess;
        public List<WeChatLoginMiddlecs> userInfo;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public WeChatLoginResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
