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
        private readonly IUserRightsRepository userRightsRepository;
        private readonly IMapper _IMapper;

        public RoleService(IUserRoleRepository  userRoleRepository, IMapper mapper)
        {
            _IUserRoleRepository = userRoleRepository;
            _IMapper = mapper;
        }
        //给角色分配用户
        public int User_RoleToUser_Add(RelateRoleToUserAddViewModel relateRoleToUserAddViewModel)
        {
            //获取视图集合
            List<RelateRoleUserAddMiddles> relateUserIdandRoleIdList = relateRoleToUserAddViewModel.RelateUserIdandRoleIdList;
            //将视图模型和转为领域模型集合
            List<User_Relate_Info_Role> user_Relate_Role_Rights= _IMapper.Map<List<RelateRoleUserAddMiddles>, List<User_Relate_Info_Role>>(relateUserIdandRoleIdList);

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



    }
}
