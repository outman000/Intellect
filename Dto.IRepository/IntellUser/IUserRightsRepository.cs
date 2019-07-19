using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserRightsRepository : IRepository<User_Rights>
    {  
        //根据权限id查询
        IQueryable<User_Rights> GetRightsByValue(String RightsValue);
        //批量删除
        int DeleteByRightsidList(List<int> IdList);
        //
        List<User_Rights> SearchRightsByWhere(RightsSearchViewModel rightsSearchViewModel);
        //根据主键id查询
        User_Rights GetInfoByRightId(int id);
    }
}
