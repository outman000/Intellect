using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IService.IntellRepair
{
    public interface IFlowProcedureInfoService
    {
        /// <summary>
        /// 查询流程信息
        /// </summary>
        /// <param name="flowProcedureSearchViewModel"></param>
        /// <returns></returns>
        List<FlowProcedureSearchMiddlecs> Procedure_Search(FlowProcedureSearchViewModel flowProcedureSearchViewModel);

        /// <summary>
        /// 查询流程信息数量
        /// </summary>
        /// <param name="flowProcedureSearchViewModel"></param>
        /// <returns></returns>
        int Procedure_Get_ALLNum(FlowProcedureSearchViewModel flowProcedureSearchViewModel);

        /// <summary>
        /// 删除流程信息
        /// </summary>
        /// <param name="flowProcedureDelViewModel"></param>
        /// <returns></returns>
        int Procedure_Delete(FlowProcedureDelViewModel  flowProcedureDelViewModel);


        /// <summary>
        /// 更新流程信息
        /// </summary>
        /// <param name="flowProcedureUpdateViewModel"></param>
        /// <returns></returns>
        int Procedure_Update(FlowProcedureUpdateViewModel flowProcedureUpdateViewModel);
    }
}
