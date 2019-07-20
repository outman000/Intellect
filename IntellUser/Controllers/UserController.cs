﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellUser;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService  _userService;

       // private readonly IValidator<UserAddViewModel> _validator;



        public UserController(IUserService  userService)
        {
            _userService = userService;

        }
        /// <summary>
        /// 增添用户信息
        /// </summary>
        /// <param name="userAddViewModel"></param>
        /// <returns></returns>
       
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_User_add(UserAddViewModel userAddViewModel)
        {
            int User_Add_Count;
            User_Add_Count = _userService.User_Add(userAddViewModel);
            UserAddResModel userAddResModel = new UserAddResModel();
            if (User_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = User_Add_Count;
                userAddResModel.baseViewModel.Message = "添加成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userAddResModel);
            }
        }
        /// <summary>
        /// 用户名id验证是否重复
        /// </summary>
        /// <param name="userValideRepeat"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_User_ValideRepeat(UserValideRepeat userValideRepeat)
        {
            UserValideResRepeat userValideResRepeat = new UserValideResRepeat();
            bool ValideResutlt= _userService.User_Single(userValideRepeat);
            userValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                userValideResRepeat.IsSuccess = true;
                userValideResRepeat.baseViewModel.Message = "此id可以使用";
                userValideResRepeat.baseViewModel.ResponseCode = 200;
                return  Ok(userValideResRepeat);
            }
            else
            {
                userValideResRepeat.IsSuccess = false;
                userValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                userValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(userValideResRepeat);
            }
        }


        /// <summary>
        /// 删除用户信息（软删除）
        /// </summary>
        /// <param name="userDeleteViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Manage_User_Delete(UserDeleteViewModel userDeleteViewModel)
        {
            UserDeleteResModel userDeleteResModel = new UserDeleteResModel();
            int DeleteResult= _userService.User_Delete(userDeleteViewModel);

            if (DeleteResult > 0)
            {
                userDeleteResModel.AddCount = DeleteResult;
                userDeleteResModel.IsSuccess=true;
                userDeleteResModel.baseViewModel.Message = "删除成功";
                userDeleteResModel.baseViewModel.ResponseCode = 200;
                return Ok(userDeleteResModel);
            }
            else
            {
                userDeleteResModel.AddCount = -1;
                userDeleteResModel.IsSuccess = false;
                userDeleteResModel.baseViewModel.Message = "删除失败";
                userDeleteResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userDeleteResModel);
            }

         
          
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_User_Update(UserUpdateViewModel userUpdateViewModel)
        {
            UserUpdateResModel userValideResRepeat = new UserUpdateResModel();
            int UpdateRowNum = _userService.User_Update(userUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                userValideResRepeat.IsSuccess = true;
                userValideResRepeat.AddCount = UpdateRowNum;
                userValideResRepeat.baseViewModel.Message = "更新成功";
                userValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(userValideResRepeat);
            }
            else
            {
                userValideResRepeat.IsSuccess = false;
                userValideResRepeat.AddCount = 0;
                userValideResRepeat.baseViewModel.Message = "更新失败";
                userValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(userValideResRepeat);
            }
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_User_Search(UserSearchViewModel userSearchViewModel)
        {
           UserSearchResModel userSearchResModel = new UserSearchResModel();
            var UserSearchResult = _userService.User_Search(userSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = UserSearchResult.Count;
            userSearchResModel.user_Infos = UserSearchResult;
            userSearchResModel.isSuccess = true;
            userSearchResModel.baseViewModel.Message = "查询成功";
            userSearchResModel.baseViewModel.ResponseCode = 200;
            userSearchResModel.TotalNum = TotalNum;
            return Ok(userSearchResModel);

        }
      
        /// <summary>
        /// 根据部门 添加/删除 用户
        /// </summary>
        /// <param name="relateDepartToUserAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_User_Depart(RelateDepartToUserAddViewModel relateDepartToUserAddViewModel)
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
                return Ok(relateDepartToUserAddResModel);
            }
            else if(UpdateRowNum<totalnum)
            {
                relateDepartToUserAddResModel.IsSuccess = false;
                relateDepartToUserAddResModel.AddCount = 0;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据部门添加用户失败"+ (totalnum-UpdateRowNum) + "条";
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(relateDepartToUserAddResModel);
            }
            else
            {
                relateDepartToUserAddResModel.IsSuccess = false;
                relateDepartToUserAddResModel.AddCount = 0;
                relateDepartToUserAddResModel.baseViewModel.Message = "根据部门添加用户失败" ;
                relateDepartToUserAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(relateDepartToUserAddResModel);

            }

        }

        /// <summary>
        /// 根据角色查用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Role_By_User_Search(UserByRoleSearchViewModel userByRoleSearchViewModel)
        {
            UserByRoleSearchResModel userByRoleSearchResModel = new UserByRoleSearchResModel();
            userByRoleSearchResModel.userInfos = _userService.User_By_Role_Search(userByRoleSearchViewModel);

            if (userByRoleSearchResModel.userInfos.Count > 0)
            {
                userByRoleSearchResModel.IsSuccess = true;
                userByRoleSearchResModel.TotalNum = userByRoleSearchResModel.userInfos.Count;
                userByRoleSearchResModel.baseViewModel.Message = "根据用户查询成功";
                userByRoleSearchResModel.baseViewModel.ResponseCode = 200;
                return Ok(userByRoleSearchResModel);
            }
            else
            {
                userByRoleSearchResModel.IsSuccess = false;
                userByRoleSearchResModel.TotalNum = userByRoleSearchResModel.userInfos.Count;
                userByRoleSearchResModel.baseViewModel.Message = "根据用户查询失败";
                userByRoleSearchResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userByRoleSearchResModel);
            }
        }



    }
}