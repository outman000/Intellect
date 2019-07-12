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
    public class UserService : IUserService
    {
        private readonly IUserInfoRepository _IUserInfoRepository;
        private readonly IMapper _IMapper;

        public UserService(IUserInfoRepository iuserInfoRepository,IMapper mapper)
        {
            _IUserInfoRepository = iuserInfoRepository;
            _IMapper = mapper;
        }

        //添加用户
        public int User_Add(UserAddViewModel userAddViewModel)
        {

            var user_Info  = _IMapper.Map<UserAddViewModel, User_Info>(userAddViewModel);
            _IUserInfoRepository.Add(user_Info);
            return _IUserInfoRepository.SaveChanges();
        }
        //单一用户
        public bool User_Single(UserValideRepeat userValideRepeat)
        {
            IQueryable<User_Info>  Queryable_UserInfo =_IUserInfoRepository
                                                        .GetInfoByUserid(userValideRepeat.UserId);
            return (Queryable_UserInfo.Count() < 1) ?
                   true : false;
        }
        //删除用户（一个或者多个）
        public int User_Delete(UserDeleteViewModel  userDeleteViewModel)
        {
           int DeleteRowsNum = _IUserInfoRepository
                .DeleteByUseridList(userDeleteViewModel.DeleleIdList);
            if (DeleteRowsNum == userDeleteViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }

        }
        //查询用户
        public List<UserSearchMiddlecs> User_Search(UserSearchViewModel  userSearchViewModel)
        {
            List<User_Info> user_Infos=_IUserInfoRepository.SearchInfoByWhere(userSearchViewModel);

            List<UserSearchMiddlecs> userSearches=new List<UserSearchMiddlecs>() ;

            foreach (var item in user_Infos)
            {
               var UserSearchMiddlecs= _IMapper.Map<User_Info, UserSearchMiddlecs>(item);
                userSearches.Add(UserSearchMiddlecs);

            }
            return userSearches;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userUpdateViewModel"></param>
        /// <returns></returns>
        public int User_Update(UserUpdateViewModel  userUpdateViewModel)
        {
            var user_Info = _IMapper.Map<UserUpdateViewModel, User_Info>(userUpdateViewModel);
            _IUserInfoRepository.Update(user_Info);
            return _IUserInfoRepository.SaveChanges();
        }

      
    }
}
