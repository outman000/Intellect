using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.Attribute;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IUserRelateInfoRoleRepository _userRelateInfoRoleRepository;
        NPOIClass EP_Plus = new NPOIClass();
        public UserService(IUserInfoRepository iuserInfoRepository, IUserRelateInfoRoleRepository userRelateInfoRoleRepository, IMapper mapper)
        {
            _IUserInfoRepository = iuserInfoRepository;
            _userRelateInfoRoleRepository = userRelateInfoRoleRepository;
            _IMapper = mapper;
        }

        //添加用户
        public int User_Add(UserAddViewModel userAddViewModel)
        {
          
            var user_Info = _IMapper.Map<UserAddViewModel, User_Info>(userAddViewModel);
            _IUserInfoRepository.Add(user_Info);
            return _IUserInfoRepository.SaveChanges();
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
            //string RandName = GetUserHead(userUpdateViewModel.formFile);//头像名
            //RandName = " E://东疆智慧后勤/IntellUser/HeadImg/" + RandName;//头像存储路径
            //userUpdateViewModel.Files = RandName;
            var user_Info = _IUserInfoRepository.GetInfoByUserid(userUpdateViewModel.Id);
            var user_Info_update = _IMapper.Map<UserUpdateViewModel, User_Info>(userUpdateViewModel, user_Info);
            _IUserInfoRepository.Update(user_Info_update);
            return _IUserInfoRepository.SaveChanges();
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
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    var user_Info = _IUserInfoRepository.GetInfoByUserid(userList[i].Id);
            //    user_Info.User_DepartId = userList[i].User_DepartId;
            //    _IUserInfoRepository.SaveChanges();
            //}

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
                return false;

            else return true;

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
    }
}
