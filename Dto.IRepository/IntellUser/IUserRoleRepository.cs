using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserRoleRepository : IRepository<User_Role>
    {
        IQueryable<User_Role> GetInfoByRoleCode(string roleCode);
        int DeleteByRoleIdList(List<int> deleleIdList);
        List<User_Role> SearchRoleInfoByWhere(UserRoleSearchViewModel userRoleSearchViewModel);
        //根据主键id查询
        User_Role GetInfoByRoleid(int id);
    }
}
