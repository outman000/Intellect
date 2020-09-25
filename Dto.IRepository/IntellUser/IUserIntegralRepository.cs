using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserIntegralRepository : IRepository<User_Integral_Log>
    {
        List<User_Integral> SearchUserIntegral(string  idcard);
        void Add_User_Integral(User_Integral obj);

        void Update_User_Integral(User_Integral obj);

        List<User_Integral_Log> SearchUserIntegral2(string idcard);

        List<User_Integral> SearchUserIntegralByUserId(string id);

        /// <summary>
        /// 根据条件查询用户积分
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>
        List<User_Integral> SearchUserIntegralAll(UserIntegralSearchViewModel userIntegralSearchViewModel);
        /// <summary>
        ///  根据条件查询用户积分数量
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>
        List<User_Integral> SearchUserIntegralAllNum(UserIntegralSearchViewModel userIntegralSearchViewModel);
    }
}
