using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IService.IntellUser
{
    public  interface IRoleService
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="userRoleAddViewModel"></param>
        /// <returns></returns>
        int User_Role_Add(UserRoleAddViewModel  userRoleAddViewModel);
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="userRoleDeleteViewModel"></param>
        /// <returns></returns>
        int User_Role_Delete(UserRoleDeleteViewModel  userRoleDeleteViewModel);
        /// <summary>
        /// 验证角色的唯一性
        /// </summary>
        /// <param name="userRoleSingleViewModel"></param>
        /// <returns></returns>
        bool User_Role_Single(UserRoleSingleViewModel  userRoleSingleViewModel);
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        List<UserRoleSearChMiddles> User_Role_Search(UserRoleSearchViewModel userRoleSearchViewModel);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userRoleUpdateViewModel"></param>
        /// <returns></returns>
        int User_Role_Update(UserRoleUpdateViewModel userRoleUpdateViewModel);
        /// <summary>
        /// 给角色分配用户
        /// </summary>
        /// <param name="relateRoleToUserAddViewModel"></param>
        /// <returns></returns>
        int User_RoleToUser_Add(RelateRoleToUserAddViewModel relateRoleToUserAddViewModel);
    }
}
