using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.IRepository.IntellUser
{
    public interface IUserRelateRoleRightRepository: IRepository<User_Relate_Role_Right>
    {
        /// <summary>
        /// 给角色添加权限
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateRoleToRightsAdd(List<User_Relate_Role_Right> list);
        /// <summary>
        /// 给角色删除权限
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateRoleToRightsDel(List<int> list);
    }
}
