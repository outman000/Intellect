using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.OpinionInfoViewModel.RequestViewModel;

namespace Dto.IRepository.IntellOpinionInfo
{
    public interface IOpinionInfoRepository : IRepository<Opinion_Info>
    {
        //批量删除
        int DeleteByOpinionInfoIdList(List<int> IdList);

        //根据菜单主键id查询
        Opinion_Info GetInfoByOpinionId(int id);
        /// <summary>
        /// 根据条件查询领导意见
        /// </summary>
        /// <param name="opinionInfoSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<Opinion_Info> SearchOpinionInfoByWhere(OpinionInfoSearchViewModel  opinionInfoSearchViewModel);

        //根据菜单主键id查询
        List<Opinion_Info> GetInfoByRepair_InfoId(int id);

        //根据条件查询领导意见数量
        IQueryable<Opinion_Info> GetOpinionInfoAll(OpinionInfoSearchViewModel opinionInfoSearchViewModel);
    }
}
