using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface IFlowNodeDefineInfoRepository : IRepository<Flow_NodeDefine>
    {
        //根据节点主键id查询
        Flow_NodeDefine GetInfoByNodeDefineId(int id);
        //批量删除
        int DeleteByNodeDefineIdList(List<int> IdList);
        // 根据条件查节点信息
        IQueryable<Flow_NodeDefine> SearchInfoByNodeDefineWhere(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel);
        //根据流程主键id查相关节点
        IQueryable<Flow_NodeDefine> SearchInfoByNodeDefineWhere(int ProduceKeyId);
        Flow_NodeDefine GetInfoByProcedureDefineId(int id);

        // 根据id查节点信息
        Flow_NodeDefine GetById(int id);

        //查询节点信息数量
        IQueryable<Flow_NodeDefine> GetNodeDefineAll(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel);

        //根据当前节点查下一节点信息
        List<Flow_CurrentNodeAndNextNode> SearchNextNodeInfoByWhere(NextNodeByCurrentNodeSearchViewModel nextNodeByCurrentNodeSearchViewModel);

        //根据当前节点查下一节点信息(重载)
        List<Flow_CurrentNodeAndNextNode> SearchNextNodeInfoByWhere(int id);

        /// <summary>
        /// 给当前节点添加下一节点
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int CurrentNodeAddNextNode(List<Flow_CurrentNodeAndNextNode> list);


        /// <summary>
        ///  给当前节点删除下一节点
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="aimRoleId"></param>
        /// <returns></returns>
        int RelateCurrentNodeToNextNodeDel(List<CurrentNodeToNextNodeDelMiddlecs> list);
    }
}
