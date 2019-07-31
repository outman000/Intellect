using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.IRepository.IntellOpinionInfo
{
    public interface IRelate_Food_UserRepository : IRepository<User_Relate_Food>
    {
        /// <summary>
        /// 根据用户和菜单查点赞信息
        /// </summary>
        /// <param name="foodByUserSearchViewModel"></param>
        /// <returns></returns>
        int SearchFoodInfoByWhere(FoodByUserPraiseViewModel foodByUserSearchViewModel);

        /// <summary>
        /// 给用户点赞关系表删数据
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateFoodToUserDel(FoodByUserPraiseViewModel foodByUserSearchViewModelt);

        /// <summary>
        /// 根据菜单id查询关系表
        /// </summary>
        /// <param name="foodIdSearchViewModel"></param>
        /// <returns></returns>
        List<FoodPraiseNumMiddlecs> RelateFoodToFoodIdSearch();
    }
}
