using Dto.IRepository.IntellFood;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.IntellSuggestBox
{
    public interface ISuggestBoxRepository : IRepository<Suggest_Box>
    {
        //批量删除
        //int DeleteByFoodInfoIdList(List<int> IdList);
        //List<Food_Info> SearchFoodInfoByWhere(FoodInfoSearchViewModel foodInfoSearchViewModel);
       // 根据菜单主键id查询
        Suggest_Box GetInfoBySuggestBoxId(int id);

        //根据班车标识查询
        //IQueryable<Food_Info> GetInfoByFoodId(string code);
        //// 根据条件查人员缴费
        //IQueryable<Food_Info> SearchInfoByBusWhere(BusUserSearchViewModel busUserSearchViewModel);
        //根据条件查人员缴费数量
        //IQueryable<Food_Info> GetFoodAll(FoodInfoSearchViewModel foodInfoSearchViewModel);
    }
}
