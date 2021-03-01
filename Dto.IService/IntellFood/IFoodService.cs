using Dtol.dtol;
using Microsoft.AspNetCore.Http;
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
        List<FoodInfoSearchMiddle> Food_Search(FoodInfoSearchViewModel  foodInfoSearchViewModel);
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
        /// 根据用户id和菜id 增加
        /// </summary>
        /// <param name="foodByUserCpViewModel"></param>
        /// <returns></returns>
        int Food_Relate_UserCp(FoodByUserAddCpViewModel foodByUserAddCpViewModel);

        /// <summary>
        /// 查询差评数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        List<FoodPraiseNumMiddlecs> CpNumByFoodId(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs);

        /// <summary>
        /// 新增建议增加的菜
        /// </summary>
        /// <param name="suggestFoodAddViewModel"></param>
        /// <returns></returns>
        int SuggestFood_Add(SuggestFoodAddViewModel suggestFoodAddViewModel);


        /// <summary>
        /// 建议增加的菜查询
        /// </summary>
        /// <param name="suggestFoodSearchViewModel"></param>
        /// <returns></returns>
        List<SuggestFoodSearchMiddleModel> SuggestFood_Search(SuggestFoodSearchViewModel suggestFoodSearchViewModel);

        /// <summary>
        /// 查询建议增加的菜数量
        /// </summary>
        /// <param name="suggestFoodSearchViewModel"></param>
        /// <returns></returns>
        int SuggesttFood_Get_ALLNum(SuggestFoodSearchViewModel suggestFoodSearchViewModel);


        /// <summary>
        /// 日期转化为第几周
        /// </summary>
        /// <param name="day"></param>
        /// <param name="WeekStart"></param>
        /// <returns></returns>
        int WeekOfMonth(DateTime day, int WeekStart);

        /// <summary>
        /// 日期转化为第几周
        /// </summary>
        /// <param name="day"></param>
        /// <param name="WeekStart"></param>
        /// <returns></returns>
         List<int> WeekOfMonthSearch();

        /// <summary>
        /// 生成模板
        /// </summary>
        /// <param name="templateAddViewModel"></param>
        /// <returns></returns>
        int Template_Add(TemplateAddViewModel templateAddViewModel);


        //随机名称
        string fileRandName(string fileRealname);

        string saveAttachInfo(IFormCollection fileinfo, string randomName);

        //导入文件并存入数据库（菜单信息）
        int uploadTodatabase_User_Info(string filepath, string tableName, string tag , string userID);

        string getUserID(IFormCollection fileinfo, string randomName);
    }
}
