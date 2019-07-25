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
    public class FlowProcedureDefineService : IFlowProcedureDefineService
    {
        private readonly IFlowProcedureDefineRepository _IFlowProcedureDefineRepository;
        private readonly IMapper _IMapper;

        public FlowProcedureDefineService(IFlowProcedureDefineRepository ifFlowProcedureDefineRepository,
                                        IMapper mapper)
        {
            _IFlowProcedureDefineRepository = ifFlowProcedureDefineRepository;
            _IMapper = mapper;
        }
        /// <summary>
        /// 流程定义增加
        /// </summary>
        /// <param name="flowProcedureDefineAddViewModel"></param>
        /// <returns></returns>
        public int ProcedureDefine_Add(FlowProcedureDefineAddViewModel flowProcedureDefineAddViewModel)
        {
            var procedure_Info = _IMapper.Map<FlowProcedureDefineAddViewModel, Flow_ProcedureDefine>(flowProcedureDefineAddViewModel);
            _IFlowProcedureDefineRepository.Add(procedure_Info);
            return _IFlowProcedureDefineRepository.SaveChanges();
        }

        /// <summary>
        /// 删除流程定义
        /// </summary>
        /// <param name="flowProcedureDefineDelViewModel"></param>
        /// <returns></returns>
        public int ProcedureDefine_Delete(FlowProcedureDefineDelViewModel flowProcedureDefineDelViewModel)
        {
            int DeleteRowsNum = _IFlowProcedureDefineRepository
                    .DeleteByProcedureDefineIdList(flowProcedureDefineDelViewModel.DeleleIdList);
            if (DeleteRowsNum == flowProcedureDefineDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 根据条件查流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineSearchViewModel"></param>
        /// <returns></returns>
        public List<FlowProcedureDefineSearchMiddlecs> ProcedureDefine_Search(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel)
        {
            List<Flow_ProcedureDefine> procedureDefine = _IFlowProcedureDefineRepository.SearchInfoByProcedureDefineWhere(flowProcedureDefineSearchViewModel);

            List<FlowProcedureDefineSearchMiddlecs> procedureSearchList = new List<FlowProcedureDefineSearchMiddlecs>();

            foreach (var item in procedureDefine)
            {
                var procedureDefineSearChMiddles = _IMapper.Map<Flow_ProcedureDefine, FlowProcedureDefineSearchMiddlecs>(item);
                procedureSearchList.Add(procedureDefineSearChMiddles);

            }
            return procedureSearchList;
        }
        /// <summary>
        /// 验证流程的唯一性
        /// </summary>
        /// <param name="flowProcedureDefineSingleViewModel"></param>
        /// <returns></returns>
        public bool ProcedureDefine_Single(FlowProcedureDefineSingleViewModel flowProcedureDefineSingleViewModel)
        {
            IQueryable<Flow_ProcedureDefine> Queryable_UserInfo = _IFlowProcedureDefineRepository
                                                      .GetInfoByProcedureDefineId(flowProcedureDefineSingleViewModel.ProcedureCode);
            return (Queryable_UserInfo.Count() < 1) ?
                   true : false;
        }

        /// <summary>
        /// 更新流程定义
        /// </summary>
        /// <param name="flowProcedureDefineUpdateViewModel"></param>
        /// <returns></returns>
        public int ProcedureDefine_Update(FlowProcedureDefineUpdateViewModel flowProcedureDefineUpdateViewModel)
        {
            var procedure_Info = _IFlowProcedureDefineRepository.GetInfoByProcedureDefineId(flowProcedureDefineUpdateViewModel.Id);
            var procedure_Info_update = _IMapper.Map<FlowProcedureDefineUpdateViewModel, Flow_ProcedureDefine>(flowProcedureDefineUpdateViewModel, procedure_Info);
            _IFlowProcedureDefineRepository.Update(procedure_Info_update);
            return _IFlowProcedureDefineRepository.SaveChanges();
        }
    }
}
