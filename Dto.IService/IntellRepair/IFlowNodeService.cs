using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IService.IntellRepair
{
    public interface IFlowNodeService
    {

        /// <summary>
        /// 查询流转信息
        /// </summary>
        /// <param name="flowNodeSearchViewModel"></param>
        List<FlowNodeSearchMiddlecs> Node_Search(FlowNodeSearchViewModel flowNodeSearchViewModel);
        ///// <summary>
        ///// 根据表单Id查询流转信息
        ///// </summary>
        ///// <param name="flowNodeByRepairIdSearchViewModel"></param>
        ///// <returns></returns>
        //List<FlowNodeSearchMiddlecs> NodeByRepairId_Search(FlowNodeByRepairIdSearchViewModel flowNodeByRepairIdSearchViewModel);
        /// <summary>
        /// 查询流转信息数量
        /// </summary>
        /// <param name="flowNodeSearchViewModel"></param>
        /// <returns></returns>
        int Node_Get_ALLNum(FlowNodeSearchViewModel flowNodeSearchViewModel);
        /// <summary>
        /// 添加流转信息
        /// </summary>
        /// <param name="flowNodeAddViewModel"></param>
        /// <returns></returns>
        int FlowNode_Add(FlowNodeAddViewModel  flowNodeAddViewModel);
        /// <summary>
        /// 更新流转信息
        /// </summary>
        /// <param name="flowNodeUpdateViewModels"></param>
        /// <returns></returns>
        int FlowNode_Update(FlowNodeUpdateViewModel  flowNodeUpdateViewModel);

        /// <summary>
        /// 删除流转信息
        /// </summary>
        /// <param name="flowNodeDelViewModel"></param>
        /// <returns></returns>
        int Node_Delete(FlowNodeDelViewModel  flowNodeDelViewModel);


    }
}
