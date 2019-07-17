using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserInfoRepository : IRepository<User_Info>
    {
        //根据用户id查询
        IQueryable<User_Info>  GetInfoByUserid(string userid);
        //根据主键id查询
        User_Info GetInfoByUserid(int id);
        //批量删除
        int DeleteByUseridList(List<int>  IdList);
        // 根据条件查角色
        List<User_Info> SearchInfoByWhere(UserSearchViewModel  userSearchViewModel);

      
    }
}
