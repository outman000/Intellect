using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;

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

        /// <summary>
        /// 根据权限查角色
        /// </summary>
        /// <param name="roleByRightsSearchViewModel"></param>
        /// <returns></returns>
        List<User_Relate_Role_Right> SearchRoleInfoByRightsWhere(RoleByRightsSearchViewModel roleByRightsSearchViewModel);
        /// <summary>
        /// 根据权限查角色数量
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<User_Relate_Role_Right> GetRoleByRightsAll(RoleByRightsSearchViewModel roleByRightsSearchViewModel);
        /// <summary>
        /// 根据角色查权限
        /// </summary>
        /// <param name="rightsByRoleSearchViewModel"></param>
        /// <returns></returns>
        List<User_Relate_Role_Right> SearchRightsInfoByRoleWhere(RightsByRoleSearchViewModel rightsByRoleSearchViewModel);
        /// <summary>
        /// 根据角色查权限数量
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<User_Relate_Role_Right> GetRightsByRoleAll(RightsByRoleSearchViewModel rightsByRoleSearchViewModel);

    }
}
