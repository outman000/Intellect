using AutoMapper;
using Dto.IRepository.IntellRepair;
using Dto.IRepository.IntellUser;
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
    public class WorkFlowService : IWorkFlowService
    {
        private readonly IFlowNodeDefineInfoRepository _IFlowNodeDefineInfoRepository;

        private readonly IRelateRoleByNodeRepository _IRelateRoleByNodeRepository;
        private readonly IUserRelateInfoRoleRepository _IUserRelateInfoRoleRepository;
      private readonly IMapper _IMapper;

        public WorkFlowService(IFlowNodeDefineInfoRepository flowNodeDefineInfoRepository,
                               IRelateRoleByNodeRepository relateRoleByNodeRepository,
                               IUserRelateInfoRoleRepository userRelateInfoRoleRepository,
                               IMapper mapper)
        {
                _IFlowNodeDefineInfoRepository = flowNodeDefineInfoRepository;
                _IRelateRoleByNodeRepository = relateRoleByNodeRepository;
                _IUserRelateInfoRoleRepository = userRelateInfoRoleRepository;
                _IMapper = mapper;
        }


        /// <summary>
        /// 根据节点查用户列表
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<UserSearchMiddlecs> User_By_Node_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            List<Flow_Relate_NodeRole> node_Relate_Info_Roles = _IRelateRoleByNodeRepository.SearchRoleInfoByWhere(roleByNodeSearchViewModel);
            List<int> RoleList = new List<int>();
            for(int i=0;i< node_Relate_Info_Roles.Count;i++)
            {
                int User_RoleId = node_Relate_Info_Roles[i].User_RoleId;
                RoleList.Add(User_RoleId);

            }
          
            List<User_Info> user_Relate_Info_Users = _IUserRelateInfoRoleRepository.SearchUserInfoByListWhere(RoleList);
            var userLsit_Info = _IMapper.Map<List<User_Info>, List<UserSearchMiddlecs>>(user_Relate_Info_Users);

            return userLsit_Info;
        }
      
        
    }
}
