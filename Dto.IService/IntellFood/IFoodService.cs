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
        ///根据菜Id删除点赞数量
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        int By_Food_Id_Del(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel);

        /// <summary>
        ///根据用户和菜单查询点赞数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        List<FoodPraiseNumMiddlecs> PraiseNumByFoodId(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs);
    }
}
