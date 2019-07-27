using AutoMapper;
using Dto.IRepository.IntellRepair;
using Dto.IService.IntellRepair;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.IntellRepair
{
    public class FlowProcedureInfoService : IFlowProcedureInfoService
    {
        private readonly IFlowProcedureInfoRepository _IFlowProcedureInfoRepository;
        private readonly IMapper _IMapper;

        public FlowProcedureInfoService(IFlowProcedureInfoRepository iflowProcedureInfoRepository,              
                                          IMapper mapper)
        {
            _IFlowProcedureInfoRepository = iflowProcedureInfoRepository;
            _IMapper = mapper;
        }

      /// <summary>
      /// 流程增加
      /// </summary>
      /// <param name="flowProcedureAddViewModel"></param>
      /// <returns></returns>
        public int Procedure_Add(FlowProcedureAddViewModel flowProcedureAddViewModel)
        {
            var procedure_Info = _IMapper.Map<FlowProcedureAddViewModel, Flow_Procedure>(flowProcedureAddViewModel);
            _IFlowProcedureInfoRepository.Add(procedure_Info);
            return _IFlowProcedureInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 流程删除
        /// </summary>
        /// <param name="flowProcedureDelViewModel"></param>
        /// <returns></returns>
        public int Procedure_Delete(FlowProcedureDelViewModel flowProcedureDelViewModel)
        {
            int DeleteRowsNum = _IFlowProcedureInfoRepository
                   .DeleteByProcedureList(flowProcedureDelViewModel.DeleleIdList);
            if (DeleteRowsNum == flowProcedureDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        public int Procedure_Get_ALLNum(FlowProcedureSearchViewModel flowProcedureSearchViewModel)
        {
            return _IFlowProcedureInfoRepository.GetProcedureAll(flowProcedureSearchViewModel).Count();
        }

        /// <summary>
        /// 查询流程
        /// </summary>
        /// <param name="flowProcedureAddViewModel"></param>
        /// <returns></returns>
        public List<FlowProcedureSearchMiddlecs> Procedure_Search(FlowProcedureSearchViewModel flowProcedureAddViewModel)
        {
            List<Flow_Procedure> user_Departs = _IFlowProcedureInfoRepository.SearchInfoByProcedureWhere(flowProcedureAddViewModel);

            List<FlowProcedureSearchMiddlecs> departSearches = new List<FlowProcedureSearchMiddlecs>();

            foreach (var item in user_Departs)
            {
                var DeaprtSearchMiddlecs = _IMapper.Map<Flow_Procedure, FlowProcedureSearchMiddlecs>(item);
                departSearches.Add(DeaprtSearchMiddlecs);

            }
            return departSearches;
        }
        /// <summary>
        /// 更新流程
        /// </summary>
        /// <param name="flowProcedureUpdateViewModel"></param>
        /// <returns></returns>
        public int Procedure_Update(FlowProcedureUpdateViewModel flowProcedureUpdateViewModel)
        {
            var procedure_Info = _IFlowProcedureInfoRepository.GetInfoByProcedureId(flowProcedureUpdateViewModel.Id);
            var procedure_Info_update = _IMapper.Map<FlowProcedureUpdateViewModel, Flow_Procedure>(flowProcedureUpdateViewModel, procedure_Info);
            _IFlowProcedureInfoRepository.Update(procedure_Info_update);
            return _IFlowProcedureInfoRepository.SaveChanges();
        }
    }
}
