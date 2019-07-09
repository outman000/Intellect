using System;
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
                userValideResRepeat.IsSuccess = true;
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
            var a = userDeleteViewModel;
            //_userService.User_Delete(userDeleteViewModel);

            return Ok();
         
          
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult Manage_User_Update(UserUpdateViewModel  userUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.User_Update(userUpdateViewModel);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
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
            return null;
        
        }



    }
}