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
        ///根据用户主键Id查询
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
       WeChatIndexMiddlecs WeChatLogin_Search(WeChatInfoViewModel  weChatInfoViewModel);
        User_Info Searchpwd(string userId);
        /// <summary>
        ///根据账号和密码查询用户和部门信息
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        WeChatLoginMiddlecs WeChatLogin_User(WeChatLoginViewModel weChatLoginViewModel);

        List<UserBind> UserBindSearch(string openid);
        List<UserBind> UserBindSearch2(string userId);

        int AddUserBind(string openid, string userId,string passWord);

        int WeChatLogin_User_Update(WeChatUpdateViewModel weChatUpdateViewModel);

        string SmsMessage(string phone, string message);


     
    }
}
