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
using ViewModel.UserViewModel.MiddleModel;
using Microsoft.Extensions.Configuration;

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService  _userService;
        private readonly ILogger _ILogger;
        private readonly IConfiguration _configuration;


        public UserController(IUserService  userService, IConfiguration configuration, ILogger logger)
        {
            _userService = userService;
            _configuration = configuration;
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
        /// 根据用户ID查询用户积分信息
        /// </summary>
        /// <param name="userIntegralByUserId"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<UserIntegralResModel> Manage_IntegralSearchByUserId(UserIntegralByUserId  userIntegralByUserId)
        {
            UserIntegralResModel  userIntegralResModel = new UserIntegralResModel();
            var Result = _userService.SearchByUserId(userIntegralByUserId.id);
            userIntegralResModel.user_Integrals = Result;
            userIntegralResModel.isSuccess = true;
            userIntegralResModel.baseViewModel.Message = "查询成功";
            userIntegralResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据用户ID查询用户积分信息，查询成功");
            return Ok(userIntegralResModel);

        }

        /// <summary>
        /// 根据条件查询用户积分信息
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<UserIntegralResModel> Manage_IntegralSearchAll(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            UserIntegralResModel userIntegralResModel = new UserIntegralResModel();
            var Result = _userService.SearchUserIntegralWhere(userIntegralSearchViewModel);
            int count= _userService.SearchUserIntegralWhereNum(userIntegralSearchViewModel);
           
            userIntegralResModel.user_Integrals = Result;
            userIntegralResModel.count = count;
            userIntegralResModel.isSuccess = true;
            userIntegralResModel.baseViewModel.Message = "查询成功";
            userIntegralResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据条件查询用户积分信息，查询成功");
            return Ok(userIntegralResModel);

        }


        /// <summary>
        /// 根据条件查询用户积分信息(最新)
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<UserIntegralSearchResModel> Manage_IntegralSearchNewAll(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            UserIntegralSearchResModel userIntegralResModel = new UserIntegralSearchResModel();
            var Result = _userService.SearchUserIntegralNewWhere(userIntegralSearchViewModel);
            int count = _userService.SearchUserIntegralWhereNum(userIntegralSearchViewModel);

            userIntegralResModel.user_Integrals = Result;
            userIntegralResModel.count = count;
            userIntegralResModel.isSuccess = true;
            userIntegralResModel.baseViewModel.Message = "查询成功";
            userIntegralResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据条件查询用户积分信息，查询成功");
            return Ok(userIntegralResModel);

        }




        /// <summary>
        /// 增添用户积分信息
        /// </summary>
        /// <param name="userIntegralLogAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]

        public ActionResult<UserAddResModel> Manage_User_Integral_Log(UserIntegralLogAddViewModel userIntegralLogAddViewModel)
        {


            int User_Add_Count;
            UserAddResModel userAddResModel = new UserAddResModel();
            User_Add_Count = _userService.User_Integral_Log_Add(userIntegralLogAddViewModel);
            if (User_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = User_Add_Count;
                userAddResModel.baseViewModel.Message = "添加成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添用户积分信息成功");
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添用户积分信息失败");
                return Ok(userAddResModel);
            }
        }

        /// <summary>
        /// 扫码加积分
        /// </summary>
        /// <param name="userIntegralViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]

        public ActionResult<AddIntegralResModel> Manage_CheckCodeAddIntegral(UserIntegralViewModel userIntegralViewModel)
        {


            AddIntegralResModel  addIntegralResModel = new AddIntegralResModel();
           string n = _userService.CheckCodeAddIntegral(userIntegralViewModel);
            if ( n == "0" )
            {
                addIntegralResModel.code = n;
                addIntegralResModel.msg = "添加成功";            
                _ILogger.Information("增添用户积分信息成功");
                return Ok(addIntegralResModel);
            }
            else if( n == "1")
            {
                addIntegralResModel.code = n;
                addIntegralResModel.msg = "添加失败，重复扫码";
                _ILogger.Information("增添用户积分信息失败，重复扫码");
                return Ok(addIntegralResModel);
            }
            else if (n == "2")
            {
                addIntegralResModel.code = n;
                addIntegralResModel.msg = "添加失败，二维码过期，动态码已刷新";
                _ILogger.Information("增添用户积分信息失败，二维码过期，动态码已刷新");
                return Ok(addIntegralResModel);
            }
            else if (n == "3")
            {
                addIntegralResModel.code = n;
                addIntegralResModel.msg = "添加失败，不符合扫码时间段";
                _ILogger.Information("增添用户积分信息失败，不符合扫码时间段");
                return Ok(addIntegralResModel);
            }
            else if (n == "4")
            {
                addIntegralResModel.code = n;
                addIntegralResModel.msg = "添加失败，有电子通行证但是没有智慧后勤账户";
                _ILogger.Information("增添用户积分信息失败，有电子通行证但是没有智慧后勤账户");
                return Ok(addIntegralResModel);
            }
            else
            {
                addIntegralResModel.code = n;
                addIntegralResModel.msg = "添加失败，系统异常";
                _ILogger.Information("增添用户积分信息失败，系统异常");
                return Ok(addIntegralResModel);
            }
        }


        /// <summary>
        /// 注册用户信息
        /// </summary>
        /// <param name="userRegisterViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]

        public ActionResult<UserRegisterResModel> Manage_User_Register(UserRegisterViewModel userRegisterViewModel)
        {

            UserRegisterResModel  userRegisterResModel = new UserRegisterResModel();
            int temp = _userService.User_Register(userRegisterViewModel);
            if (temp == 0)
            {
                userRegisterResModel.IsSuccess = true;
                userRegisterResModel.Status = temp;
                userRegisterResModel.baseViewModel.Message = "注册成功";
                userRegisterResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("注册用户信息成功");
                return Ok(userRegisterResModel);
            }
            else if(temp == 1)
            {
                userRegisterResModel.IsSuccess = false;
                userRegisterResModel.Status = temp;
                userRegisterResModel.baseViewModel.Message = "注册失败,未注册过电子通行证";
                userRegisterResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("注册用户信息失败,未注册过电子通行证");
                return Ok(userRegisterResModel);
            }
            else
            {
                userRegisterResModel.IsSuccess = false;
                userRegisterResModel.Status = temp;
                userRegisterResModel.baseViewModel.Message = "注册失败,注册过电子通行证并且智慧后勤也已经有身份信息,请勿重复操作";
                userRegisterResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("注册用户信息失败,注册过电子通行证并且智慧后勤也已经有身份信息,请勿重复操作");
                return Ok(userRegisterResModel);
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
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]

        public ActionResult<UserSearchResModel> Manage_CheckIdcard(string Idcard,string Id)
        {
            UserSearchSingleResModel userSearchSingleResModel = new UserSearchSingleResModel();
            var result = _userService.CheckIdcard2(Idcard,Id);
            if(result==false)
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
        /// 根据工会 添加/删除 用户
        /// </summary>
        /// <param name="relateUnionToUserAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<RelateDepartToUserAddResModel> Manage_User_Union(RelateUnionToUserAddViewModel  relateUnionToUserAddViewModel)
        {
            RelateDepartToUserAddResModel relateDepartToUserAddResModel = new RelateDepartToUserAddResModel();
            int UpdateRowNum = _userService.Union_User_Add(relateUnionToUserAddViewModel);
            int totalnum = relateUnionToUserAddViewModel.relateUnionUserAddMiddles.Count;
            if (UpdateRowNum == totalnum)
            {
                relateDepartToUserAddResModel.IsSuccess = true;
                relateDepartToUserAddResModel.AddCount = UpdateRowNum;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据工会添加用户成功：" + UpdateRowNum + "条";
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据工会添加用户成功，" + UpdateRowNum + "条");
                return Ok(relateDepartToUserAddResModel);
            }
            else if (UpdateRowNum < totalnum)
            {
                relateDepartToUserAddResModel.IsSuccess = false;
                relateDepartToUserAddResModel.AddCount = 0;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据工会添加用户失败" + (totalnum - UpdateRowNum) + "条";
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据工会添加用户失败，" + (totalnum - UpdateRowNum) + "条");
                return Ok(relateDepartToUserAddResModel);
            }
            else
            {
                relateDepartToUserAddResModel.IsSuccess = false;
                relateDepartToUserAddResModel.AddCount = 0;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据工会添加用户失败";
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据工会添加用户失败");
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


        /// <summary>
        /// 批量更新用户账户和密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UserByDepartSearchResModel> Manage_User_Add_Test()
        {
            UserByDepartSearchResModel userByDepartSearchResModel = new UserByDepartSearchResModel();
            int a = _userService.UserAddTest();

            userByDepartSearchResModel.IsSuccess = true;
            userByDepartSearchResModel.TotalNum = a;
            userByDepartSearchResModel.baseViewModel.Message = "批量更新用户账户和密码成功";
            userByDepartSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("批量更新用户账户和密码成功");
            return Ok(userByDepartSearchResModel);
        }


        /// <summary>
        /// 批量更新用户账户和密码和增加用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UserByDepartSearchResModel> Manage_User_Add_Test2()
        {
            UserByDepartSearchResModel userByDepartSearchResModel = new UserByDepartSearchResModel();
            string a = _userService.UserAddTest2();
            string re1 = a.Substring(0, a.IndexOf(","));
            string re2 = a.Substring(a.IndexOf(",")+1);
            userByDepartSearchResModel.IsSuccess = true;
            userByDepartSearchResModel.TotalNum = 999;
            userByDepartSearchResModel.baseViewModel.Message = "更新了："+re1+"个；新增了："+re2+"个";
            userByDepartSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("批量更新用户账户和密码成功");
            return Ok(userByDepartSearchResModel);
        }




        /// <summary>
        /// 更新注册用户信息
        /// </summary>
        /// <param name="userRegisterUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<UserUpdateResModel> Manage_UserRegister_Update(UserRegisterUpdateViewModel userRegisterUpdateViewModel)
        {
            UserUpdateResModel userValideResRepeat = new UserUpdateResModel();
            int UpdateRowNum = _userService.UserRegister_Update(userRegisterUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                userValideResRepeat.IsSuccess = true;
                userValideResRepeat.AddCount = UpdateRowNum;
                userValideResRepeat.baseViewModel.Message = "更新成功";
                userValideResRepeat.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新注册用户信息，更新成功");
                return Ok(userValideResRepeat);
            }
            else
            {
                userValideResRepeat.IsSuccess = false;
                userValideResRepeat.AddCount = 0;
                userValideResRepeat.baseViewModel.Message = "更新失败";
                userValideResRepeat.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新注册用户信息，更新失败");
                return Ok(userValideResRepeat);
            }
        }




        /// <summary>
        /// 查询注册用户信息
        /// </summary>
        /// <param name="userRegisterSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<UserRegisterSearchResModel> Manage_UserRegister_Search(UserRegisterSearchViewModel userRegisterSearchViewModel)
        {
            UserRegisterSearchResModel userRegisterSearchResModel = new UserRegisterSearchResModel();
            var userRegister = _userService.SearchUserRegisterWhere(userRegisterSearchViewModel);
            int count = _userService.SearchUserRegisterWhereNum(userRegisterSearchViewModel);
            userRegisterSearchResModel.user_Registers = userRegister;
            userRegisterSearchResModel.isSuccess = true;
            userRegisterSearchResModel.TotalNum = count;
            userRegisterSearchResModel.baseViewModel.Message = " 查询注册用户信息成功";
            userRegisterSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information(" 查询注册用户信息成功");
            return Ok(userRegisterSearchResModel);


        }


        /// <summary>
        /// 附件上传
        /// </summary>
        /// <param name="userID">登录账户</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFileNew([FromForm]string userID)
        {
            try
            {
                Commodity_AttachsMiddles model = new Commodity_AttachsMiddles();

                var folderName = "UploadFile";
                //var webRootPath = _hostingEnvironment.WebRootPath;
                var webRootPath = _configuration["StoredFilesPath"];
                var newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                var files = Request.Form.Files;
                if (files != null)
                {
                    var size = files.Sum(f => f.Length);
                    var fileName = "";
                    var physicsName = "";
                    var formFile = files[0];
                    var id = Guid.NewGuid().ToString();
                    if (formFile.Length > 0)
                    {
                        fileName = formFile.FileName;
                        var fileExt = Path.GetExtension(formFile.FileName);
                        physicsName = id + fileExt;
                        var filePath = Path.Combine(newPath, physicsName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        model.Catalog = DateTime.Now.ToString("yyyyMMddHHmmss");
                        model.ImgIndex = 1;
                        //文件名
                        model.FileName = fileName;
                        model.Length = formFile.Length.ToString();

                        //存储时生成新文件名
                        model.InternalName = physicsName;

                        //保存文件路径
                        string filePathName = _configuration["StoredFilesPath"];

                        //相对路径
                        string relativeUrl = _configuration["DownloadPath"]; ;

                        model.Path = filePathName;
                        //获取临时文件相对完整路径
                        model.Url = System.IO.Path.Combine(relativeUrl, model.InternalName).Replace("\\", "/");

                    }


                    return Ok(model);

                }
                else
                    return BadRequest("未上传任何附件");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }



        /// <summary>
        /// 积分商品新增
        /// </summary>
        /// <param name="integralCommodityAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]

        public ActionResult<UserAddResModel> Manage_Integral_Commodity_Add(IntegralCommodityAddViewModel integralCommodityAddViewModel)
        {
            int User_Add_Count;
            UserAddResModel userAddResModel = new UserAddResModel();
            User_Add_Count = _userService.Integral_Commodity_Add(integralCommodityAddViewModel);
            if (User_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = User_Add_Count;
                userAddResModel.baseViewModel.Message = "添加成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("积分商品新增成功");
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("积分商品新增失败");
                return Ok(userAddResModel);
            }
        }


        /// <summary>
        /// 积分商品修改
        /// </summary>
        /// <param name="integralCommodityUpdateViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]

        public ActionResult<UserAddResModel> Manage_Integral_Commodity_Update(IntegralCommodityUpdateViewModel  integralCommodityUpdateViewModel)
        {
            int User_Add_Count;
            UserAddResModel userAddResModel = new UserAddResModel();
            User_Add_Count = _userService.Integral_Commodity_Update(integralCommodityUpdateViewModel);
            if (User_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = User_Add_Count;
                userAddResModel.baseViewModel.Message = "修改成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("积分商品修改成功");
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "修改失败";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("积分商品修改失败");
                return Ok(userAddResModel);
            }
        }

        /// <summary>
        /// 新增物品清单
        /// </summary>
        /// <param name="shoppingCarAddMiddleModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<UserAddResModel> Manage_Product_List_Add(ShoppingCarAddMiddleModel  shoppingCarAddMiddleModel)
        {
            int Product_Add_Count;
            UserAddResModel userAddResModel = new UserAddResModel();
            Product_Add_Count = _userService.Product_List_Add(shoppingCarAddMiddleModel.shoppingCarAddViewModel);
            if (Product_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = Product_Add_Count;
                userAddResModel.baseViewModel.Message = "添加成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("新增物品清单成功");
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("新增物品清单失败");
                return Ok(userAddResModel);
            }
        }



        /// <summary>
        /// 查询商品信息
        /// </summary>
        /// <param name="integralCommoditySearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<IntegralCommoditySearchResModel> Manage_Integral_Commodity_Search(IntegralCommoditySearchViewModel integralCommoditySearchViewModel)
        {
            IntegralCommoditySearchResModel  integralCommoditySearchResModel = new IntegralCommoditySearchResModel();
            var Integral_Commodity = _userService.Integral_Commodity_Search(integralCommoditySearchViewModel);
            int count = _userService.Integral_Commodity_Num_Search(integralCommoditySearchViewModel);
            integralCommoditySearchResModel.integral_Commodities = Integral_Commodity;
            integralCommoditySearchResModel.isSuccess = true;
            integralCommoditySearchResModel.TotalNum = count;
            integralCommoditySearchResModel.baseViewModel.Message = " 查询商品信息成功";
            integralCommoditySearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询商品信息成功");
            return Ok(integralCommoditySearchResModel);


        }

        /// <summary>
        /// 查询兑换清单信息
        /// </summary>
        /// <param name="productListSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<ProductListSearchResModel> Manage_Product_List_Search(ProductListSearchViewModel productListSearchViewModel)
        {
            ProductListSearchResModel  productListSearchResModel = new ProductListSearchResModel();
            var Product_List = _userService.Product_List_Search(productListSearchViewModel);
            int count = _userService.Product_List_Search_Num(productListSearchViewModel);
            productListSearchResModel.productListMiddles = Product_List;
            productListSearchResModel.isSuccess = true;
            productListSearchResModel.TotalNum = count;
            productListSearchResModel.baseViewModel.Message = "查询兑换清单信息成功";
            productListSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询兑换清单信息成功");
            return Ok(productListSearchResModel);
        }


        /// <summary>
        /// 根据用户主键ID查询兑换清单信息
        /// </summary>
        /// <param name="productListSearchByUserIdViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<ProductListSearchResModel> Manage_Product_List_ByUserID_Search(ProductListSearchByUserIdViewModel productListSearchByUserIdViewModel)
        {
            ProductListSearchResModel productListSearchResModel = new ProductListSearchResModel();
            var Product_List = _userService.Product_List_ByUserId_Search(productListSearchByUserIdViewModel);
            int count = Product_List.Count;
            productListSearchResModel.productListMiddles = Product_List;
            productListSearchResModel.isSuccess = true;
            productListSearchResModel.TotalNum = count;
            productListSearchResModel.baseViewModel.Message = "查询兑换清单信息成功";
            productListSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询兑换清单信息成功");
            return Ok(productListSearchResModel);
        }




        /// <summary>
        /// 删除商品信息（软删除）
        /// </summary>
        /// <param name="integralCommodityDeleteViewModel"></param>
        /// <returns></returns>

        [HttpPost]

        public ActionResult<UserDeleteResModel> Manage_Integral_Commodity_Delete(IntegralCommodityDeleteViewModel integralCommodityDeleteViewModel)
        {
            UserDeleteResModel userDeleteResModel = new UserDeleteResModel();
            int DeleteResult = _userService.IntegralCommodity_Delete(integralCommodityDeleteViewModel);

            if (DeleteResult > 0)
            {
                userDeleteResModel.AddCount = DeleteResult;
                userDeleteResModel.IsSuccess = true;
                userDeleteResModel.baseViewModel.Message = "删除成功";
                userDeleteResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除商品信息（软删除），删除成功");
                return Ok(userDeleteResModel);
            }
            else
            {
                userDeleteResModel.AddCount = -1;
                userDeleteResModel.IsSuccess = false;
                userDeleteResModel.baseViewModel.Message = "删除失败";
                userDeleteResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除商品信息（软删除），删除失败");
                return Ok(userDeleteResModel);
            }



        }






        /// <summary>
        /// 新增物品清单的分数校验
        /// </summary>
        /// <param name="userIntegralCheckViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<ProductListCheckResModel> Manage_Product_List_Check(UserIntegralCheckViewModel userIntegralCheckViewModel)
        {
            int Temp;
            ProductListCheckResModel  productListCheckResModel = new ProductListCheckResModel();
            Temp = _userService.Product_List_Check(userIntegralCheckViewModel);
            if (Temp == 0)
            {
                productListCheckResModel.IsSuccess = true;
                productListCheckResModel.status = Temp;
                productListCheckResModel.baseViewModel.Message = "添加成功";
                productListCheckResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("新增物品清单成功");
                return Ok(productListCheckResModel);
            }
            else if(Temp==1)
            {
                productListCheckResModel.IsSuccess = false;
                productListCheckResModel.status = Temp;
                productListCheckResModel.baseViewModel.Message = "添加失败,分数已超";
                productListCheckResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("新增物品清单失败,分数已超");
                return Ok(productListCheckResModel);
            }
            else if(Temp == -1)
            {
                productListCheckResModel.IsSuccess = false;
                productListCheckResModel.status = Temp;
                productListCheckResModel.baseViewModel.Message = "添加失败,未查询到积分信息";
                productListCheckResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("新增物品清单失败,未查询到积分信息");
                return Ok(productListCheckResModel);
            }
            else 
            {
                productListCheckResModel.IsSuccess = false;
                productListCheckResModel.status = Temp;
                productListCheckResModel.baseViewModel.Message = "添加失败,系统异常";
                productListCheckResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("新增物品清单失败,系统异常");
                return Ok(productListCheckResModel);
            }
        }

    }
}