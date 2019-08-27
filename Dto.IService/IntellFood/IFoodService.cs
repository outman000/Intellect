using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.IService.IntellFood
{
    public interface IFoodService
    {

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="foodInfoAddViewModel"></param>
        /// <returns></returns>
        int Food_Add(FoodInfoAddViewModel  foodInfoAddViewModel);
        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="foodInfoUpdateViewModel"></param>
        /// <returns></returns>
        int Food_Update(FoodInfoUpdateViewModel  foodInfoUpdateViewModel);
        /// <summary>
        /// 删除菜单信息
        /// </summary>
        /// <param name="foodInfoDelViewModel"></param>
        /// <returns></returns>
        int Food_Delete(FoodInfoDelViewModel   foodInfoDelViewModel);
        /// <summary>
        /// 查询菜单信息
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        List<Food_Info> Food_Search(FoodInfoSearchViewModel  foodInfoSearchViewModel);
        /// <summary>
        /// 获取菜单总数
        /// </summary>
        /// <returns></returns>
        int Food_Get_ALLNum(FoodInfoSearchViewModel foodInfoSearchViewModel);
        /// <summary>
        /// 获取菜单差评总数
        /// </summary>
        /// <returns></returns>
        int FoodCp_Get_ALLNum(FoodByUserSearchCpViewModel foodByUserSearchCpViewModel);
        /// <summary>
        /// 验证菜单的唯一性
        /// </summary>
        /// <param name="foodInfoValideRepeat"></param>
        /// <returns></returns>
        bool Food_Single(FoodInfoValideRepeat  foodInfoValideRepeat);

        /// <summary>
        ///根据用户和菜单查询有无点赞信息
        /// </summary>
        /// <param name="foodByUserSearchViewMode"></param>
        /// <returns></returns>
        int Food_Relate_User(FoodByUserPraiseViewModel foodByUserSearchViewMode);

        /// <summary>
        /// 根据用户和菜单查询差评信息
        /// </summary>
        /// <param name="foodByUserAddCpViewModel"></param>
        /// <returns></returns>
        int Food_Relate_User_ADD_Pj(FoodByUserAddCpViewModel foodByUserAddCpViewModel);

        /// <summary>
        /// 根据用户和菜单查询差评信息(重载)
        /// </summary>
        /// <param name="foodByUserSearchCpViewModel"></param>
        /// <returns></returns>
        List<FoodCpMiddlecs> Food_Relate_User_Search_CP(FoodByUserSearchCpViewModel foodByUserSearchCpViewModel);
        /// <summary>
        ///根据菜Id删除点赞数量
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        int By_Food_Id_Del(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel);

        /// <summary>
        ///根据菜Id删除点赞数量
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        int By_Food_Id_DelCp(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel);

        /// <summary>
        ///根据用户和菜单查询点赞数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        List<FoodPraiseNumMiddlecs> PraiseNumByFoodId(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs);

        List<string> FoodType_Search(FoodInfoSearchViewModel foodInfoSearchViewModel);

        /// <summary>
        /// 根据用户id和菜id 增加或者减少差评
        /// </summary>
        /// <param name="foodByUserCpViewModel"></param>
        /// <returns></returns>
        int Food_Relate_UserCp(FoodByUserCpViewModel foodByUserCpViewModel);

        /// <summary>
        /// 查询差评数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        List<FoodPraiseNumMiddlecs> CpNumByFoodId(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs);
    }
}
