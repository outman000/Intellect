using Dtol.dtol;
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
        /// 查询报修信息数量
        /// </summary>
        /// <param name="repairInfoSearchViewModel"></param>
        /// <returns></returns>
        int Repair_Get_ALLNum(RepairInfoSearchViewModel repairInfoSearchViewModel);

        /// <summary>
        /// 添加报修信息
        /// </summary>
        /// <param name="repairAddViewModel"></param>
        /// <returns></returns>
        WorkFlowFistReturnIdList Repair_Add(RepairAddViewModel repairAddViewModel, int Flow_ProcedureDefineId);

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


        /// <summary>
        /// 根据表单主键查表单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RepairInfoSearchMiddlecs GetInfoByRepairId(RepairIdSearchInfoViewModel repairIdSearchInfoViewModel);

       
    }
}
