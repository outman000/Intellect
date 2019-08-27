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
        /// 根据用户和菜单查差评信息
        /// </summary>
        /// <param name="foodByUserAddCpViewModel"></param>
        /// <returns></returns>
        int SearchFoodInfoByWhere(FoodByUserAddCpViewModel foodByUserAddCpViewModel);

        /// <summary>
        /// 根据用户和菜单查差评信息
        /// </summary>
        /// <param name="foodByUserSearchCpViewModel"></param>
        /// <returns></returns>
        List<User_Relate_Food> SearchFoodInfoByWhere(FoodByUserSearchCpViewModel foodByUserSearchCpViewModel);

        /// <summary>
        /// 给用户点赞关系表删数据
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateFoodToUserDel(FoodByUserPraiseViewModel foodByUserSearchViewModelt);

        /// <summary>
        /// 根据菜ID给用户点赞关系表删点赞数据
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        int ByFoodIdDel(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel);
        /// <summary>
        /// 根据菜ID给用户点赞关系表删差评数据
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        int ByFoodIdDelCp(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel);
        /// <summary>
        /// 根据菜单id查询关系表
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        List<FoodPraiseNumMiddlecs> RelateFoodToFoodIdSearch(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs);

        /// <summary>
        /// 根据用户查差评信息
        /// </summary>
        /// <param name="foodByUserCpViewModel"></param>
        /// <returns></returns>
        int SearchFoodCpInfoByWhere(FoodByUserCpViewModel foodByUserCpViewModel);

        /// <summary>
        /// 根据用户和菜Id删差评信息
        /// </summary>
        /// <param name="foodByUserCpViewModel"></param>
        /// <returns></returns>
        int RelateFoodToUserDelCp(FoodByUserCpViewModel foodByUserCpViewModel);
        /// <summary>
        /// 查询差评数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        List<FoodPraiseNumMiddlecs> RelateFoodToFoodIdCpSearch(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs);
    }
}
