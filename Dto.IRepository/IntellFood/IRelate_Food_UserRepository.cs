using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.IRepository.IntellFood
{
    public interface IRelate_Food_UserRepository : IRepository<User_Relate_Food>
    {
        /// <summary>
        /// 根据用户和菜单查点赞信息
        /// </summary>
        /// <param name="foodByUserSearchViewModel"></param>
        /// <returns></returns>
        List<User_Relate_Food> SearchFoodInfoByWhere(FoodByUserSearchViewModel foodByUserSearchViewModel);

        ///// <summary>
        ///// 给用户点赞关系表删数据
        ///// </summary>
        ///// <param name="userIdList"></param>
        ///// <param name="aimRoleId"></param>
        ///// <returns></returns>
        //int RelateRoleToUserDel(List<RelateRoleUserDelMiddlecs> list);

    }
}
