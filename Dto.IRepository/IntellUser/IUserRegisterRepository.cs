using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserRegisterRepository : IRepository<User_Register>
    {
        List<User_Register> SearchById(int Id);
        /// <summary>
        /// 查询注册信息
        /// </summary>
        /// <param name="userRegisterSearchViewModel"></param>
        /// <returns></returns>
        List<User_Register> SearchUserRegister(UserRegisterSearchViewModel userRegisterSearchViewModel);
        /// <summary>
        /// 查询注册信息数量 
        /// </summary>
        /// <param name="userRegisterSearchViewModel"></param>
        /// <returns></returns>
        List<User_Register> SearchUserRegisterNum(UserRegisterSearchViewModel userRegisterSearchViewModel);
    }
}
