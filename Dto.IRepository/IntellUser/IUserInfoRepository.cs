using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.IRepository.IntellUser
{
    public interface IUserInfoRepository : IRepository<User_Info>
    {
        //根据用户id查询
        IQueryable<User_Info>  GetInfoByUserid(String userid);
    }
}
