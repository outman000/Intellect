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
    public class FlowNodeService : IFlowNodeService
    {
        private readonly IFlowNodeRepository _IFlowNodeRepository;

        private readonly IMapper _IMapper;

        public FlowNodeService(IFlowNodeRepository iflowNodeRepository,
                                        IMapper mapper)
        {
            _IFlowNodeRepository = iflowNodeRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 流转信息增加
        /// </summary>
        /// <param name="flowNodeAddViewModel"></param>
        /// <returns></returns>
        public int FlowNode_Add(FlowNodeAddViewModel flowNodeAddViewModel)
        {
            var node_Info = _IMapper.Map<FlowNodeAddViewModel, Flow_Node>(flowNodeAddViewModel);
            _IFlowNodeRepository.Add(node_Info);
            return _IFlowNodeRepository.SaveChanges();
        }
        /// <summary>
        /// 修改流转信息
        /// </summary>
        /// <param name="flowNodeUpdateViewModels"></param>
        /// <returns></returns>
        public int FlowNode_Update(FlowNodeUpdateViewModel flowNodeUpdateViewModel)
        {
            var node_Info = _IFlowNodeRepository.GetInfoByNodeId(flowNodeUpdateViewModel.Id);
            var node_Info_update = _IMapper.Map<FlowNodeUpdateViewModel, Flow_Node>(flowNodeUpdateViewModel, node_Info);
            _IFlowNodeRepository.Update(node_Info_update);
            return _IFlowNodeRepository.SaveChanges();
        }


        /// <summary>
        /// 删除流转信息
        /// </summary>
        /// <param name="flowNodeDelViewModel"></param>
        /// <returns></returns>
        public int Node_Delete(FlowNodeDelViewModel flowNodeDelViewModel)
        {
            int DeleteRowsNum = _IFlowNodeRepository
                   .DeleteByNodeIdList(flowNodeDelViewModel.DeleleIdList);
            if (DeleteRowsNum == flowNodeDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        public int Node_Get_ALLNum(FlowNodeSearchViewModel flowNodeSearchViewModel)
        {
            return _IFlowNodeRepository.GetNodeAll(flowNodeSearchViewModel).Count();
        }
        /// <summary>
        /// 查询流转信息（待办、已办）
        /// </summary>
        /// <param name="flowNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<FlowNodeSearchMiddlecs> Node_Search(FlowNodeSearchViewModel flowNodeSearchViewModel)
        {
            FlowNodeSearchMiddlecs nodeSearchs = new FlowNodeSearchMiddlecs();
            List<Flow_Node> node_Infos = _IFlowNodeRepository.SearchInfoByNodeWhere(flowNodeSearchViewModel);

            var nodeSearchMiddle = _IMapper.Map<List<Flow_Node>, List<FlowNodeSearchMiddlecs>>(node_Infos);

            return nodeSearchMiddle;
        }

        /// <summary>
        /// 根据表单ID获取拟稿人手机号
        /// </summary>
        /// <param name="flowNodeByRepairIdSearchViewModel"></param>
        /// <returns></returns>
        public string Phone_SearchByRepair_InfoId(FlowNodeByRepairIdSearchViewModel  flowNodeByRepairIdSearchViewModel)
        {
   
            List<Flow_Node> node_Infos = _IFlowNodeRepository.SearchInfoByRepariIdWhere(flowNodeByRepairIdSearchViewModel);
            string phone = "无手机号";
            for(int i=0;i< node_Infos.Count;i++)
            {
                if(node_Infos[i].Parent_Flow_NodeDefine!=null && node_Infos[i].Parent_Flow_NodeDefine.NodeType=="开始类型")
                {
                    phone = node_Infos[i].User_Info.PhoneCall;
                    break;
                }
            }

            return phone;
        }
    }
}
