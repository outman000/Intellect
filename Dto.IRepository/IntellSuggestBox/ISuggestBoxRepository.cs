using Dto.IRepository.IntellFood;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SuggestBoxViewModel.RequestViewModel;

namespace Dto.IRepository.IntellSuggestBox
{
    public interface ISuggestBoxRepository : IRepository<Suggest_Box>
    {
        //批量删除
        int DeleteByFoodInfoIdList(List<int> IdList);
        List<Suggest_Box> SearchSuggestBoxInfoByWhere(SuggestBoxSearchViewModel suggestBoxSearchViewModel);
        // 根据菜单主键id查询
        Suggest_Box GetInfoBySuggestBoxId(int id);

        //根据班车标识查询
        //IQueryable<Food_Info> GetInfoByFoodId(string code);
        // 根据条件查人员缴费
        //IQueryable<Suggest_Box> SearchInfoBySuggestBoxWhere(SuggestBoxSearchViewModel  suggestBoxSearchViewModel);
        //根据条件查人员缴费数量
        IQueryable<Suggest_Box> GeSuggestBoxAll(SuggestBoxSearchViewModel suggestBoxSearchViewModel);
    }
}
