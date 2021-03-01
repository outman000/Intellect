using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.IRepository.IntellOpinionInfo
{
    public interface IFoodInfoRepository : IRepository<Food_Info>
    {
        //批量删除
        int DeleteByFoodInfoIdList(List<int> IdList);
        /// <summary>
        /// 根据条件查询菜单信息
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        List<Food_Info> SearchFoodInfoByWhere(FoodInfoSearchViewModel  foodInfoSearchViewModel);
        //根据菜单主键id查询
        Food_Info GetInfoByFoodId(int id);

        //根据班车标识查询
        IQueryable<Food_Info> GetInfoByFoodId(string code);
       // 根据条件查人员缴费
       //IQueryable<Food_Info> SearchInfoByFoodWhere(FoodInfoSearchViewModel foodInfoSearchViewModel);
        //根据条件查人员缴费数量
        IQueryable<Food_Info> GetFoodAll(FoodInfoSearchViewModel foodInfoSearchViewModel);
        List<string> SearchFoodTypeInfoByWhere(FoodInfoSearchViewModel foodInfoSearchViewModel);

        void Add_Suggest_Food(Suggest_Food obj);
        /// <summary>
        /// 查询建议新增的菜
        /// </summary>
        /// <param name="suggestFoodSearchViewModel"></param>
        /// <returns></returns>
        List<Suggest_Food> SearchSuggestFoodInfoByWhere(SuggestFoodSearchViewModel suggestFoodSearchViewModel);

        /// <summary>
        /// 查询建议新增的菜数量
        /// </summary>
        /// <param name="suggestFoodSearchViewModel"></param>
        /// <returns></returns>
        List<Suggest_Food> SearchSuggestFoodInfoByWhereNum(SuggestFoodSearchViewModel suggestFoodSearchViewModel);

        /// <summary>
        /// 根据周数查询食品信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        List<Food_Info> GetInfoByWeekNumber(string y ,string wn, string FoodType);

        /// <summary>
        /// 获取数据库最大周数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        int GetMaxWeekNumber();

        /// <summary>
        /// 检查是否已存在数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        List<Food_Info> CheckTemplateAdd(string year, string zhou, string xq, string fn, string foodtype);

        void Add2(ComAttachs obj);

        /// <summary>
        /// 批量导入数据库（菜单信息）
        /// </summary>
        /// <param name="recommendedDirectories"></param>
        void AddRange_User_Info(List<Food_Info> user_Infos,string userID);
    }
}
