using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface IFlowNodeDefineInfoRepository : IRepository<Flow_NodeDefine>
    {
        //根据节点主键id查询
        Flow_NodeDefine GetInfoByNodeDefineId(int id);
        //批量删除
        int DeleteByNodeDefineIdList(List<int> IdList);
        // 根据条件查节信息
        IQueryable<Flow_NodeDefine> SearchInfoByNodeDefineWhere(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel);
        // 根据id查节信息
        Flow_NodeDefine GetById(int id);
    }
}
