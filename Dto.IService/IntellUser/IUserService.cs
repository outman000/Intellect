using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;
namespace Dto.IService.IntellUser
{
    public interface IUserService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userAddViewModel"></param>
        /// <returns></returns>
          int User_Add(UserAddViewModel  userAddViewModel);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userUpdateViewModel"></param>
        /// <returns></returns>
          int User_Update(UserUpdateViewModel  userUpdateViewModel);
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userDeleteViewModel"></param>
        /// <returns></returns>
          int User_Delete(UserDeleteViewModel  userDeleteViewModel);
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        List<UserSearchMiddlecs> User_Search(UserSearchViewModel userSearchViewModel);
        /// <summary>
        /// 验证用户的唯一性
        /// </summary>
        /// <param name="userValideRepeat"></param>
        /// <returns></returns>
        bool User_Single(UserValideRepeat  userValideRepeat);
        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <returns></returns>
        int User_Get_ALLNum();

        /// <summary>
        /// 根据部门添加用户
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        /// <returns></returns>
       int Depart_User_Add(RelateDepartToUserAddViewModel relateDepartToUserAddViewModel);
       
        /// <summary>
        ///根据角色查询用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Role_Search(UserByRoleSearchViewModel userByRoleSearchViewModel);
    }
}

