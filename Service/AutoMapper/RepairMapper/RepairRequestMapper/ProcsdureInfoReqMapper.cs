using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.AutoMapper.RepairMapper.RepairRequestMapper
{
    public class ProcsdureInfoReqMapper : Profile
    {

        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public ProcsdureInfoReqMapper()
        {
            CreateMap<FlowProcedureUpdateViewModel, Flow_Procedure>();
            CreateMap < Flow_Procedure, FlowProcedureSearchMiddlecs>();
        }
    }
}
