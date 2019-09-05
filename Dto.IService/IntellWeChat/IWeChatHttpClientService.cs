using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.WeChatViewModel.MiddleModel;
using ViewModel.WeChatViewModel.ResponseModel;

namespace Dto.IService.IntellWeChat
{
    public interface IWeChatHttpClientService
    {
        /// <summary>
        /// 获取token
        /// </summary>
        Task<WeChatTokenResModel> getWeChatTokenAsync();

        /// <summary>
        /// 
        /// </summary>
      //  void getWeCHatTokenAsync();
    }
}
