using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IRepository.IntellWeChat;
using Dto.IService.IntellWeChat;
using Dtol.dtol;
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

        public List<WeChatLoginMiddlecs> WeChatLogin_Search(WeChatLoginViewModel weChatLoginViewModel)
        {
            List<WeChatLoginMiddlecs> wlm = new List<WeChatLoginMiddlecs>();

            //查出用户id
            List<User_Info> user_Infos = _ILoginRepository.SearchInfoByWhere(weChatLoginViewModel);

            if (user_Infos.Count == 0)//没有该用户
            {
            
                return wlm;
            }
            var rb = _IMapper.Map<List<User_Info>, List< WeChatLoginMiddlecs> >(user_Infos, wlm);   
            var rb2 = _IMapper.Map<WeChatLoginMiddlecs, RoleByUserSearchViewModel >(rb[0]);
            rb2.pageViewModel.PageSize = 99999;
            rb2.pageViewModel.CurrentPageNum = 0;
            //查出角色id
            List<User_Relate_Info_Role> user_Relate_Info_Roles = _userRelateInfoRoleRepository.SearchRoleInfoByWhere(rb2);
            if (user_Relate_Info_Roles.Count == 0)//该用户没有角色
            {
                wlm[0].Id = 8888888;
                return wlm;
            }

            var rbsb = _IMapper.Map< List<User_Relate_Info_Role>, List<RightsByRoleSearchViewModel> >(user_Relate_Info_Roles);
            for(int i=0;i<rbsb.Count;i++)
            {
                rbsb[i].pageViewModel.PageSize = 9999;
                rbsb[i].pageViewModel.CurrentPageNum = 0;
            }

            //查出权限
            List<List<User_Relate_Role_Right>>  user_Relate_Right_Roles = new List<List<User_Relate_Role_Right>>();
            if (user_Relate_Right_Roles.Count == 0)//该用户没有权限
            {
                wlm[0].Id = 6666666;
                return wlm;
            }
            for (int j=0;j< rbsb.Count;j++ )
            {
               var a = _userRelateRoleRightRepository.SearchRightsInfoByRoleWhere(rbsb[j]);
               user_Relate_Right_Roles.Add(a);
            }
          

            List<RightsSearchMiddlecs> user_rights = new List<RightsSearchMiddlecs>();
            for(int n=0;n< user_Relate_Right_Roles.Count; n++)
            {
                for (int z = 0; z < user_Relate_Right_Roles[n].Count; z++)
                {
                    var user_rights_temp = _IMapper.Map<User_Rights, RightsSearchMiddlecs>(user_Relate_Right_Roles[n][z].User_Rights);
                    user_rights.Add(user_rights_temp);
                }
            }

            //WeChatLoginMiddlecs 列表长度取决于 角色*权限 个数
            _IMapper.Map<List<RightsSearchMiddlecs>, List<WeChatLoginMiddlecs>>(user_rights, wlm);
            for (int n = 0; n < user_rights.Count; n++)
            {
                var fh = _IMapper.Map<User_Info, WeChatLoginMiddlecs>(user_Infos[0], wlm[n]);
            }
          
            return wlm;
        }
    }
}
