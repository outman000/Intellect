using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.IRepository.IntellRepair
{
    public interface IFlowProcedureDefineRepository : IRepository<Flow_ProcedureDefine>
    {
        //根据流程主键id查询
        IQueryable<Flow_ProcedureDefine> GetInfoByProcedureDefineId(string ProcedureCode);
        //批量删除
        int DeleteByProcedureDefineIdList(List<int> IdList);
        Flow_ProcedureDefine GetById(int id);
        //根据条件查流程信息
        List<Flow_ProcedureDefine> SearchInfoByProcedureDefineWhere(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel);
        // 根据id查流程信息
        Flow_ProcedureDefine GetInfoByProcedureDefineId(int id);
        //查询流程信息数量
        IQueryable<Flow_ProcedureDefine> GetProcedureDefineAll(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel);
    }
}
