using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.WeChatViewModel.MiddleModel;

namespace ViewModel.WeChatViewModel.RequestViewModel
{
    public class WeChatLoginResModel
    {
        public bool IsSuccess;
        public WeChatLoginMiddlecs user_session;
        public BaseViewModel baseViewModel;
        
  
             
        public WeChatLoginResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
