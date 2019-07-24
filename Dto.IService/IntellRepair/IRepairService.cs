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
        /// <param name="repairInfoSearchViewModel"></param>
        List<RepairInfoSearchMiddlecs> Repair_Search(RepairInfoSearchViewModel repairInfoSearchViewModel);
        /// <summary>
        /// 添加报修信息
        /// </summary>
        /// <param name="repairAddViewModel"></param>
        /// <returns></returns>
        int Repair_Add(RepairAddViewModel repairAddViewModel);

        /// <summary>
        /// 删除报修信息
        /// </summary>
        /// <param name="repairDelViewModel"></param>
        /// <returns></returns>
        int Repair_Delete(RepairDelViewModel repairDelViewModel);


        /// <summary>
        /// 更新表单信息
        /// </summary>
        /// <param name="repairUpdateViewModel"></param>
        /// <returns></returns>

        int Repair_Update(RepairUpdateViewModel repairUpdateViewModel);
    }
}
