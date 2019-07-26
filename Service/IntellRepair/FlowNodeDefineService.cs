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
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.Service.IntellRepair
{
    public class FlowNodeDefineService : IFlowNodeDefineService
    {
        private readonly IFlowNodeDefineInfoRepository _IFlowNodeDefineInfoRepository;
        private readonly IRelateRoleByNodeRepository _IRelateRoleByNodeRepository;
        private readonly IMapper _IMapper;

        public FlowNodeDefineService(IFlowNodeDefineInfoRepository iflowNodeDefineInfoRepository,
                                        IRelateRoleByNodeRepository irelateRoleByNodeRepository,
                                        IMapper mapper)
        {
            _IFlowNodeDefineInfoRepository = iflowNodeDefineInfoRepository;
            _IRelateRoleByNodeRepository = irelateRoleByNodeRepository;
            _IMapper = mapper;
        }

      

        /// <summary>
        /// 节点定义查询
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        public List<FlowNodeDefineSearchMiddlecs> NodeDefine_Search(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            FlowNodeDefineSearchMiddlecs nodeDefineSearches = new FlowNodeDefineSearchMiddlecs();
            List<Flow_NodeDefine> nodeDefine_Infos = _IFlowNodeDefineInfoRepository.SearchInfoByNodeDefineWhere(flowNodeDefineSearchViewModel).ToList();

            var repairSearchMiddlecs = _IMapper.Map<List<Flow_NodeDefine>, List<FlowNodeDefineSearchMiddlecs>>(nodeDefine_Infos);

            return repairSearchMiddlecs;
        }
        /// <summary>
        /// 节点定义增加
        /// </summary>
        /// <param name="flowNodeDefineAddViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Add(FlowNodeDefineAddViewModel flowNodeDefineAddViewModel)
        {
            var node_Info = _IMapper.Map<FlowNodeDefineAddViewModel, Flow_NodeDefine>(flowNodeDefineAddViewModel);
            _IFlowNodeDefineInfoRepository.Add(node_Info);
            return _IFlowNodeDefineInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 删除节点定义
        /// </summary>
        /// <param name="flowNodeDefineDelViewModel"></param>
        /// <returns></returns>
        public int NodeDefiner_Delete(FlowNodeDefineDelViewModel flowNodeDefineDelViewModel)
        {
            int DeleteRowsNum = _IFlowNodeDefineInfoRepository
                  .DeleteByNodeDefineIdList(flowNodeDefineDelViewModel.DeleleIdList);
            if (DeleteRowsNum == flowNodeDefineDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 节点定义更新
        /// </summary>
        /// <param name="flowNodeDefineUpdateViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Update(FlowNodeDefineUpdateViewModel flowNodeDefineUpdateViewModel)
        {
            var node_Info = _IFlowNodeDefineInfoRepository.GetInfoByNodeDefineId(flowNodeDefineUpdateViewModel.Id);
            var node_Info_update = _IMapper.Map<FlowNodeDefineUpdateViewModel, Flow_NodeDefine>(flowNodeDefineUpdateViewModel, node_Info);
            _IFlowNodeDefineInfoRepository.Update(node_Info_update);
            return _IFlowNodeDefineInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 给节点分配角色 
        /// </summary>
        /// <param name="relateRoleByNodeAddViewModel"></param>
        /// <returns></returns>

        public int NodeDefine_RoleToNode_Add(RelateRoleByNodeAddViewModel relateRoleByNodeAddViewModel)
        {

            //获取视图集合
            List<RelateRoleByNodeAddModelcs> relateNodeIdandRoleIdList = relateRoleByNodeAddViewModel.RelateRoleIdandNodeIdList;
            //将视图模型和转为领域模型集合
            List<Flow_Relate_NodeRole> node_Relate_Role = _IMapper.Map<List<RelateRoleByNodeAddModelcs>, List<Flow_Relate_NodeRole>>(relateNodeIdandRoleIdList);

            int AddNum = _IRelateRoleByNodeRepository
                       .RelateNodeToRoleAdd(node_Relate_Role);

            return AddNum;
        }
        /// <summary>
        /// 给节点删除角色
        /// </summary>
        /// <param name="relateRoleByNodeDelViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_RoleToNode_Del(RelateRoleByNodeDelViewModel relateRoleByNodeDelViewModel)
        {

            int DelNum = _IRelateRoleByNodeRepository
                       .RelateNodeToRoleDel(relateRoleByNodeDelViewModel.RelateNodeIdandRoleIdList);

            return DelNum;
        }
        /// <summary>
        /// 根据节点查角色
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<UserRoleSearChMiddles> Role_By_Node_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            List<Flow_Relate_NodeRole> node_Relate_Info_Roles = _IRelateRoleByNodeRepository.SearchRoleInfoByWhere(roleByNodeSearchViewModel);
            List<UserRoleSearChMiddles> user_roles = new List<UserRoleSearChMiddles>();

            foreach (var item in node_Relate_Info_Roles)
            {
                var user_role_temp = _IMapper.Map<User_Role, UserRoleSearChMiddles>(item.User_Role);
                user_roles.Add(user_role_temp);
            }
            return user_roles;
        }
        /// <summary>
        /// 查询节点定义数量
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        public int NodeDefine_Get_ALLNum(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            return _IFlowNodeDefineInfoRepository.GetNodeDefineAll(flowNodeDefineSearchViewModel).Count();
        }

        /// <summary>
        /// 根据节点查角色数量
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public int Role_By_Node_Get_ALLNum(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            return _IRelateRoleByNodeRepository.Role_By_Node_Get_ALLNum(roleByNodeSearchViewModel).Count();
        }
    }
    
}
