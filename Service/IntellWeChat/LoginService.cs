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
using RestSharp;
using Microsoft.Extensions.Options;

namespace Dto.Service.IntellWeChat
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _ILoginRepository;
        private readonly IUserInfoRepository _IUserInfoRepository;
        private readonly IUserRelateInfoRoleRepository _userRelateInfoRoleRepository;
        private readonly IUserRelateRoleRightRepository _userRelateRoleRightRepository;
        private readonly IUserBindRepository _userBindRepository;
        private readonly IMapper _IMapper;
        private IntegralCommodityDate _IOptions { get; set; }
        public LoginService(ILoginRepository loginRepository,
                            IUserInfoRepository userInfoRepository,
                            IUserRelateInfoRoleRepository userRelateInfoRoleRepository,
                            IUserRelateRoleRightRepository userRelateRoleRightRepository,
                            IUserBindRepository userBindRepository,
                            IMapper mapper, IOptions<IntegralCommodityDate> settings)
        {
            _ILoginRepository = loginRepository;
            _IUserInfoRepository = userInfoRepository;
            _userRelateInfoRoleRepository = userRelateInfoRoleRepository;
            _userRelateRoleRightRepository = userRelateRoleRightRepository;
            _userBindRepository = userBindRepository;
            _IMapper = mapper;
            _IOptions = settings.Value;
        }
        /// <summary>
        /// 查询一个用户所拥有的权限
        /// </summary>
        /// <param name="weChatInfoViewModel"></param>
        /// <returns></returns>
        public WeChatIndexMiddlecs WeChatLogin_Search(WeChatInfoViewModel weChatInfoViewModel)
        {
            WeChatIndexMiddlecs weChatIndexMiddlecs = new WeChatIndexMiddlecs();
            weChatIndexMiddlecs.FoodStatus = "0";
            //用户权限集合
            List<User_Rights> user_Rights = new List<User_Rights>();
            List<User_Rights> user_RightsQc = new List<User_Rights>();
   
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

               if(user_Infos_All[i].User_Role.Id == 34)
               {
                    weChatIndexMiddlecs.FoodStatus = "3";
               }
               if (user_Infos_All[i].User_Role.Id == 35 && weChatIndexMiddlecs.FoodStatus != "3")
               {
                    weChatIndexMiddlecs.FoodStatus = "1";
               }
               if (user_Infos_All[i].User_Role.Id == 36 && weChatIndexMiddlecs.FoodStatus != "3")
               {
                    weChatIndexMiddlecs.FoodStatus = "2";
               }
                int rightNum = user_Infos_All[i].User_Role.User_Relate_Role_Right.Count;
                for (int j = 0; j < rightNum; j++)
                {
                    //将外键变为空
                    var tempRights = user_Infos_All[i].User_Role.User_Relate_Role_Right[j].User_Rights;
                   
                    user_Rights.Add(tempRights);
                }
               
            }
           
            foreach (User_Rights user in user_Rights)//去重(因为用户可能拥有多个角色，每个角色之间有重叠的权限)
            {
                if (user_RightsQc.Exists(x => x.Id == user.Id) == false)
                {
                    user_RightsQc.Add(user);
                }
            }
            var user_All= _IMapper.Map<List<User_Rights>, List<RightsParentSearchMiddlecs>>(user_RightsQc);//所有权限集合
            result.AddRange(user_All.Where(p => p.ParentId == "0").ToList());//父节点集合
            result = result.OrderBy(x => x.Sort).ToList();//按照sort 字段排序
            foreach (var el in result)
            {
                AddPermission(user_All, el);
            }

            //判断当前时间是否在工作时间段内
            DateTime _staDate = DateTime.Parse(_IOptions._staDate);//工作时间上午06:00
            DateTime _endDate = DateTime.Parse(_IOptions._endDate); //工作时间上午09:00
            DateTime now = DateTime.Now;
            if (now >= _staDate && now <= _endDate)
                weChatIndexMiddlecs.status = "0";//符合兑换时间段
            else
                weChatIndexMiddlecs.status = "1";//不符合兑换时间段
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

        /// <summary>
        /// 根据账号和密码查询用户信息（用于存储session）
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        public WeChatLoginMiddlecs WeChatLogin_User(WeChatLoginViewModel weChatLoginViewModel)
        {
            WeChatLoginMiddlecs weChatLoginMiddlecs = new WeChatLoginMiddlecs(); 
            var user_Infos = _ILoginRepository.ValideUserInfo(weChatLoginViewModel);
            var user_session = _IMapper.Map(user_Infos, weChatLoginMiddlecs);
            return user_session;
        }

        /// <summary>
        /// 根据账号和密码查询用户信息（用于存储session）
        /// </summary>
        /// <param name="weChatUpdateViewModel"></param>
        /// <returns></returns>
        public int WeChatLogin_User_Update(WeChatUpdateViewModel  weChatUpdateViewModel)
        {
       
            var user_Infos = _ILoginRepository.ValideNewUserInfo(weChatUpdateViewModel);
            if (user_Infos.Count == 0)
                return 0;
            else
            {

                var user_Info = _IUserInfoRepository.GetInfoByUserid(user_Infos[0].Id);
                user_Info.UserPwd = weChatUpdateViewModel.NewUserPwd;
                _IUserInfoRepository.Update(user_Info);
                _IUserInfoRepository.SaveChanges();
                return 1;

            }
         
        }



        /// <summary>
        /// 根据账号和密码查询用户信息（用于存储session）
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        public List<UserBind> UserBindSearch(string openid)
        {

            var user_Bind = _userBindRepository.GetoUserBindStr(openid);

            return user_Bind;
        }
        /// <summary>
        /// 根据账号和密码查询用户信息（用于存储session）
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        public List<UserBind> UserBindSearch2(string userId)
        {

            var user_Bind = _userBindRepository.GetoUserBindStr2(userId);

            return user_Bind;
        }

        /// <summary>
        /// 根据账号和密码查询用户信息（用于存储session）
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        public User_Info Searchpwd(string userId)
        {

            var user_Bind = _IUserInfoRepository.GetPwd(userId);

            return user_Bind;
        }

        public int AddUserBind(string openid, string userId, string passWord)
        {
            int result = 0;
            UserBind model = new UserBind();
            model.ID = Guid.NewGuid().ToString();
            model.OpenId = openid;
            model.userId = userId;
            model.passWord = passWord;
            model.CreateUser = openid;
            model.CreateTime = DateTime.Now;
            model.UpdateUser = openid;
            model.UpdateTime = DateTime.Now;
            model.isDelete = "0";
   
            _userBindRepository.Add(model);
            return _userBindRepository.SaveChanges();
            
        }



        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SmsMessage(string phone, string message)
        {
            var client = new RestClient("http://swj.dongjiang.gov.cn/TestSMS/SmsOutNetwork.asmx/SendMessage");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("phone", phone);
            request.AddParameter("content", message);
            IRestResponse response = client.Execute(request);
            return response.StatusCode.ToString();
        }


   


    }
}
