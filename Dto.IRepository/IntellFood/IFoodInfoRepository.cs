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

       
    }
}
