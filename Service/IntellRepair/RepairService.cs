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
    public class RepairService : IRepairService
    {
        private readonly IRepairInfoRepository _IRepairInfoRepository;
        private readonly IFlowProcedureInfoRepository _IFlowProcedureInfoRepository;
        private readonly IFlowNodeDefineInfoRepository _IFlowNodeDefineInfoRepository;
        private readonly IMapper _IMapper;

        public RepairService(IRepairInfoRepository irepairInfoRepository, 
                             IFlowProcedureInfoRepository iflowProcedureInfoRepository,
                             IFlowNodeDefineInfoRepository iflowNodeDefineInfoRepository,
                             IMapper mapper)
        {
            _IRepairInfoRepository = irepairInfoRepository;
            _IFlowProcedureInfoRepository = iflowProcedureInfoRepository;
            _IFlowNodeDefineInfoRepository = iflowNodeDefineInfoRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 报修表单查询
        /// </summary>
        /// <param name="repairInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<RepairInfoSearchMiddlecs> Repair_Search(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            RepairInfoSearchMiddlecs repairSearches = new RepairInfoSearchMiddlecs();
            List<Repair_Info> line_Infos = _IRepairInfoRepository.SearchInfoByRepairWhere(repairInfoSearchViewModel).ToList();

            var repairSearchMiddlecs = _IMapper.Map< List<Repair_Info>, List<RepairInfoSearchMiddlecs>>(line_Infos);
             
            return repairSearchMiddlecs;
        }

        /// <summary>
        /// 添加报修表单
        /// </summary>
        /// <param name="repairAddViewModel"></param>
        /// <returns>返回主键id</returns>
        public WorkFlowFistReturnIdList Repair_Add(RepairAddViewModel repairAddViewModel,int Flow_ProcedureDefineId)
        {
            //存入表单信息
            var repair_Info = _IMapper.Map<RepairAddViewModel, Repair_Info>(repairAddViewModel);
            _IRepairInfoRepository.Add(repair_Info);
            _IRepairInfoRepository.SaveChanges();

            //存入流程信息（只有在开始节点的时候才会存入一条数据）
            var flowProcedureAddViewModel = _IMapper.Map<Repair_Info, FlowProcedureAddViewModel>(repair_Info);
            var procedure_Info = _IMapper.Map<FlowProcedureAddViewModel, Flow_Procedure>(flowProcedureAddViewModel);
            procedure_Info.remark = "1";//流程开始
            _IFlowProcedureInfoRepository.Add(procedure_Info);
            _IFlowProcedureInfoRepository.SaveChanges();

            //通过流程定义Id去查开始节点的主键id
           var ProcedureDefine= _IFlowNodeDefineInfoRepository.GetInfoByProcedureDefineId(Flow_ProcedureDefineId);
           int FirstNodeId=ProcedureDefine.Id;
            //返回三个Id
            WorkFlowFistReturnIdList workFlowFistReturnIdList = new WorkFlowFistReturnIdList();
            workFlowFistReturnIdList.Repair_InfoId = repair_Info.id;//表单主键Id
            workFlowFistReturnIdList.RepairType = repair_Info.RepairsType;//填写的类型与角色类相对应
            workFlowFistReturnIdList.User_InfoId = repair_Info.User_InfoId;//填写表单的用户Id
            workFlowFistReturnIdList.Flow_ProcedureId = procedure_Info.Id;//流程Id
            workFlowFistReturnIdList.Flow_NodeDefineId = FirstNodeId;//该流程第一个节点Id
            return workFlowFistReturnIdList;
        }

        /// <summary>
        /// 删除报修表单（一个或者多个）
        /// </summary>
        /// <param name="repairDelViewModel"></param>
        /// <returns></returns>
        public int Repair_Delete(RepairDelViewModel repairDelViewModel)
        {
            int DeleteRowsNum = _IRepairInfoRepository
                 .DeleteByRepairIdList(repairDelViewModel.DeleleIdList);
            if (DeleteRowsNum == repairDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 报修表单更新
        /// </summary>
        /// <param name="repairUpdateViewModel"></param>
        /// <returns></returns>
        public int Repair_Update(RepairUpdateViewModel repairUpdateViewModel)
        {
            var repair_Info = _IRepairInfoRepository.GetInfoByRepairId(repairUpdateViewModel.id);
            var repair_Info_update = _IMapper.Map<RepairUpdateViewModel, Repair_Info>(repairUpdateViewModel, repair_Info);
            _IRepairInfoRepository.Update(repair_Info_update);
            return _IRepairInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 查询报修数量
        /// </summary>
        /// <param name="repairInfoSearchViewModel"></param>
        /// <returns></returns>
        public int Repair_Get_ALLNum(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            return _IRepairInfoRepository.GetInfoByRepairAll(repairInfoSearchViewModel).Count();
        }
    }
}
