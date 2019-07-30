using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

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
        /// <summary>
        /// 给角色删除用户
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateRoleToUserDel(List<RelateRoleUserDelMiddlecs> list);
        /// <summary>
        /// 根据用户查角色
        /// </summary>
        /// <param name="roleByUserSearchViewModel"></param>
        /// <returns></returns>
        List<User_Relate_Info_Role> SearchRoleInfoByWhere(RoleByUserSearchViewModel roleByUserSearchViewModel);

        /// <summary>
        /// 根据角色查用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        List<User_Relate_Info_Role> SearchUserInfoByWhere(UserByRoleSearchViewModel userByRoleSearchViewModel);

        /// <summary>
        /// 根据角色列表查用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        List<User_Info> SearchUserInfoByListWhere(List<int> RoleList);

        /// <summary>
        /// 根据角色查用户数量
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<User_Relate_Info_Role> GetUserByRoleAll(UserByRoleSearchViewModel userByRoleSearchViewModel);
        /// <summary>
        /// 根据用户查角色数量
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<User_Relate_Info_Role> GetRoleByUserAll(RoleByUserSearchViewModel roleByUserSearchViewModel);


        
    }

}
