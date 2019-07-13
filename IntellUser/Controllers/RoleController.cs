
using Dto.IService.IntellUser;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService  roleService)
        {
            _roleService = roleService;

        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="userRoleAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_UserRole_add(UserRoleAddViewModel  userRoleAddViewModel)
        {
            int User_Add_Count;
            User_Add_Count = _roleService.User_Role_Add(userRoleAddViewModel);
            UserRoleAddResModel userRoleAddResModel=new UserRoleAddResModel();
            if (User_Add_Count > 0)
            {
                userRoleAddResModel.IsSuccess = true;
                userRoleAddResModel.AddCount = User_Add_Count;
                userRoleAddResModel.baseViewModel.Message = "添加成功";
                userRoleAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(userRoleAddResModel);
            }
            else
            {
                userRoleAddResModel.IsSuccess = false;
                userRoleAddResModel.AddCount = 0;
                userRoleAddResModel.baseViewModel.Message = "添加失败";
                userRoleAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userRoleAddResModel);
            }
        }

        /// <summary>
        /// 添加角色标识唯一性验证
        /// </summary>
        /// <param name="userRoleSingleViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_UserRole_Single(UserRoleSingleViewModel userRoleSingleViewModel)
        {
            bool IsSuccess = _roleService.User_Role_Single(userRoleSingleViewModel);
            UserRoleSingleResModel  userRoleSingleResModel =new UserRoleSingleResModel();
            if (IsSuccess)
            {
                userRoleSingleResModel.IsSuccess = IsSuccess;
                userRoleSingleResModel.baseViewModel.Message = "角色可以添加";
                userRoleSingleResModel.baseViewModel.ResponseCode = 200;
                return Ok(userRoleSingleResModel);
            }
            else
            {
                userRoleSingleResModel.IsSuccess = false;
                userRoleSingleResModel.baseViewModel.Message = "角色id重复请修改";
                userRoleSingleResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userRoleSingleResModel);
            }
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="userRoleDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_UserRole_Delete(UserRoleDeleteViewModel  userRoleDeleteViewModel)
        {
            UserRoleDeleteResModel userRoleDeleteResModel = new UserRoleDeleteResModel();
            int DeleteResult = _roleService.User_Role_Delete(userRoleDeleteViewModel);

            if (DeleteResult > 0)
            {
                userRoleDeleteResModel.AddCount = DeleteResult;
                userRoleDeleteResModel.IsSuccess = true;
                userRoleDeleteResModel.baseViewModel.Message = "删除成功";
                userRoleDeleteResModel.baseViewModel.ResponseCode = 200;
                return Ok(userRoleDeleteResModel);
            }
            else
            {
                userRoleDeleteResModel.AddCount = -1;
                userRoleDeleteResModel.IsSuccess = false;
                userRoleDeleteResModel.baseViewModel.Message = "删除失败";
                userRoleDeleteResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userRoleDeleteResModel);
            }
        }

        /// <summary>
        /// 角色查询
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_UserRole_Search(UserRoleSearchViewModel  userRoleSearchViewModel)
        {
            UserRoleSearchResModel userRoleSearchResModel=new UserRoleSearchResModel();
            var UserRoleSearchResult = _roleService.User_Role_Search(userRoleSearchViewModel);
            var TotalNum = _roleService.User_Role_GetAllNum();
            userRoleSearchResModel.userRoles = UserRoleSearchResult;
            userRoleSearchResModel.isSuccess = true;
            userRoleSearchResModel.baseViewModel.Message = "查询成功";
            userRoleSearchResModel.baseViewModel.ResponseCode = 200;
            userRoleSearchResModel.TotalNum = TotalNum;
            return Ok(userRoleSearchResModel);

        }


        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="userRoleUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_UserRole_Update(UserRoleUpdateViewModel  userRoleUpdateViewModel)
        {
            UserUpdateResModel userUpdateResModel = new UserUpdateResModel();
            int UpdateRowNum = _roleService.User_Role_Update(userRoleUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                userUpdateResModel.IsSuccess = true;
                userUpdateResModel.AddCount = UpdateRowNum;
                userUpdateResModel.baseViewModel.Message = "更新成功";
                userUpdateResModel.baseViewModel.ResponseCode = 200;
                return Ok(userUpdateResModel);
            }
            else
            {
                userUpdateResModel.IsSuccess = false;
                userUpdateResModel.AddCount = 0;
                userUpdateResModel.baseViewModel.Message = "更新失败";
                userUpdateResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userUpdateResModel);
            }
        }

        /// <summary>
        /// 给角色配置人员
        /// </summary>
        /// <param name="relateRoleToUserAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_UserRoleToUser_Add(RelateRoleToUserAddViewModel  relateRoleToUserAddViewModel  )
        {
           RelateRoleToUserAddResModel relateRoleToUserAddResModel=new RelateRoleToUserAddResModel();
            int UpdateRowNum = _roleService.User_RoleToUser_Add(relateRoleToUserAddViewModel);

            if (UpdateRowNum > 0)
            {
                relateRoleToUserAddResModel.IsSuccess = true;
                relateRoleToUserAddResModel.AddCount = UpdateRowNum;
                relateRoleToUserAddResModel.baseViewModel.Message = "角色分配用户成功";
                relateRoleToUserAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(relateRoleToUserAddResModel);
            }
            else
            {
                relateRoleToUserAddResModel.IsSuccess = false;
                relateRoleToUserAddResModel.AddCount = 0;
                relateRoleToUserAddResModel.baseViewModel.Message = "角色分配用户失败";
                relateRoleToUserAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(relateRoleToUserAddResModel);
            }
        }




    }
}