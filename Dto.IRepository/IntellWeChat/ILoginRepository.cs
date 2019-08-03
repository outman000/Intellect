using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.WeChatViewModel.MiddleModel;
using ViewModel.WeChatViewModel.RequestViewModel;

namespace Dto.IRepository.IntellWeChat
{
    public interface ILoginRepository : IRepository<User_Info>
    {


        // 根据账号密码登录
        List<User_Info> SearchInfoByWhere(WeChatLoginViewModel weChatLoginViewModel);
    }
}
