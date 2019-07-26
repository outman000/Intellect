using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IService.IntellRepair
{
    public interface IFlowProcedureDefineService
    {
        /// <summary>
        /// 添加流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineAddViewModel"></param>
        /// <returns></returns>
        int ProcedureDefine_Add(FlowProcedureDefineAddViewModel  flowProcedureDefineAddViewModel);

        /// <summary>
        /// 查询流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineSearchViewModel"></param>
        List<FlowProcedureDefineSearchMiddlecs> ProcedureDefine_Search(FlowProcedureDefineSearchViewModel  flowProcedureDefineSearchViewModel);

        /// <summary>
        /// 查询流程定义信息数量
        /// </summary>
        /// <param name="flowProcedureDefineSearchViewModel"></param>
        /// <returns></returns>
        int ProcedureDefine_Get_ALLNum(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel);

        /// <summary>
        /// 删除流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineDelViewModel"></param>
        /// <returns></returns>
        int ProcedureDefine_Delete(FlowProcedureDefineDelViewModel  flowProcedureDefineDelViewModel);


        /// <summary>
        /// 更新流程定义信息
        /// </summary>
        /// <param name = "flowProcedureDefineUpdateViewModel" ></ param >
        /// < returns ></ returns >
        int ProcedureDefine_Update(FlowProcedureDefineUpdateViewModel  flowProcedureDefineUpdateViewModel);

        /// <summary>
        /// 验证流程的唯一性
        /// </summary>
        /// <param name="flowProcedureDefineSingleViewModel"></param>
        /// <returns></returns>
        bool ProcedureDefine_Single(FlowProcedureDefineSingleViewModel  flowProcedureDefineSingleViewModel);
    }
}
