using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.dtol;
using System.Collections.Generic;
using System.Linq;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.IntellUser
{
    public class RoleService : IRoleService
    {
        private readonly IUserRoleRepository _IUserRoleRepository;
        private readonly IUserRelateInfoRoleRepository  _userRelateInfoRoleRepository;
        private readonly IUserRightsRepository _userRightsRepository;
        private readonly IMapper _IMapper;
        private readonly IUserRelateRoleRightRepository _userRelateRoleRightRepository;

        public RoleService(IUserRoleRepository  userRoleRepository,
                           IUserRelateInfoRoleRepository userRelateInfoRoleRepository,
                           IUserRightsRepository userRightsRepository,
                           IUserRelateRoleRightRepository userRelateRoleRightRepository,
                           IMapper mapper)
        {
            _IUserRoleRepository = userRoleRepository;
            _userRelateInfoRoleRepository = userRelateInfoRoleRepository;
            _userRightsRepository = userRightsRepository;
            _userRelateRoleRightRepository=userRelateRoleRightRepository;
            _IMapper = mapper;
        }
        //给角色删除用户
        public int User_RoleToUser_Del(RelateRoleToUserDelViewModel relateRoleToUserDelViewModel)
        {


            int DelNum = _userRelateInfoRoleRepository
                       .RelateRoleToUserDel(relateRoleToUserDelViewModel.RelateUserIdandRoleIdList);

            return DelNum;
        }

        //给角色分配用户/给用户分配角色
        public int User_RoleToUser_Add(RelateRoleToUserAddViewModel relateRoleToUserAddViewModel)
        {
            //获取视图集合
            List<RelateRoleUserAddMiddlecs> relateUserIdandRoleIdList = relateRoleToUserAddViewModel.RelateUserIdandRoleIdList;
            //将视图模型和转为领域模型集合
            List<User_Relate_Info_Role> user_Relate_Role_Rights= _IMapper.Map<List<RelateRoleUserAddMiddlecs>, List<User_Relate_Info_Role>>(relateUserIdandRoleIdList);

            int AddNum= _userRelateInfoRoleRepository
                       .RelateRoleToUser(user_Relate_Role_Rights);

            return AddNum;
        }
  

        //添加角色
        public int User_Role_Add(UserRoleAddViewModel  userRoleAddViewModel)
        {
            var role_Info = _IMapper.Map<UserRoleAddViewModel, User_Role>(userRoleAddViewModel);
            _IUserRoleRepository.Add(role_Info);
            return _IUserRoleRepository.SaveChanges();
        }
        //角色删除
        public int User_Role_Delete(UserRoleDeleteViewModel userRoleDeleteViewModel)
        {
            int DeleteRowsNum = _IUserRoleRepository
                 .DeleteByRoleIdList(userRoleDeleteViewModel.DeleleIdList);
            if (DeleteRowsNum == userRoleDeleteViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }
        //角色查询
        public List<UserRoleSearChMiddles> User_Role_Search(UserRoleSearchViewModel userRoleSearchViewModel)
        {
            List<User_Role> user_Roles = _IUserRoleRepository.SearchRoleInfoByWhere(userRoleSearchViewModel);

            List<UserRoleSearChMiddles> userRoleSearchList = new List<UserRoleSearChMiddles>();

            foreach (var item in user_Roles)
            {
                var userRoleSearChMiddles = _IMapper.Map<User_Role, UserRoleSearChMiddles>(item);
                userRoleSearchList.Add(userRoleSearChMiddles);

            }
            return userRoleSearchList;
        }
        //验证唯一
        public bool User_Role_Single(UserRoleSingleViewModel userRoleSingleViewModel)
        {
            IQueryable<User_Role> Queryable_RoleInfo = _IUserRoleRepository
                                                        .GetInfoByRoleCode(userRoleSingleViewModel.RoleCode);
            return (Queryable_RoleInfo.Count() < 1) ?
                   true : false;
        }
        //更新角色
        public int User_Role_Update(UserRoleUpdateViewModel userRoleUpdateViewModel)
        {
            var userRole_Info = _IMapper.Map<UserRoleUpdateViewModel, User_Role>(userRoleUpdateViewModel);
            _IUserRoleRepository.Update(userRole_Info);
            return _IUserRoleRepository.SaveChanges();
        }
        //获取所有角色
        public int User_Role_GetAllNum()
        {
            return _userRelateInfoRoleRepository.GetAll().Count();
        }

        //给角色添加权限
        public int User_RoleToRights_Add(RelateRoleToRightAddViewModel relateRoleToRightAddViewModel)
        {
            //获取视图集合
            List<RelateRoleRightAddMiddlecs> relateRightIdandRoleIdList = relateRoleToRightAddViewModel.RelateRightIdandRoleIdList;
            //将视图模型和转为领域模型集合
            List<User_Relate_Role_Right> Relate_Role_Rights = _IMapper.Map<List<RelateRoleRightAddMiddlecs>, List<User_Relate_Role_Right>>(relateRightIdandRoleIdList);

            int AddNum = _userRelateRoleRightRepository
                       .RelateRoleToRightsAdd(Relate_Role_Rights);

            return AddNum;
        }

        //给角色删除权限
        public int User_RoleToRight_Del(RelateRoleToRightDelViewModel relateRoleToRightrDelViewModel)
        {


            int DelNum = _userRelateRoleRightRepository
                       .RelateRoleToRightsDel(relateRoleToRightrDelViewModel.RelateRightIdandRoleIdList);

            return DelNum;
        }
        //根据用户查询角色
        public List<UserRoleSearChMiddles> Role_By_User_Search(RoleByUserSearchViewModel roleByUserSearchViewModel)
        {
            List<User_Relate_Info_Role> user_Relate_Info_Roles = _userRelateInfoRoleRepository.SearchRoleInfoByWhere(roleByUserSearchViewModel);
            List<UserRoleSearChMiddles> user_roles = new List<UserRoleSearChMiddles>();
            
            foreach (var item in user_Relate_Info_Roles)
            {
               var user_role_temp=   _IMapper.Map<User_Role, UserRoleSearChMiddles>(item.User_Role);
                user_roles.Add(user_role_temp);
            }
            return user_roles;
        }

        //根据权限查询角色
        public List<UserRoleSearChMiddles> Role_By_Rights_Search(RoleByRightsSearchViewModel roleByRightsSearchViewModel)
        {
            List<User_Relate_Role_Right> user_Relate_Rights_Roles = _userRelateRoleRightRepository.SearchRoleInfoByRightsWhere(roleByRightsSearchViewModel);
            List<UserRoleSearChMiddles> user_roles = new List<UserRoleSearChMiddles>();

            foreach (var item in user_Relate_Rights_Roles)
            {
                var user_role_temp = _IMapper.Map<User_Role, UserRoleSearChMiddles>(item.User_Role);
                user_roles.Add(user_role_temp);
            }
            return user_roles;
        }
    }
}
