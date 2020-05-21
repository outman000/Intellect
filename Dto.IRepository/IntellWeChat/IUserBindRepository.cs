using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.IntellWeChat
{
    public interface IUserBindRepository : IRepository<UserBind>
    {
        UserBind GetoUserBindStr(string openid);
    }
}
