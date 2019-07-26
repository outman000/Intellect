using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface IFlowProcedureInfoRepository : IRepository<Flow_Procedure>
    {
        //根据流程主键id查询
        Flow_Procedure GetInfoByProcedureId(int id);
        //批量删除
        int DeleteByProcedureList(List<int> IdList);
        /// 根据条件流程信息
        List<Flow_Procedure> SearchInfoByProcedureWhere(FlowProcedureSearchViewModel  flowProcedureSearchViewModel);
        // 根据id查流程信息
        Flow_Procedure GetById(int id);

        //查询节点信息数量
        IQueryable<Flow_Procedure> GetProcedureAll(FlowProcedureSearchViewModel flowProcedureSearchViewModel);
    }
}
