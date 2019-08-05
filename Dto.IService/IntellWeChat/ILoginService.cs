using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.WeChatViewModel.MiddleModel;
using ViewModel.WeChatViewModel.RequestViewModel;

namespace Dto.IService.IntellWeChat
{
    public interface ILoginService
    {
        /// <summary>
        ///根据账号和密码查询用户和部门信息
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
       WeChatIndexMiddlecs WeChatLogin_Search(WeChatInfoViewModel weChatLoginViewModel);
    }
}
