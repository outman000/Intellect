using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserDepartRepository: IRepository<User_Depart>
    {
        //根据部门id查询
        IQueryable<User_Depart> GetDepartByCode(String code);
        //批量删除
        int DeleteByDepartidList(List<int> IdList);
        List<User_Depart> SearchDepartByWhere(DepartSearchViewModel departSearchViewModel);
        //根据主键id查询
        User_Depart GetInfoByDepartid(int id);
    }
}
