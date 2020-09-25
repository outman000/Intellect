using Dtol.dtol;
using Microsoft.AspNetCore.Http;
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
        int User_SearchTest(UserSearchViewModel userSearchViewModel);
        string fileRandName(string fileRealname);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userAddViewModel"></param>
        /// <returns></returns>
        int User_Add(UserAddViewModel  userAddViewModel);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="userRegisterViewModel"></param>
        /// <returns></returns>
        int User_Register(UserRegisterViewModel userRegisterViewModel);



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
        int User_Get_ALLNum(UserSearchViewModel userSearchViewModel);

        /// <summary>
        /// 根据部门添加用户
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        /// <returns></returns>
       int Depart_User_Add(RelateDepartToUserAddViewModel relateDepartToUserAddViewModel);

        /// <summary>
        ///根据部门查询用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Depart_Search(UserByDepartSearchViewModel  userByDepartSearchViewModel);
       
        /// <summary>
        ///根据角色查询用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        List<UserSearchMiddlecs> User_By_Role_Search(UserByRoleSearchViewModel userByRoleSearchViewModel);


        /// <summary>
        ///根据角色列表查询用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        List<User_Info> User_By_RoleList_Search(List<int> RoleList);

        /// <summary>
        ///根据部门查询用户数量
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        int User_By_Depart_Get_ALLNum(UserByDepartSearchViewModel userByDepartSearchViewModel);

        /// <summary>
        ///根据角色查询用户数量
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        int User_By_Role_Get_ALLNum(UserByRoleSearchViewModel userByRoleSearchViewModel);
        /// <summary>
        /// 上传用户头像
        /// </summary>
        /// <param name="iformFile"></param>

        String GetUserHead(IFormFile iformFile);

       User_Info User_Single_Search(UserSearchByUserIdViewModel  userSearchByUserIdViewModel);

        int uploadTodatabase_User_Info(string filepath, string tableName, string tag);

        //保存
        string saveAttachInfo(IFormCollection fileinfo, string randomName);

        bool CheckIdcard(string Idcard);

        /// <summary>
        /// 添加用户的积分日志
        /// </summary>
        /// <param name="userIntegralLogAddViewModel"></param>
        /// <returns></returns>
        int User_Integral_Log_Add(UserIntegralLogAddViewModel userIntegralLogAddViewModel);

        /// <summary>
        /// 扫码加积分
        /// </summary>
        /// <param name="checkCodeSearchViewModel"></param>
        /// <returns></returns>
        string CheckCodeAddIntegral(UserIntegralViewModel userIntegralViewModel);

        /// <summary>
        /// 根据身份证号查询用户
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        List<User_Info> SearchByIdcard(string Idcard);
        /// <summary>
        /// 根据用户ID查询用户积分信息
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>

        List<User_Integral> SearchByUserId(string Id);

        /// <summary>
        /// 根据条件查询用户积分信息
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        List<User_Integral> SearchUserIntegralWhere(UserIntegralSearchViewModel userIntegralSearchViewModel);
        /// <summary>
        /// 根据条件查询用户积分信息数量
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        int SearchUserIntegralWhereNum(UserIntegralSearchViewModel userIntegralSearchViewModel);

 
    }
}

