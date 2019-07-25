using AutoMapper;
using Dtol.dtol;

using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class ProcedureDefineReqMapper : Profile
    {

        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public ProcedureDefineReqMapper()
        {
            CreateMap<Flow_ProcedureDefine, FlowProcedureDefineSearchMiddlecs>();
            CreateMap<FlowProcedureDefineUpdateViewModel, Flow_ProcedureDefine >();
            CreateMap<FlowProcedureDefineAddViewModel, Flow_ProcedureDefine > ();
        }
    }
}
