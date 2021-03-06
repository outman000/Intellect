﻿using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.Attribute;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using Dapper;

namespace Dto.Service.IntellUser
{
    public class UserService : IUserService
    {
        private readonly IUserInfoRepository _IUserInfoRepository;
        private readonly IMapper _IMapper;
        private readonly IUserRelateInfoRoleRepository _userRelateInfoRoleRepository;
        private readonly IUserIntegralRepository _userIntegralRepository;
        private readonly IUserRegisterRepository _userRegisterRepository;
    //    private string _connectionString = string.Empty;
        private UserIntegralDate _IOptions { get; set; }
        NPOIClass EP_Plus = new NPOIClass();

        public UserService(IUserInfoRepository iuserInfoRepository, IUserRelateInfoRoleRepository userRelateInfoRoleRepository,
                           IUserIntegralRepository userIntegralRepository, IUserRegisterRepository userRegisterRepository, IMapper mapper, 
                           IOptions<UserIntegralDate> settings)
        {
            _IUserInfoRepository = iuserInfoRepository;
            _userRelateInfoRoleRepository = userRelateInfoRoleRepository;
            _userIntegralRepository = userIntegralRepository;
            _userRegisterRepository = userRegisterRepository;
            _IMapper = mapper;
            _IOptions = settings.Value;
        
        }

        //public UserService(string constr)
        //{
        //    _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        //}

        //添加用户
        public int User_Add(UserAddViewModel userAddViewModel)
        {

            var user_Info = _IMapper.Map<UserAddViewModel, User_Info>(userAddViewModel);
            _IUserInfoRepository.Add(user_Info);
            return _IUserInfoRepository.SaveChanges();
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="userRegisterViewModel"></param>
        /// <returns></returns>
        public int User_Register(UserRegisterViewModel userRegisterViewModel)
        {
            var client = new RestClient("https://dztxz.dongjiang.gov.cn/ET_CompanyApi/api/PersonInfo/Manage/PersonInfo/IsExistIdCard?idCard=" + userRegisterViewModel.Idcard);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.Content == "true")//注册过电子通行证
            {
                if (CheckIdcard(userRegisterViewModel.Idcard))//有智慧后勤身份证信息
                {
                    var result = SearchByIdcard(userRegisterViewModel.Idcard);

                    if (result[0].UserId != null && result[0].UserId != "")
                    {
                        return 2;//注册过电子通行证并且智慧后勤也已经有身份信息
                    }                 
                    else
                    {
                            var UserRegisterMiddle = _IMapper.Map<UserRegisterViewModel, UserRegisterMiddle>(userRegisterViewModel);
                            var user_Info = _IMapper.Map<UserRegisterMiddle, User_Info>(UserRegisterMiddle, result[0]);
                            user_Info.updateDate = DateTime.Now;
                            _IUserInfoRepository.Update(user_Info);
                            _IUserInfoRepository.SaveChanges();
                            return 0;
                      
                    }
                }
                else
                {                   
                        var user_Info = _IMapper.Map<UserRegisterViewModel, User_Register>(userRegisterViewModel);//加入注册表
                        user_Info.AddDate = DateTime.Now;
                        user_Info.updateDate = DateTime.Now;
                        user_Info.status = "1";//待审核
                        user_Info.createUser = user_Info.UserId;
                        user_Info.updateUser = user_Info.UserId;
                        _IUserInfoRepository.Add3(user_Info);
                        _IUserInfoRepository.SaveChanges();
                        return 0;
               
                }

            }
            else//未注册过电子通行证
            {
                return 1;
            }
        }


        //单一用户
        public bool User_Single(UserValideRepeat userValideRepeat)
        {
            IQueryable<User_Info> Queryable_UserInfo = _IUserInfoRepository
                                                        .GetInfoByUserid(userValideRepeat.UserId);
            return (Queryable_UserInfo.Count() < 1) ?
                   true : false;
        }
        public User_Info User_Single_Search(UserSearchByUserIdViewModel userSearchByUserIdViewModel)
        {
            User_Info Queryable_UserInfo = _IUserInfoRepository
                                                        .GetInfoByUserid(userSearchByUserIdViewModel.UserId);
            return Queryable_UserInfo;

        }
        //随机名称
        public string fileRandName(string fileRealname)
        {
            string RandName = "";
            string[] fileTail = fileRealname.Split('.');
            RandName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileTail[1];
            return RandName;
        }
        //导入文件并存入数据库（推荐目录）
        public int uploadTodatabase_User_Info(string filepath, string tableName, string tag)
        {
            var list = EP_Plus.ExcelToList<User_Info>(filepath, tag, tableName);
            _IUserInfoRepository.AddRange_User_Info(list);
            _IUserInfoRepository.SaveChanges();
            return list.Count;
        }

        //删除用户（一个或者多个）
        public int User_Delete(UserDeleteViewModel userDeleteViewModel)
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
        public List<UserSearchMiddlecs> User_Search(UserSearchViewModel userSearchViewModel)
        {
            List<User_Info> user_Infos = _IUserInfoRepository.SearchInfoByWhere(userSearchViewModel);

            List<UserSearchMiddlecs> userSearches = new List<UserSearchMiddlecs>();

            foreach (var item in user_Infos)
            {
                var UserSearchMiddlecs = _IMapper.Map<User_Info, UserSearchMiddlecs>(item);
                userSearches.Add(UserSearchMiddlecs);

            }
            return userSearches;
        }

        //更新用户
        public int User_Update(UserUpdateViewModel userUpdateViewModel)
        {
            var user_Info = _IUserInfoRepository.GetInfoByUserid(userUpdateViewModel.Id);
            var user_Info_update = _IMapper.Map<UserUpdateViewModel, User_Info>(userUpdateViewModel, user_Info);
            _IUserInfoRepository.Update(user_Info_update);
            return _IUserInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 更新审核状态
        /// </summary>
        /// <param name="userRegisterUpdateViewModel"></param>
        /// <returns></returns>
        public int UserRegister_Update(UserRegisterUpdateViewModel  userRegisterUpdateViewModel)
        {
 
            var UserRegister = _userRegisterRepository.SearchById(userRegisterUpdateViewModel.Id);//更新注册用户审批状态
            var UserRegister_update = _IMapper.Map<UserRegisterUpdateViewModel, User_Register>(userRegisterUpdateViewModel, UserRegister[0]);
                UserRegister_update.updateDate = DateTime.Now;
                _userRegisterRepository.Update(UserRegister_update);
                _userRegisterRepository.SaveChanges();
            if (userRegisterUpdateViewModel.status == "9")
            {
                var user_Info_middle = _IMapper.Map<User_Register, UserRegisterMiddleToUserInfo>(UserRegister_update);//增加用户信息
                var user_Info = _IMapper.Map<UserRegisterMiddleToUserInfo, User_Info>(user_Info_middle);//增加用户信息
                user_Info.AddDate = DateTime.Now;
                user_Info.status = "0";
                _IUserInfoRepository.Add(user_Info);
                _IUserInfoRepository.SaveChanges();
            }
            return 1;
        }


        //按部门添加用户
        public int Depart_User_Add(RelateDepartToUserAddViewModel relateDepartToUserAddViewModel)
        {
            var userList = relateDepartToUserAddViewModel.RelateUserIdandDepartIdList;//用户id和部门id列表

            for (int i = 0; i < userList.Count; i++)
            {
                var hr_info = _IUserInfoRepository.GetInfoByUserid(userList[i].Id);
                var hr_info_update = _IMapper.Map<RelateDepartUserAddMiddlecs, User_Info>(userList[i], hr_info);
                _IUserInfoRepository.Update(hr_info_update);
            }
           
            return _IUserInfoRepository.SaveChanges();
        }

        //按工会添加用户
        public int Union_User_Add(RelateUnionToUserAddViewModel  relateUnionToUserAddViewModel)
        {
            var userList = relateUnionToUserAddViewModel.relateUnionUserAddMiddles;//用户id和工会id列表

            for (int i = 0; i < userList.Count; i++)
            {
                var hr_info = _IUserInfoRepository.GetInfoByUserid(userList[i].Id);
                var hr_info_update = _IMapper.Map<RelateUnionUserAddMiddle, User_Info>(userList[i], hr_info);
                _IUserInfoRepository.Update(hr_info_update);
            }
            return _IUserInfoRepository.SaveChanges();
        }




        //根据角色查询用户
        public List<UserSearchMiddlecs> User_By_Role_Search(UserByRoleSearchViewModel userByRoleSearchViewModel)
        {
            List<User_Relate_Info_Role> user_Relate_Info_Users = _userRelateInfoRoleRepository.SearchUserInfoByWhere(userByRoleSearchViewModel);
            List<UserSearchMiddlecs> user_infos = new List<UserSearchMiddlecs>();

            foreach (var item in user_Relate_Info_Users)
            {
                var user_info_temp = _IMapper.Map<User_Info, UserSearchMiddlecs>(item.User_Info);
                user_infos.Add(user_info_temp);
            }
            return user_infos;
        }

        //获取所有用户
        public int User_Get_ALLNum(UserSearchViewModel userSearchViewModel)
        {
            return _IUserInfoRepository.GetUserAll(userSearchViewModel).Count();
        }


        public bool CheckIdcard(string Idcard)
        {
            if (_IUserInfoRepository.CheckIdcard(Idcard).Count > 0)
                return true;

            else return false;

        }

        public bool CheckIdcard2(string Idcard,string Id)
        {
            if (_IUserInfoRepository.CheckIdcard(Idcard).Count > 0 && _IUserInfoRepository.CheckIdcard(Idcard)[0].Id.ToString()!= Id)
                return true;

            else return false;

        }


        /// <summary>
        /// 根据身份证号查询用户
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        public List<User_Info> SearchByIdcard(string Idcard)
        {
            return _IUserInfoRepository.SearchByIdcard(Idcard);
        }
        /// <summary>
        /// 根据角色查用户数量
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        public int User_By_Role_Get_ALLNum(UserByRoleSearchViewModel userByRoleSearchViewModel)
        {
            return _userRelateInfoRoleRepository.GetUserByRoleAll(userByRoleSearchViewModel).Count();
        }
        /// <summary>
        /// 根据角色列表查询用户
        /// </summary>
        /// <param name="RoleList"></param>
        /// <returns></returns>
        public List<User_Info> User_By_RoleList_Search(List<int> RoleList)
        {
            List<User_Info> user_Relate_Info_Users = _userRelateInfoRoleRepository.SearchUserInfoByListWhere(RoleList);

            return user_Relate_Info_Users;
        }
        /// <summary>
        /// 获得头像名称
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public string GetUserHead(IFormFile formFile)
        {
            string filePath = "";//上传文件的路径
            string RandName = "";
            string[] fileTail = formFile.FileName.Split('.');
            RandName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileTail[1];
            filePath = Directory.GetCurrentDirectory() + "\\files\\" + RandName;
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            return RandName;
        }
        /// <summary>
        /// 根据部门查用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        public List<UserSearchMiddlecs> User_By_Depart_Search(UserByDepartSearchViewModel userByDepartSearchViewModel)
        {
            List<User_Info> Bus_Relate_Line = _IUserInfoRepository.SearchUserInfoByDepartWhere(userByDepartSearchViewModel);
            List<UserSearchMiddlecs> user_infos = new List<UserSearchMiddlecs>();
            foreach (var item in Bus_Relate_Line)
            {
                var user_info_temp = _IMapper.Map<User_Info, UserSearchMiddlecs>(item);
                user_infos.Add(user_info_temp);
            }
            return user_infos;
        }

        public int User_By_Depart_Get_ALLNum(UserByDepartSearchViewModel userByDepartSearchViewModel)
        {
            return _IUserInfoRepository.GetUserByDepartAll(userByDepartSearchViewModel).Count();
        }


        //查询用户
        public int User_SearchTest(UserSearchViewModel userSearchViewModel)
        {
            List<User_Info> user_Infos = _IUserInfoRepository.SearchInfoByWhere(userSearchViewModel);

            User_Relate_Info_Role a = new User_Relate_Info_Role();
            foreach (var item in user_Infos)
            {
                a.User_RoleId = 12;
                a.User_InfoId = item.Id;
                _userRelateInfoRoleRepository.Add(a);


            }
            return _userRelateInfoRoleRepository.SaveChanges();
        }
        //保存
        public string saveAttachInfo(IFormCollection fileinfo, string randomName)
        {
            string attid = Guid.NewGuid().ToString();
            var com_Attachs = new ComAttachs
            {
                Id = attid,
                UploadUserId = fileinfo["UploadUserId"],
                HrDeptId = Convert.ToInt32(fileinfo["HrDeptId"].ToString()),
                Filename = fileinfo["FileName"],
                FileType = fileinfo["FileType"],
                Employeeid = fileinfo["userid"],
                Physicsname = randomName,
                Createdate = DateTime.Now,
                Isdelete = "0",
                Formtablename = fileinfo["tablename"],
                //Filesize = fileinfo["filesize"],
                //Remark = fileinfo["Remark"]
            };
            _IUserInfoRepository.Add2(com_Attachs);
            _IUserInfoRepository.SaveChanges();
            return attid;
        }
        /// <summary>
        /// 增加积分信息
        /// </summary>
        /// <param name="userIntegralLogAddViewModel"></param>
        /// <returns></returns>
        public int User_Integral_Log_Add(UserIntegralLogAddViewModel userIntegralLogAddViewModel)
        {
            try
            {
                var user_Integral_Log = _IMapper.Map<UserIntegralLogAddViewModel, User_Integral_Log>(userIntegralLogAddViewModel);
                user_Integral_Log.AddDate = DateTime.Now;
                user_Integral_Log.IsDelete = "0";
                _userIntegralRepository.Add(user_Integral_Log);
               int a=  _userIntegralRepository.SaveChanges();
                if (a == 1 && user_Integral_Log.status=="0")
                {
                    var TempList = _userIntegralRepository.SearchUserIntegral(userIntegralLogAddViewModel.Idcard);
                    if (TempList.Count > 0)
                    {
                        int TPoint = Convert.ToInt32(TempList[0].TotalPoints) + Convert.ToInt32(userIntegralLogAddViewModel.Points);
                        TempList[0].TotalPoints = TPoint.ToString();
                        TempList[0].updateDate = DateTime.Now;
                        _userIntegralRepository.Update_User_Integral(TempList[0]);
                    }
                    else
                    {
                        var user_Integral = _IMapper.Map<UserIntegralLogAddViewModel, User_Integral>(userIntegralLogAddViewModel);
                        user_Integral.AddDate = DateTime.Now;
                        user_Integral.updateDate= user_Integral.AddDate;
                        user_Integral.updateUser = user_Integral.createUser;
                        user_Integral.IsDelete = "0";
                        user_Integral.TotalPoints = "1";
                        _userIntegralRepository.Add_User_Integral(user_Integral);

                    }
                    return _userIntegralRepository.SaveChanges();
                }
                else
                    return 0;

            }
            catch (Exception E)
            {
                E.ToString();
                return 2;
            }

        }


        /// <summary>
        /// 根据用户ID查询用户积分信息
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        public List<User_Integral> SearchByUserId(string Id)
        {
            return _userIntegralRepository.SearchUserIntegralByUserId(Id);
        }

        /// <summary>
        /// 根据条件查询注册信息
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        public List<User_Register> SearchUserRegisterWhere(UserRegisterSearchViewModel  userRegisterSearchViewModel)
        {
            return _userRegisterRepository.SearchUserRegister(userRegisterSearchViewModel);
        }

        /// <summary>
        /// 根据条件查询注册信息
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        public int SearchUserRegisterWhereNum(UserRegisterSearchViewModel userRegisterSearchViewModel)
        {
            return _userRegisterRepository.SearchUserRegister(userRegisterSearchViewModel).Count;
        }

        /// <summary>
        /// 根据条件查询用户积分信息
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        public List<User_Integral> SearchUserIntegralWhere(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            return _userIntegralRepository.SearchUserIntegralAll(userIntegralSearchViewModel);
        }

        /// <summary>
        /// 根据条件查询用户积分信息
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        public List<UserIntegralSearchMiddle> SearchUserIntegralNewWhere(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            string _connectionString = "Server=172.30.10.243\\SQLSERVER2014,14330;Database=User_DateBase;uid=sa;pwd=Admin@123.0;";
          // string _connectionString = "Server=192.168.168.10\\SQLEXPRESSTEST,1349;Database=User_DateBase;uid=sa;pwd=Admin@123456;";
            string UserName = "'%" + userIntegralSearchViewModel.UserName + "%'";
            string Mobile = "'%" + userIntegralSearchViewModel.Mobile + "%'";
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                string sql = "select User_Integral.UserName as UserName,User_Integral.Idcard as Idcard,User_Integral.Dept as Dept, User_Integral.Type as Type,";
                sql += " User_Integral.TotalPoints as TotalPoints,User_Integral.Mobile as Mobile,User_Union.Name as UnionName,User_Integral.updateDate as updateDate";
                sql += " from User_Integral inner join User_Info On User_Integral.Idcard=User_Info.Idcard left join User_Union On User_Union.Id=User_Info.User_UnionId where 1=1";
                if (userIntegralSearchViewModel.UserName!="" && userIntegralSearchViewModel.UserName!=null)
                sql += " and User_Integral.UserName like " + UserName;
                if (userIntegralSearchViewModel.Mobile != "" && userIntegralSearchViewModel.Mobile != null)
                sql += " and User_Integral.Mobile like " + Mobile;
                if (userIntegralSearchViewModel.User_DepartId != null)
                {
                    sql += " and User_Integral.User_DepartId='" + userIntegralSearchViewModel.User_DepartId + "'";
                }
                if (userIntegralSearchViewModel.starPoints != null && userIntegralSearchViewModel.endPoints != null)
                {
                    sql += " and CONVERT(int,User_Integral.TotalPoints, 23)>='" + userIntegralSearchViewModel.starPoints + "' and CONVERT(int, User_Integral.TotalPoints, 23) <='" + userIntegralSearchViewModel.endPoints + "'";
                }

                if (userIntegralSearchViewModel.strDate != null && userIntegralSearchViewModel.endDate != null)
                {
                    sql += " and User_Integral.updateDate >='" + userIntegralSearchViewModel.strDate.Value + "' and User_Integral.updateDate <= '" + userIntegralSearchViewModel.endDate.Value + "'";
                }
                sql += " order by CONVERT(int,TotalPoints, 23)  desc offset @total rows fetch next @cur rows only";
                var result = connection.Query<UserIntegralSearchMiddle>( @sql, new { total = (userIntegralSearchViewModel.pageViewModel.CurrentPageNum - 1) * userIntegralSearchViewModel.pageViewModel.PageSize,
                                cur = userIntegralSearchViewModel.pageViewModel.PageSize}).ToList();

                return result;
            }
   
        }

        /// <summary>
        /// 根据条件查询用户积分信息数量
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        public int SearchUserIntegralWhereNum(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            string _connectionString = "Server=172.30.10.243\\SQLSERVER2014,14330;Database=User_DateBase;uid=sa;pwd=Admin@123.0;";
            // string _connectionString = "Server=192.168.168.10\\SQLEXPRESSTEST,1349;Database=User_DateBase;uid=sa;pwd=Admin@123456;";
            string UserName = "'%" + userIntegralSearchViewModel.UserName + "%'";
            string Mobile = "'%" + userIntegralSearchViewModel.Mobile + "%'";
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                string sql = "select User_Integral.UserName as UserName,User_Integral.Idcard as Idcard,User_Integral.Dept as Dept, User_Integral.Type as Type,";
                sql += " User_Integral.TotalPoints as TotalPoints,User_Integral.Mobile as Mobile,User_Union.Name as UnionName,User_Integral.updateDate as updateDate";
                sql += " from User_Integral inner join User_Info On User_Integral.Idcard=User_Info.Idcard left join User_Union On User_Union.Id=User_Info.User_UnionId";
                sql += " where 1=1";
                if (userIntegralSearchViewModel.UserName != "" && userIntegralSearchViewModel.UserName != null)
                    sql += " and User_Integral.UserName like " + UserName;
                if (userIntegralSearchViewModel.Mobile != "" && userIntegralSearchViewModel.Mobile != null)
                    sql += " and User_Integral.Mobile like " + Mobile;
                if (userIntegralSearchViewModel.User_DepartId != null)
                {
                    sql += " and User_Integral.User_DepartId='" + userIntegralSearchViewModel.User_DepartId + "'";
                }
                if (userIntegralSearchViewModel.starPoints != null && userIntegralSearchViewModel.endPoints != null)
                {
                    sql += " and CONVERT(int,User_Integral.TotalPoints, 23) >= '" + userIntegralSearchViewModel.starPoints + "' and CONVERT(int, User_Integral.TotalPoints, 23) <= '" + userIntegralSearchViewModel.endPoints + "'";
                }

                if (userIntegralSearchViewModel.strDate != null && userIntegralSearchViewModel.endDate != null)
                {
                    sql += " and User_Integral.updateDate >='" + userIntegralSearchViewModel.strDate.Value + "' and User_Integral.updateDate<= '" + userIntegralSearchViewModel.endDate.Value + "'";
                }
            

                var result = connection.Query<UserIntegralSearchMiddle>(@sql).ToList();
                return result.Count;
            }
        }


        public UserIntegralLogAddViewModel TempFunctionCorrect(User_Info  user_Info,string sn)
        {
            var add_temp = _IMapper.Map<User_Info, UserIntegralLogAddViewModel>(user_Info);
            add_temp.Type = "光盘行动";
            add_temp.PointsLocation = "食堂";
            add_temp.Points = "1";
            add_temp.status = "0";
            add_temp.sn = sn;
            return add_temp;
        }
        public UserIntegralLogAddViewModel TempFunctionError(User_Info user_Info, string sn)
        {
            var add_temp = _IMapper.Map<User_Info, UserIntegralLogAddViewModel>(user_Info);
            add_temp.Type = "光盘行动";
            add_temp.PointsLocation = "食堂";
            add_temp.status = "1";
            add_temp.sn = sn;
            return add_temp;
        }
        /// <summary>
        /// 扫码加积分
        /// </summary>
        /// <param name="checkCodeSearchViewModel"></param>
        /// <returns></returns>
        public string CheckCodeAddIntegral(UserIntegralViewModel userIntegralViewModel)
        {


            try
            {
                if(userIntegralViewModel.Code.Length == 37)
                {
                    string TempCode = userIntegralViewModel.Code.Substring(36);
                    if (TempCode == "0")//用电子通行证的二维码扫的
                    {
                        var client = new RestClient("https://dztxz.dongjiang.gov.cn/ET_CompanyApi/api/PersonInfo/Manage/PersonInfo/GetCompanyPersonInfoByCode?Code=" + userIntegralViewModel.Code);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.GET);
                        IRestResponse response = client.Execute(request);

                        if (response.Content == "\"\"")//二维码过期，动态码已刷新
                        {
                            return "2";
                        }
                        else
                        {
                            string idcard = response.Content.Substring(1, 18);
                            var UserList = _IUserInfoRepository.SearchByIdcardNew(response.Content.Substring(1, 18));
                            if (UserList.Count == 0)
                            {
                                return "4";//有电子通行证但是没有智慧后勤账户
                            }
                            else
                            {
                                var TempList = _userIntegralRepository.SearchUserIntegral2(idcard);
                                UserIntegralLogAddViewModel ulvm = new UserIntegralLogAddViewModel();
                                string DateTimeResult = DateTime.Now.ToString("yyyy/MM/dd");
                                //判断当前时间是否在工作时间段内
                                string _staMorning = _IOptions._staMorning;//工作时间上午07:00
                                string _endMorning = _IOptions._endMorning; //工作时间上午09:00

                                string _staNoon = _IOptions._staNoon; //工作时间中午11:30
                                string _endNoon = _IOptions._endNoon; //工作时间中午13:30

                                //string _staNight = _IOptions._staNight; //工作时间下午17:00
                                //string _endNight = _IOptions._endNight; //工作时间上午19:00
                                TimeSpan _staMorningDay = DateTime.Parse(_staMorning).TimeOfDay;
                                TimeSpan _endMorningDay = DateTime.Parse(_endMorning).TimeOfDay;

                                TimeSpan _staNoonDay = DateTime.Parse(_staNoon).TimeOfDay;
                                TimeSpan _endNoonDay = DateTime.Parse(_endNoon).TimeOfDay;

                                //TimeSpan _staNightDay = DateTime.Parse(_staNight).TimeOfDay;
                                //TimeSpan _endNightgDay = DateTime.Parse(_endNight).TimeOfDay;

                                TimeSpan dspNow = DateTime.Now.TimeOfDay;
                                if (dspNow > _staMorningDay && dspNow < _endMorningDay)//上午6-9点
                                {
                                    if (TempList.Count == 0)//从未扫过码
                                    {
                                        var add_temp = TempFunctionCorrect(UserList[0], userIntegralViewModel.sn);
                                        if (User_Integral_Log_Add(add_temp) == 1)
                                            return "0";
                                        else return "5";
                                    }
                                    else
                                    {
                                        var ScanCodeDate = TempList[0].AddDate.Value.TimeOfDay;
                                        string ScanCodeDateResult = TempList[0].AddDate.Value.ToString("yyyy/MM/dd");
                                        if (ScanCodeDate > _staMorningDay && ScanCodeDate < _endMorningDay && DateTimeResult == ScanCodeDateResult)
                                        {
                                            var add_temp = TempFunctionError(UserList[0], userIntegralViewModel.sn);

                                            if (User_Integral_Log_Add(add_temp) == 0)
                                                return "1";
                                            else return "5";
                                        }
                                        else
                                        {
                                            var add_temp = TempFunctionCorrect(UserList[0], userIntegralViewModel.sn);
                                            if (User_Integral_Log_Add(add_temp) == 1)
                                                return "0";
                                            else return "5";
                                        }

                                    }
                                }//早上允许扫码的时间段
                                if (dspNow > _staNoonDay && dspNow < _endNoonDay)//中午允许扫码的时间段
                                {
                                    if (TempList.Count == 0)//从未扫过码
                                    {

                                        var add_temp = TempFunctionCorrect(UserList[0], userIntegralViewModel.sn);
                                        if (User_Integral_Log_Add(add_temp) == 1)
                                            return "0";
                                        else return "5";
                                    }
                                    else
                                    {

                                        var ScanCodeDate = TempList[0].AddDate.Value.TimeOfDay;
                                        string ScanCodeDateResult = TempList[0].AddDate.Value.ToString("yyyy/MM/dd");
                                        if (ScanCodeDate > _staNoonDay && ScanCodeDate < _endNoonDay && DateTimeResult == ScanCodeDateResult)
                                        {
                                            var add_temp = TempFunctionError(UserList[0], userIntegralViewModel.sn);
                                            if (User_Integral_Log_Add(add_temp) == 0)   //不能重复扫码
                                                return "1";
                                            else return "5";

                                        }
                                        else
                                        {
                                            var add_temp = TempFunctionCorrect(UserList[0], userIntegralViewModel.sn);
                                            if (User_Integral_Log_Add(add_temp) == 1)
                                                return "0";
                                            else return "5";
                                        }
                                    }
                                }//中午允许扫码的时间段
                                //if (dspNow > _staNightDay && dspNow < _endNightgDay)//晚上允许扫码的时间段
                                //{
                                //    if (TempList.Count == 0)//从未扫过码
                                //    {
                                //        var add_temp = TempFunctionCorrect(UserList[0], userIntegralViewModel.sn);
                                //        if (User_Integral_Log_Add(add_temp) == 1)
                                //            return "0";
                                //        else return "5";

                                //    }
                                //    else
                                //    {

                                //        var ScanCodeDate = TempList[0].AddDate.Value.TimeOfDay;
                                //        string ScanCodeDateResult = TempList[0].AddDate.Value.ToString("yyyy/MM/dd");
                                //        if (ScanCodeDate > _staNightDay && ScanCodeDate < _endNightgDay && DateTimeResult == ScanCodeDateResult)
                                //        {
                                //            var add_temp = TempFunctionError(UserList[0], userIntegralViewModel.sn);
                                //            if (User_Integral_Log_Add(add_temp) == 0)   //不能重复扫码
                                //                return "1";
                                //            else return "5";
                                //        }
                                //        else
                                //        {
                                //            var add_temp = TempFunctionCorrect(UserList[0], userIntegralViewModel.sn);
                                //            if (User_Integral_Log_Add(add_temp) == 1)
                                //                return "0";
                                //            else return "5";
                                //        }
                                //    }
                                //}
                                var add_temp3 = TempFunctionError(UserList[0], userIntegralViewModel.sn);
                                User_Integral_Log_Add(add_temp3);
                                return "3";//不符合扫码时间段
                            }

                        }//通过动态码，能查询出信息
                    }
                    else//用智慧后勤的二维码扫的
                    {
                        return "5";
                    }
                }
                else
                {
                    return "2";
                }
            }
            catch (Exception e)
            {
                return "5";
            }
        
        }

        /// <summary>
        /// 附件保存
        /// </summary>
        /// <param name="uploadFileMiddleModel"></param>
        /// <param name="formid"></param>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        private int UploadImgAdd(Commodity_AttachsMiddles  commodity_AttachsMiddles, string formid,string userId)
        {
            var model = _IMapper.Map<Commodity_AttachsMiddles, Commodity_Attachs>(commodity_AttachsMiddles);
            model.id = Guid.NewGuid().ToString();
            model.formid = formid;
            model.creatorID = userId;
            model.createDate = DateTime.Now;
            _userIntegralRepository.Add_Commodity_Attachs(model);
            return _userIntegralRepository.SaveChanges();
        }

        /// <summary>
        /// 校验分数是否超
        /// </summary>
        /// <param name="userIntegralCheckViewModel"></param>
        /// <returns></returns>

        public int Product_List_Check(UserIntegralCheckViewModel userIntegralCheckViewModel)
        {
            try
            {
                int points = userIntegralCheckViewModel.points;
                var user_info = _IUserInfoRepository.GetInfoByUserid(Convert.ToInt32(userIntegralCheckViewModel.userId));
                string idcard = user_info.Idcard;
                var userIntegral = _userIntegralRepository.SearchUserIntegral(idcard);
                if (userIntegral.Count > 0)
                {
                    if (points > Convert.ToInt64(userIntegral[0].TotalPoints))
                    {
                        return 1;//分数已超
                    }
                    else
                        return 0;//分数未超

                }
                else
                    return -1;
            }catch(Exception e)
            {
                return -2;
            }
        }


        /// <summary>
        /// 新增物品清单
        /// </summary>
        /// <param name="shoppingCarAddViewModel"></param>
        /// <returns></returns>

        public int Product_List_Add(List<ShoppingCarAddViewModel>  shoppingCarAddViewModel)
        {
            int result = 0;
            int totalNum = 0;
            for(int i=0;i< shoppingCarAddViewModel.Count;i++)
            {
                var model = _IMapper.Map<ShoppingCarAddViewModel, Product_List>(shoppingCarAddViewModel[i]);
                model.Id = Guid.NewGuid().ToString();
                model.AddDate = DateTime.Now;
                model.createUser = shoppingCarAddViewModel[i].userId;
                model.updateDate = DateTime.Now;
                model.updateUser = shoppingCarAddViewModel[i].userId;
                totalNum = totalNum + Convert.ToInt32(shoppingCarAddViewModel[i].IntegralNum)* Convert.ToInt32(shoppingCarAddViewModel[i].CommodityNum);
                _userIntegralRepository.Add_Product_List(model);
            }
          
            result = _userIntegralRepository.SaveChanges();
            if (shoppingCarAddViewModel.Count == result)
            {
              var user_info=  _IUserInfoRepository.GetInfoByUserid(Convert.ToInt32(shoppingCarAddViewModel[0].userId));
              string idcard = user_info.Idcard;
              var userIntegral=  _userIntegralRepository.SearchUserIntegral(idcard);
                if(userIntegral.Count>0)//积分清零
                {
                    userIntegral[0].TotalPoints = (Convert.ToInt32(userIntegral[0].TotalPoints)-totalNum).ToString();
                    _userIntegralRepository.Update_User_Integral(userIntegral[0]);
                    _userIntegralRepository.SaveChanges();
                }
            } 

            return result;

        }




        /// <summary>
        /// 删除多个商品信息
        /// </summary>
        /// <param name="integralCommodityDeleteViewModel"></param>
        /// <returns></returns>
        public int IntegralCommodity_Delete(IntegralCommodityDeleteViewModel  integralCommodityDeleteViewModel)
        {
            int DeleteRowsNum = _userIntegralRepository
                 .DeleteByUseridList(integralCommodityDeleteViewModel.DeleleIdList);
            if (DeleteRowsNum == integralCommodityDeleteViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }

        }


        /// <summary>
        /// 根据条件查询商品信息
        /// </summary>
        /// <param name="productListSearchViewModel"></param>
        /// <returns></returns>
        public List<IntegralCommodityMiddle> Integral_Commodity_Search(IntegralCommoditySearchViewModel integralCommoditySearchViewModel)
        {
          
              var tempList=  _userIntegralRepository.GetIntegral_CommodityList(integralCommoditySearchViewModel);
              var result= _IMapper.Map<List<Integral_Commodity>, List<IntegralCommodityMiddle>>(tempList);
                for(int i=0;i<tempList.Count;i++)
                {

                      var ImageInfo= GetImageMiddleModel(tempList[i].Id);
                    if(ImageInfo.Count>0)
                      result[i].Url = ImageInfo[0].Url;
           


                }
                          
            return result;
        }

        /// <summary>
        /// 根据条件查询物品清单
        /// </summary>
        /// <param name = "productListSearchViewModel" ></ param >
        /// < returns ></ returns >
        public List<ProductListMiddle> Product_List_Search(ProductListSearchViewModel productListSearchViewModel)
        {

           var tempList = _userIntegralRepository.GetProductListList(productListSearchViewModel);
            var result = _IMapper.Map<List<Product_List>, List<ProductListMiddle>>(tempList);
            for (int i = 0; i < tempList.Count; i++)
            {
                var ImageInfo = GetImageMiddleModel(tempList[i].formid);
                if(ImageInfo.Count>0)
                result[i].Url = ImageInfo[0].Url;
            }
            return result;
        }

        /// <summary>
        /// 根据用户主键ID查询物品清单
        /// </summary>
        /// <param name = "productListSearchViewModel" ></ param >
        /// < returns ></ returns >
        public List<ProductListMiddle> Product_List_ByUserId_Search(ProductListSearchByUserIdViewModel  productListSearchByUserIdViewModel)
        {

            var tempList = _userIntegralRepository.GetProductListListByUserId(productListSearchByUserIdViewModel.userid);
            var result = _IMapper.Map<List<Product_List>, List<ProductListMiddle>>(tempList);
            for (int i = 0; i < tempList.Count; i++)
            {
                var ImageInfo = GetImageMiddleModel(tempList[i].formid);
                if(ImageInfo.Count>0)
                result[i].Url = ImageInfo[0].Url;
            }
            return result;
        }




        /// <summary>
        /// 根据条件查询物品清单数量
        /// </summary>
        /// <param name = "productListSearchViewModel" ></ param >
        /// < returns ></ returns >
        public int Product_List_Search_Num(ProductListSearchViewModel productListSearchViewModel)
        {

            var tempList = _userIntegralRepository.GetProductListListNum(productListSearchViewModel);

            return tempList.Count;
        }


        /// <summary>
        /// 根据条件查询商品信息数量
        /// </summary>
        /// <param name="productListSearchViewModel"></param>
        /// <returns></returns>
        public int Integral_Commodity_Num_Search(IntegralCommoditySearchViewModel integralCommoditySearchViewModel)
        {
            return _userIntegralRepository.GetIntegral_Commodity_Num(integralCommoditySearchViewModel);
        }

        /// <summary>
        /// 查询图片信息
        /// </summary>
        /// <param name="formid"></param>
        /// <returns></returns>
        public List<Commodity_AttachsMiddles> GetImageMiddleModel(string formid)
        {
         
            var list = _userIntegralRepository.GetImageList(formid);
   
            var  result = _IMapper.Map<List<Commodity_Attachs>, List<Commodity_AttachsMiddles>>(list);
            return result;
      

        }

        /// <summary>
        /// 积分商品新增
        /// </summary>
        /// <param name="integralCommodityAddViewModel"></param>
        /// <returns></returns>
        public int Integral_Commodity_Add(IntegralCommodityAddViewModel integralCommodityAddViewModel)
        {
            int result = 0;
            var model = _IMapper.Map<IntegralCommodityAddViewModel, Integral_Commodity>(integralCommodityAddViewModel);

            model.Id = Guid.NewGuid().ToString();
            model.AddDate = DateTime.Now;
            model.createUser = integralCommodityAddViewModel.userId;
            model.updateDate = DateTime.Now;
            model.updateUser = integralCommodityAddViewModel.userId;
            model.IsDelete = "0";
            model.status = "0";
            _userIntegralRepository.Add_Integral_Commodity(model);
            result =  _userIntegralRepository.SaveChanges();
            if (result > 0)
            {
                if (integralCommodityAddViewModel.AttachsMiddles.FileName != null && integralCommodityAddViewModel.AttachsMiddles.FileName != "")
                {
                    UploadImgAdd(integralCommodityAddViewModel.AttachsMiddles, model.Id,model.createUser);
                }
            }
            return result;
        }

        /// <summary>
        /// 积分商品修改
        /// </summary>
        /// <param name="integralCommodityUpdateViewModel"></param>
        /// <returns></returns>
        public int Integral_Commodity_Update(IntegralCommodityUpdateViewModel  integralCommodityUpdateViewModel)
        {
            int result = 0;
            var modelTemp = _userIntegralRepository.GetIntegralCommodityList(integralCommodityUpdateViewModel.Id);
            Integral_Commodity model = _IMapper.Map<IntegralCommodityUpdateViewModel, Integral_Commodity>(integralCommodityUpdateViewModel, modelTemp[0]);
            model.updateDate = DateTime.Now;
            model.updateUser = integralCommodityUpdateViewModel.userId;
            _userIntegralRepository.Update_Integral_Commodity(model);
            result = _userIntegralRepository.SaveChanges(); //2020年3月4日15:14:32
            if (integralCommodityUpdateViewModel.AttachsMiddles.Url != null)
            {
                Commodity_Attachs com_AttachsModel = _userIntegralRepository.GetImageList(integralCommodityUpdateViewModel.Id).FirstOrDefault();
                com_AttachsModel = _IMapper.Map<Commodity_AttachsMiddles, Commodity_Attachs>(integralCommodityUpdateViewModel.AttachsMiddles, com_AttachsModel);
                _userIntegralRepository.Update_Commodity_Attachs(com_AttachsModel);
                result = _userIntegralRepository.SaveChanges(); //2020年3月4日15:14:35
            }
            return result;
        }




        public int UserAddTest()
        {
            var n=  _IUserInfoRepository.SearchUser_Test();
            int a = 0;
            for(int i=0;i < n.Count;i++)
            {

                if (n[i].Idcard != null && n[i].Idcard != "" )
                {
                    string idc4 = n[i].Idcard.Substring(14);
                    n[i].UserId = n[i].UserId.Replace(" ", "") + idc4;
                    n[i].UserPwd = n[i].UserId;
                    _IUserInfoRepository.Update3(n[i]);
                    _IUserInfoRepository.SaveChanges();
                    a++;
                }
                //if (n[i].Idcard == null || n[i].Idcard == "")
                //{
                //    var client = new RestClient("https://dztxz.dongjiang.gov.cn/ET_CompanyApi/api/PersonInfo/Manage/PersonInfo/Test_Search?username=" + n[i].UserName + "&dept=" + n[i].Dept);
                //    client.Timeout = -1;
                //    var request = new RestRequest(Method.POST);
                //    IRestResponse response = client.Execute(request);
                //    if (response.Content != "\"无\"")
                //    {
                //        string idc4 = response.Content.Substring(15, 4);
                //        n[i].UserId = n[i].UserId.Replace(" ", "") + idc4;
                //        n[i].UserPwd = n[i].UserId;
                //        n[i].Idcard = response.Content.Substring(1, 18);
                //        _IUserInfoRepository.Update3(n[i]);
                //        _IUserInfoRepository.SaveChanges();
                //        a++;
                //    }

                //}
            }
            return a;
        }

        public string UserAddTest2()
        {
            var userTestList = _IUserInfoRepository.SearchUser_Test();
          
            int a = 0;
            int b = 0;
            for (int i = 0; i < userTestList.Count; i++)
            {

                if(userTestList[i].Idcard!=""&& userTestList[i].Idcard !=null)
                {
                    var userList = _IUserInfoRepository.CheckIdcard(userTestList[i].Idcard);
                    if (userList.Count > 0)
                    {
                        if (userList[0].UserId == "" || userList[0].UserId == null)
                        {
                            userList[0].UserId = userTestList[i].UserId;
                            userList[0].UserPwd = userTestList[i].UserPwd;
                        }
                        userList[0].UnionName = userTestList[i].Union;
                        if ("东疆海事局工会" == userTestList[i].Union)
                            userList[0].User_UnionId = 1;
                        if ("东疆机关工会" == userTestList[i].Union)
                            userList[0].User_UnionId = 2;
                        if ("东疆税务局工会" == userTestList[i].Union)
                            userList[0].User_UnionId = 3;
                        _IUserInfoRepository.Update(userList[0]);
                        _IUserInfoRepository.SaveChanges();
                        a++;
                    }
                    else
                    {
                        var UserTestMiddle = _IMapper.Map<User_Test, UserTestMiddle>(userTestList[i]);
                        var ResultUser = _IMapper.Map<UserTestMiddle, User_Info>(UserTestMiddle);
                        if ("东疆海事局工会" == userTestList[i].Union)
                            ResultUser.User_UnionId = 1;
                        if ("东疆机关工会" == userTestList[i].Union)
                            ResultUser.User_UnionId = 2;
                        if ("东疆税务局工会" == userTestList[i].Union)
                            ResultUser.User_UnionId = 3;
                        _IUserInfoRepository.Add(ResultUser);
                        _IUserInfoRepository.SaveChanges();
                        b++;
                    }

                }

            }
            return a+","+b;
        }





    }
}
