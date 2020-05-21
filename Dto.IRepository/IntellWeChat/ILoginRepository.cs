using Dtol.dtol;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.WeChatViewModel.MiddleModel;
using ViewModel.WeChatViewModel.RequestViewModel;

namespace Dto.IRepository.IntellWeChat
{
    public interface ILoginRepository : IRepository<User_Info>
    {
        List<User_Relate_Info_Role> SearchInfoByWhere(int id);
        User_Info ValideUserInfo(WeChatLoginViewModel weChatLoginViewModel);
        // 根据账号密码登录
        List<User_Info> ValideNewUserInfo(WeChatUpdateViewModel weChatUpdateViewModel);
    }
}
