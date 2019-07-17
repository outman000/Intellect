using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.IntellUser
{
   public class RightsService : IRightsService
    {
        private readonly IUserRightsRepository _IUserRightsRepository;
        private readonly IMapper _IMapper;
        private readonly IUserRelateRoleRightRepository _userRelateRoleRightRepository;
        public RightsService(IUserRightsRepository iuserRightsRepository, 
                IUserRelateRoleRightRepository userRelateRoleRightRepository, 
                                    IMapper mapper)
        {
            _IUserRightsRepository = iuserRightsRepository;
            _userRelateRoleRightRepository = userRelateRoleRightRepository;
            _IMapper = mapper;
        }
        //添加权限
        public int Rights_Add(RightsAddViewModel rightsAddViewModel)
        {

            var user_Rights = _IMapper.Map<RightsAddViewModel, User_Rights>(rightsAddViewModel);
            _IUserRightsRepository.Add(user_Rights);
            return _IUserRightsRepository.SaveChanges();
        }
        // //删除权限（一个或者多个）
        public int Rights_Delete(RightsDeleteViewModel rightsDeleteViewModel)
        {
            int DeleteRowsNum = _IUserRightsRepository
                .DeleteByRightsidList(rightsDeleteViewModel.DeleleIdList);
            if (DeleteRowsNum == rightsDeleteViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        public int Rights_Get_ALLNum()
        {
            return _IUserRightsRepository.GetAll().Count();
        }

        //查询权限
        public List<RightsSearchMiddlecs> Rights_Search(RightsSearchViewModel rightsSearchViewModel)
        {
            List<User_Rights> user_Rights = _IUserRightsRepository.SearchRightsByWhere(rightsSearchViewModel);

            List<RightsSearchMiddlecs> rightsSearches = new List<RightsSearchMiddlecs>();

            foreach (var item in user_Rights)
            {
                var RightsSearchMiddlecs = _IMapper.Map<User_Rights, RightsSearchMiddlecs>(item);
                rightsSearches.Add(RightsSearchMiddlecs);

            }
            return rightsSearches;
        }



        //单一权限
        public bool Rights_Single(RightsValideRepeat rightsValideRepeat)
        {
            IQueryable<User_Rights> Queryable_UserRights = _IUserRightsRepository
                                                                .GetRightsByValue(rightsValideRepeat.RightsValue);
            return (Queryable_UserRights.Count() < 1) ?
                   true : false;
        }


        //更新权限信息
        public int Rights_Update(RightsUpdateViewModel rightsUpdateViewModel)
        {
            var user_Rights = _IMapper.Map<RightsUpdateViewModel, User_Rights>(rightsUpdateViewModel);
            _IUserRightsRepository.Update(user_Rights);
            return _IUserRightsRepository.SaveChanges();
        }
        //根据角色查询权限
        public List<RightsSearchMiddlecs> Rights_By_Role_Search(RightsByRoleSearchViewModel rightsByRoleSearchViewModel)
        {
            List<User_Relate_Role_Right> user_Relate_Right_Roles = _userRelateRoleRightRepository.SearchRightsInfoByRoleWhere(rightsByRoleSearchViewModel);
            List<RightsSearchMiddlecs> user_rights = new List<RightsSearchMiddlecs>();

            foreach (var item in user_Relate_Right_Roles)
            {
                var user_rights_temp = _IMapper.Map<User_Rights, RightsSearchMiddlecs>(item.User_Rights);
                user_rights.Add(user_rights_temp);
            }
            return user_rights;

        }

      
    }
}
