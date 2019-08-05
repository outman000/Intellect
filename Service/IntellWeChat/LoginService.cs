using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IRepository.IntellWeChat;
using Dto.IService.IntellWeChat;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.WeChatViewModel.MiddleModel;
using ViewModel.WeChatViewModel.RequestViewModel;

namespace Dto.Service.IntellWeChat
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _ILoginRepository;
        private readonly IUserInfoRepository _IUserInfoRepository;
        private readonly IUserRelateInfoRoleRepository _userRelateInfoRoleRepository;
        private readonly IUserRelateRoleRightRepository _userRelateRoleRightRepository;
        private readonly IMapper _IMapper;
       
        public LoginService(ILoginRepository  loginRepository,
                            IUserInfoRepository userInfoRepository,
                            IUserRelateInfoRoleRepository userRelateInfoRoleRepository,
                            IUserRelateRoleRightRepository userRelateRoleRightRepository,
                            IMapper mapper)
        {
                 _ILoginRepository = loginRepository;
                 _IUserInfoRepository = userInfoRepository;
                 _userRelateInfoRoleRepository = userRelateInfoRoleRepository;
            _userRelateRoleRightRepository = userRelateRoleRightRepository;
            _IMapper = mapper;
        }

        public WeChatIndexMiddlecs WeChatLogin_Search(WeChatInfoViewModel  weChatInfoViewModel)
        {
            WeChatIndexMiddlecs weChatIndexMiddlecs = new WeChatIndexMiddlecs();
            //用户权限集合
            List<User_Rights> user_Rights = new List<User_Rights>();
            //获取用户信息
            var user_info = _IUserInfoRepository.GetInfoAndDepartByUserid(weChatInfoViewModel.UserUid);
            //获取用户相关所有信息（部门，权限，角色等等）
            var user_Infos_All = _ILoginRepository.SearchInfoByWhere(weChatInfoViewModel.UserUid);
            //匹配相关信息
            weChatIndexMiddlecs = _IMapper.Map(user_info, weChatIndexMiddlecs);
            //建有层级关系的权限扁平化
            for (int i = 0; i < user_Infos_All.Count; i++)
            {
                int rightNum = user_Infos_All[i].User_Role.User_Relate_Role_Right.Count;
                for (int j = 0; j < rightNum; j++)
                {
                    //将外键变为空
                    var tempRights = user_Infos_All[i].User_Role.User_Relate_Role_Right[j].User_Rights;
                    user_Rights.Add(tempRights);
                }
            }
            weChatIndexMiddlecs.User_Rights = user_Rights;
            return weChatIndexMiddlecs;
        }
    }
}
