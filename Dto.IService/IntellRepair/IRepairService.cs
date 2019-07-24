using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IService.IntellRepair
{
    public interface IRepairService
    {
        /// <summary>
        /// 查询报修信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        List<RepairInfoSearchMiddlecs> Repair_Search(RepairInfoSearchViewModel repairInfoSearchViewModel);
    }
}
