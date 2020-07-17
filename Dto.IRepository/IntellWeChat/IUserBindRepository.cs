using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.IntellWeChat
{
    public interface IUserBindRepository : IRepository<UserBind>
    {
        List<UserBind> GetoUserBindStr(string openid);
        List<UserBind> GetoUserBindStr2(string userid);
    }
}
