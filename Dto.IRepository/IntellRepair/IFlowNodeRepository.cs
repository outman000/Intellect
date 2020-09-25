using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface IFlowNodeRepository : IRepository<Flow_Node>
    {
        //根据流转信息主键id查询
        Flow_Node GetInfoByNodeId(int id);
        //批量删除
        int DeleteByNodeIdList(List<int> IdList);
        //// 根据条件查流转信息
        List<Flow_Node> SearchInfoByNodeWhere(FlowNodeSearchViewModel flowNodeSearchViewModel);
        //// 根据条件查流转信息(重载查找上一节点id)
        List<Flow_Node> SearchInfoByNodeWhere(FlowInfoSearchViewModel fLowInfoSearchViewModel);

        List<Flow_Node> SearchInfoByNode2Where(FlowNodeKeepSearchViewModel  flowNodeKeepSearchViewModel);

        //// 根据表单ID查流转信息
        List<Flow_Node> SearchInfoByRepariIdWhere(FlowNodeByRepairIdSearchViewModel flowNodeByRepairIdSearchViewModel);
        // 根据id查流转信息
        Flow_Node GetById(int id);

        //查询流转信息数量
        IQueryable<Flow_Node> GetNodeAll(FlowNodeSearchViewModel flowNodeSearchViewModel);

        List<Flow_Node> SearchInfoNiWenWhere(FlowNodeNiWenSearchViewModel flowNodeNiWenSearchViewModel);
    }
}
