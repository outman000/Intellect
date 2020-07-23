using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellUser;
using Dtol.dtol;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;
using Serilog;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService  _userService;
        private readonly ILogger _ILogger;



        public UserController(IUserService  userService, ILogger logger)
        {
            _userService = userService;
            _ILogger = logger;
        }
        /// <summary>
        /// 增添用户信息
        /// </summary>
        /// <param name="userAddViewModel"></param>
        /// <returns></returns>
       
        [HttpPost]
        [ValidateModel]

        public ActionResult<UserAddResModel> Manage_User_add(UserAddViewModel userAddViewModel)
        {
           

            int User_Add_Count;
            UserAddResModel userAddResModel = new UserAddResModel();
            User_Add_Count = _userService.User_Add(userAddViewModel);
            if (User_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = User_Add_Count;
                userAddResModel.baseViewModel.Message = "添加成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添用户信息成功");
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添用户信息失败");
                return Ok(userAddResModel);
            }
        }
        /// <summary>
        /// 用户名id验证是否重复
        /// </summary>
        /// <param name="userValideRepeat"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<UserValideResRepeat> Manage_User_ValideRepeat(UserValideRepeat userValideRepeat)
        {
            UserValideResRepeat userValideResRepeat = new UserValideResRepeat();
            bool ValideResutlt= _userService.User_Single(userValideRepeat);
            userValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                userValideResRepeat.IsSuccess = true;
                userValideResRepeat.baseViewModel.Message = "此id可以使用";
                userValideResRepeat.baseViewModel.ResponseCode = 200;
                _ILogger.Information("用户名id验证，此id可以使用");
                return  Ok(userValideResRepeat);
            }
            else
            {
                userValideResRepeat.IsSuccess = false;
                userValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                userValideResRepeat.baseViewModel.ResponseCode = 400;
                _ILogger.Information("用户名id验证，此id已经存在，请更换");
                return Ok(userValideResRepeat);
            }
        }


        /// <summary>
        /// 删除用户信息（软删除）
        /// </summary>
        /// <param name="userDeleteViewModel"></param>
        /// <returns></returns>

        [HttpPost]

        public ActionResult<UserDeleteResModel> Manage_User_Delete(UserDeleteViewModel userDeleteViewModel)
        {
            UserDeleteResModel userDeleteResModel = new UserDeleteResModel();
            int DeleteResult= _userService.User_Delete(userDeleteViewModel);

            if (DeleteResult > 0)
            {
                userDeleteResModel.AddCount = DeleteResult;
                userDeleteResModel.IsSuccess=true;
                userDeleteResModel.baseViewModel.Message = "删除成功";
                userDeleteResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除用户信息（软删除），删除成功");
                return Ok(userDeleteResModel);
            }
            else
            {
                userDeleteResModel.AddCount = -1;
                userDeleteResModel.IsSuccess = false;
                userDeleteResModel.baseViewModel.Message = "删除失败";
                userDeleteResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除用户信息（软删除），删除失败");
                return Ok(userDeleteResModel);
            }

         
          
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<UserUpdateResModel> Manage_User_Update(UserUpdateViewModel userUpdateViewModel)
        {
            UserUpdateResModel userValideResRepeat = new UserUpdateResModel();
            int UpdateRowNum = _userService.User_Update(userUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                userValideResRepeat.IsSuccess = true;
                userValideResRepeat.AddCount = UpdateRowNum;
                userValideResRepeat.baseViewModel.Message = "更新成功";
                userValideResRepeat.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新用户信息，更新成功");
                return Ok(userValideResRepeat);
            }
            else
            {
                userValideResRepeat.IsSuccess = false;
                userValideResRepeat.AddCount = 0;
                userValideResRepeat.baseViewModel.Message = "更新失败";
                userValideResRepeat.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新用户信息，更新失败");
                return Ok(userValideResRepeat);
            }
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<UserSearchResModel> Manage_User_Search(UserSearchViewModel userSearchViewModel)
        {
           UserSearchResModel userSearchResModel = new UserSearchResModel();
            var UserSearchResult = _userService.User_Search(userSearchViewModel);

            //var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _userService.User_Get_ALLNum(userSearchViewModel);
            userSearchResModel.user_Infos = UserSearchResult;
            userSearchResModel.isSuccess = true;
            userSearchResModel.baseViewModel.Message = "查询成功";
            userSearchResModel.baseViewModel.ResponseCode = 200;
            userSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询用户信息，查询成功");
            return Ok(userSearchResModel);

        }


        /// <summary>
        ///批量更新用户和角色
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<UserSearchResModel> Manage_User_SearchTest(UserSearchViewModel userSearchViewModel)
        {
            UserSearchResModel userSearchResModel = new UserSearchResModel();
            var UserSearchResult = _userService.User_SearchTest(userSearchViewModel);

            //var TotalNum = _userService.User_Get_ALLNum();
           // var TotalNum = _userService.User_Get_ALLNum(userSearchViewModel);
          //  userSearchResModel.user_Infos = UserSearchResult;
            userSearchResModel.isSuccess = true;
            userSearchResModel.baseViewModel.Message = "查询成功";
            userSearchResModel.baseViewModel.ResponseCode = 200;
            userSearchResModel.TotalNum = UserSearchResult;
            _ILogger.Information("查询用户信息，查询成功");
            return Ok(userSearchResModel);

        }

        /// <summary>
        /// 查询用户信息(根据用户)
        /// </summary>
        /// <param name="userSearchByUserIdViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<UserSearchResModel> Manage_User_Single_Search(UserSearchByUserIdViewModel  userSearchByUserIdViewModel)
        {
            UserSearchSingleResModel  userSearchSingleResModel = new UserSearchSingleResModel();
            var UserSearchResult = _userService.User_Single_Search(userSearchByUserIdViewModel);

            var TotalNum = 1;
            userSearchSingleResModel.user_Infos = UserSearchResult;
            userSearchSingleResModel.isSuccess = true;
            userSearchSingleResModel.baseViewModel.Message = "查询成功";
            userSearchSingleResModel.baseViewModel.ResponseCode = 200;
            userSearchSingleResModel.TotalNum = TotalNum;
            _ILogger.Information("查询用户信息，查询成功");
            return Ok(userSearchSingleResModel);

        }
        /// <summary>
        /// 验证身份证号是否重复
        /// </summary>
        /// <param name="Idcard"></param>
        /// <returns></returns>
        [HttpGet]

        public ActionResult<UserSearchResModel> Manage_CheckIdcard(string Idcard)
        {
            UserSearchSingleResModel userSearchSingleResModel = new UserSearchSingleResModel();
            var result = _userService.CheckIdcard(Idcard);
            if(result==true)
            {
                userSearchSingleResModel.isSuccess = true;
                userSearchSingleResModel.baseViewModel.Message = "验证身份证号成功，没有重复";
                userSearchSingleResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("验证身份证号成功，没有重复");
                return Ok(userSearchSingleResModel);

            }
            else
            {
                userSearchSingleResModel.isSuccess = false;
                userSearchSingleResModel.baseViewModel.Message = "验证身份证号成功，已重复";
                userSearchSingleResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("验证身份证号成功，已重复");
                return Ok(userSearchSingleResModel);
            }      

        }
       

        /// <summary>
        /// 根据部门 添加/删除 用户
        /// </summary>
        /// <param name="relateDepartToUserAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<RelateDepartToUserAddResModel> Manage_User_Depart(RelateDepartToUserAddViewModel relateDepartToUserAddViewModel)
        {
            RelateDepartToUserAddResModel relateDepartToUserAddResModel = new RelateDepartToUserAddResModel();
            int UpdateRowNum = _userService.Depart_User_Add(relateDepartToUserAddViewModel);
            int totalnum = relateDepartToUserAddViewModel.RelateUserIdandDepartIdList.Count;
            if (UpdateRowNum==totalnum)
            {
                relateDepartToUserAddResModel.IsSuccess = true;
                relateDepartToUserAddResModel.AddCount = UpdateRowNum;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据部门添加用户成功："+ UpdateRowNum+"条";
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据部门添加用户成功，" + UpdateRowNum + "条");
                return Ok(relateDepartToUserAddResModel);
            }
            else if(UpdateRowNum<totalnum)
            {
                relateDepartToUserAddResModel.IsSuccess = false;
                relateDepartToUserAddResModel.AddCount = 0;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据部门添加用户失败"+ (totalnum-UpdateRowNum) + "条";
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据部门添加用户失败，" + (totalnum - UpdateRowNum) + "条");
                return Ok(relateDepartToUserAddResModel);
            }
            else
            {
                relateDepartToUserAddResModel.IsSuccess = false;
                relateDepartToUserAddResModel.AddCount = 0;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据部门添加用户失败" ;
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据部门添加用户失败");
                return Ok(relateDepartToUserAddResModel);

            }

        }

        /// <summary>
        /// 根据角色查用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<UserByRoleSearchResModel> Manage_User_By_Role_Search(UserByRoleSearchViewModel userByRoleSearchViewModel)
        {
            UserByRoleSearchResModel userByRoleSearchResModel = new UserByRoleSearchResModel();
            userByRoleSearchResModel.userInfos = _userService.User_By_Role_Search(userByRoleSearchViewModel);

                userByRoleSearchResModel.IsSuccess = true;
                userByRoleSearchResModel.TotalNum = _userService.User_By_Role_Get_ALLNum(userByRoleSearchViewModel);
                userByRoleSearchResModel.baseViewModel.Message = "根据角色查用户成功";
                userByRoleSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据角色查用户成功");
            return Ok(userByRoleSearchResModel);
        }

        /// <summary>
        /// 根据角色查用户列表
        /// </summary>
        /// <param name="RoleList"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<List<User_Info>> Manage_User_By_RoleList_Search(List<int> RoleList)
        {
            List<User_Info> ui= _userService.User_By_RoleList_Search(RoleList);
            _ILogger.Information("根据角色查用户列表成功");
            return Ok(ui);      
        }

        /// <summary>上传文件并且导入数据库（通过requset）
        /// </summary>

        [HttpPost]

        public ActionResult uploadfile()
        {
            var files = Request.Form.Files;
            String RandFileName = "";
       
            if (files.Count == 0)
            {
                throw new ArgumentException("找不到上传的文件");
            }
            // full path to file in temp location
            foreach (var formFile in files)
            {
                RandFileName=_userService.GetUserHead(formFile);
            }
            // return Ok(RandName);
            return Ok("ss");
        }

        /// <summary>
        /// 根据部门查用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<UserByDepartSearchResModel> Manage_User_By_Depart_Search(UserByDepartSearchViewModel userByDepartSearchViewModel)
        {
            UserByDepartSearchResModel  userByDepartSearchResModel = new UserByDepartSearchResModel();
            userByDepartSearchResModel.userInfo = _userService.User_By_Depart_Search(userByDepartSearchViewModel);

            userByDepartSearchResModel.IsSuccess = true;
            userByDepartSearchResModel.TotalNum = _userService.User_By_Depart_Get_ALLNum(userByDepartSearchViewModel);
            userByDepartSearchResModel.baseViewModel.Message = "根据部门查用户成功";
            userByDepartSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据部门查用户成功");
            return Ok(userByDepartSearchResModel);
        }

        /// <summary>
        /// 上传文件并且得到上传文件的所有信息(导入用户信息)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FileUploadAddResModel> Manage_uploadfileAndGetInfo_UserInfo()
        {
            FileUploadAddResModel fileUploadAddResModel = new FileUploadAddResModel();
            int fileUpload_Add_Count = 0;
            var files = Request.Form.Files;
            string filePath = "";//上传文件的路径

            if (files.Count == 0)
            {
                throw new ArgumentException("找不到上传的文件");
            }
            // full path to file in temp location
            foreach (var formFile in files)
            {
                string randomname = _userService.fileRandName(formFile.FileName);
                filePath = Directory.GetCurrentDirectory() + "\\files\\" + randomname;
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                string tag = _userService.saveAttachInfo(Request.Form, randomname);
                fileUpload_Add_Count = _userService.uploadTodatabase_User_Info(filePath, Request.Form["tablename"], tag);
            }

            if (fileUpload_Add_Count > 0)
            {
                fileUploadAddResModel.IsSuccess = true;
                fileUploadAddResModel.AddCount = fileUpload_Add_Count;
                fileUploadAddResModel.baseViewModel.Message = "导入附件成功";
                fileUploadAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("导入附件成功");
                return Ok(fileUploadAddResModel);
            }
            else
            {
                fileUploadAddResModel.IsSuccess = false;
                fileUploadAddResModel.AddCount = 0;
                fileUploadAddResModel.baseViewModel.Message = "导入附件失败";
                fileUploadAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("导入附件失败");
                return BadRequest(fileUploadAddResModel);
            }
        }
    }
}