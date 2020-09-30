using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserInfoRepository : IRepository<User_Info>
    {
        void Add3(User_Register obj);
        //根据用户id查询
        IQueryable<User_Info>  GetInfoByUserid(string userid);
         void Add2(ComAttachs obj);
        User_Info GetPwd(string userid);
        //根据主键id查询
        User_Info GetInfoByUserid(int id);
        //根据主键id查询用户信息和部门信息
        User_Info GetInfoAndDepartByUserid(int id);

        //批量删除
        int DeleteByUseridList(List<int>  IdList);
        // 根据条件查角色
        List<User_Info> SearchInfoByWhere(UserSearchViewModel  userSearchViewModel);
        //查询用户数量
        IQueryable<User_Info> GetUserAll(UserSearchViewModel userSearchViewModel);
        void AddRange_User_Info(List<User_Info> user_Infos);
        /// <summary>
        /// 根据部门查用户数量
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<User_Info> GetUserByDepartAll(UserByDepartSearchViewModel userByDepartSearchViewModel);
      
        /// <summary>
        ///根据部门查用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        List<User_Info> SearchUserInfoByDepartWhere(UserByDepartSearchViewModel  userByDepartSearchViewModel);


        List<User_Info> CheckIdcard(string Idcard);

        List<User_Info> SearchByIdcard(string Idcard);

        /// <summary>
        /// 根据账号查询
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<User_Info> GetPwdByUserid(string userid);

        List<User_Test> SearchUser_Test();

        void Update3(User_Test obj);
    }
}
