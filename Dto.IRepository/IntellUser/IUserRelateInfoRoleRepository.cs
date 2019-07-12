using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserRelateInfoRoleRepository : IRepository<User_Relate_Info_Role>
    {
        /// <summary>
        /// 给角色添加用户
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateRoleToUser(List<User_Relate_Info_Role> list);
    }
}
