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


        /// <summary>
        /// token
        /// </summary>
        public TokenViewModel tokenViewModel { get; set; }

        public WeChatLoginResModel()
        {
            tokenViewModel = new TokenViewModel();
            baseViewModel = new BaseViewModel();
        }
    }
}
