using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IRepository.IntellWeChat;
using Dto.IService.IntellWeChat;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public LoginService(ILoginRepository loginRepository,
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

        public WeChatIndexMiddlecs WeChatLogin_Search(WeChatInfoViewModel weChatInfoViewModel)
        {
            WeChatIndexMiddlecs weChatIndexMiddlecs = new WeChatIndexMiddlecs();
            //用户权限集合
            List<User_Rights> user_Rights = new List<User_Rights>();
            List<User_Rights> user_RightsQc = new List<User_Rights>();
            List<RightsParentSearchMiddlecs> right_chlid = new List<RightsParentSearchMiddlecs>();
           // List<RightsParentSearchMiddlecs> right_chlid2 = new List<RightsParentSearchMiddlecs>();
            List<RightsParentSearchMiddlecs> right_parent = new List<RightsParentSearchMiddlecs>();
            List<RightsParentSearchMiddlecs> result = new List<RightsParentSearchMiddlecs>();
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
           
            foreach (User_Rights user in user_Rights)//去重
            {
                if (user_RightsQc.Exists(x => x.Id == user.Id) == false)
                {
                    user_RightsQc.Add(user);
                }
            }
            var user_All= _IMapper.Map<List<User_Rights>, List<RightsParentSearchMiddlecs>>(user_RightsQc);
            result.AddRange(user_All.Where(p => p.ParentId == "0").ToList());//父节点集合
            result = result.OrderBy(x => x.Sort).ToList();//按照sort 字段排序
            foreach (var el in result)
            {
                AddPermission(user_All, el);
            }
            //right_parent= BianLi(user_All, right_chlid, right_parent, user_RightsQc);
         //weChatIndexMiddlecs.User_Rights = right_parent;
            weChatIndexMiddlecs.User_Rights = result;
            return weChatIndexMiddlecs;
        }

        /// <summary>
        /// 从某个根节点递归出其下所有子节点
        /// </summary>
        /// <param name="list">所有权限</param>
        /// <param name="curPermission">当前权限</param>
        public void AddPermission(List<RightsParentSearchMiddlecs> list, RightsParentSearchMiddlecs curPermission)
        {
            List<RightsParentSearchMiddlecs> sonPermissions = list.Where(p => p.ParentId==curPermission.Id.ToString()).ToList();
            if (sonPermissions.Count != 0)
            {
                sonPermissions = sonPermissions.OrderBy(x => x.Sort).ToList();//按照sort 字段排序
                curPermission.Children = sonPermissions;
            }
            foreach (var p in sonPermissions)
            {
                AddPermission(list, p);
            }
        }
        //private List<RightsParentSearchMiddlecs> BianLi(List<RightsParentSearchMiddlecs> user_All, 
        //                    List<RightsParentSearchMiddlecs> right_chlid, 
        //                    List<RightsParentSearchMiddlecs> right_parent,
        //                    List<User_Rights> user_Rights)
        //{
        //    for (int j = 0; j < user_Rights.Count; j++)
        //    {
        //        if (user_Rights[j].ParentId == "0")
        //        {
        //            right_parent.Add(user_All[j]);//遍历出所有父权限   
        //        }
        //        else
        //        {
        //            right_chlid.Add(user_All[j]);//遍历出所有子权限
        //        }
        //    }
        //    right_parent = right_parent.OrderBy(x => x.Sort).ToList();//按照sort 字段排序
        //    List<RightsParentSearchMiddlecs> right_chlid5 = new List<RightsParentSearchMiddlecs>();
        //    for (int n = 0; n < right_parent.Count; n++)//父权限
        //    {
        //        List<RightsParentSearchMiddlecs> right_chlid2 = new List<RightsParentSearchMiddlecs>();
        //        for (int z = 0; z < right_chlid.Count; z++)//子权限
        //        {
        //            if (right_chlid[z].ParentId == right_parent[n].Id.ToString())
        //            {
        //                right_chlid2.Add(right_chlid[z]);
        //                right_chlid5.Add(right_chlid[z]);
        //            }
                   
        //        }
        //        if (right_chlid2.Count != 0)
        //        {
                    
        //            right_parent[n].Children = right_chlid2.OrderBy(x => x.Sort).ToList();//按照sort 字段排序
        //        }
                   
        //    }
           
         
        //    if (right_chlid.Count!= right_chlid5.Count)//存在三级权限
        //    {
        //        List<RightsParentSearchMiddlecs> right_chlid3 = new List<RightsParentSearchMiddlecs>();
              
        //        right_chlid3 = Enumerable.Except(right_chlid.Union(right_chlid5), right_chlid.Intersect(right_chlid5)).ToList();
        //        for (int i = 0; i < right_parent.Count; i++)
        //        {
        //            if(right_parent[i].Children!=null)
        //            {
        //                for (int j = 0; j < right_parent[i].Children.Count; j++)
        //                {
        //                    List<RightsParentSearchMiddlecs> right_chlid4 = new List<RightsParentSearchMiddlecs>();
        //                    for (int z = 0; z < right_chlid3.Count; z++)
        //                    {
        //                        if (right_chlid3[z].ParentId == right_parent[i].Children[j].Id.ToString())
        //                        {
        //                            right_chlid4.Add(right_chlid3[z]);
        //                        }
        //                    }
        //                    if (right_chlid4.Count != 0)
        //                    {
                               
        //                        right_parent[i].Children[j].Children = right_chlid4.OrderBy(x => x.Sort).ToList();//按照sort字段排序
        //                    }    
        //                }
        //            }
                    
        //        }
        //    }

        //    return right_parent;

        //}

        public WeChatLoginMiddlecs WeChatLogin_User(WeChatLoginViewModel weChatLoginViewModel)
        {
            WeChatLoginMiddlecs weChatLoginMiddlecs = new WeChatLoginMiddlecs();
            var user_Infos = _ILoginRepository.ValideUserInfo(weChatLoginViewModel);

           var user_session=_IMapper.Map(user_Infos, weChatLoginMiddlecs);
            return user_session;
        }
    }
}
