using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface IRepairInfoRepository : IRepository<Repair_Info>
    {

        //根据报修主键id查询
        Repair_Info GetInfoByRepairId(int id);
        //批量删除
        int DeleteByRepairIdList(List<int> IdList);
        // 根据条件查报修信息
        IQueryable<Repair_Info> SearchInfoByRepairWhere(RepairInfoSearchViewModel repairInfoSearchViewModel);
        // 根据id查报修信息
        Repair_Info GetById(int id);
        //查询报修信息数量
        IQueryable<Repair_Info> GetInfoByRepairAll(RepairInfoSearchViewModel repairInfoSearchViewMode);
    }
}
