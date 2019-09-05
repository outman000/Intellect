
using Serilog;
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
        private readonly ILogger _ILogger;
        public RoleController(IRoleService  roleService, ILogger logger)
        {
            _roleService = roleService;
            _ILogger = logger;

        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="userRoleAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult<UserRoleAddResModel> Manage_UserRole_add(UserRoleAddViewModel  userRoleAddViewModel)
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
                _ILogger.Information("添加角色成功");
                return Ok(userRoleAddResModel);
            }
            else
            {
                userRoleAddResModel.IsSuccess = false;
                userRoleAddResModel.AddCount = 0;
                userRoleAddResModel.baseViewModel.Message = "添加失败";
                userRoleAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("添加角色失败");
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
        public ActionResult<UserRoleSingleResModel> Manage_UserRole_Single(UserRoleSingleViewModel userRoleSingleViewModel)
        {
            bool IsSuccess = _roleService.User_Role_Single(userRoleSingleViewModel);
            UserRoleSingleResModel  userRoleSingleResModel =new UserRoleSingleResModel();
            if (IsSuccess)
            {
                userRoleSingleResModel.IsSuccess = IsSuccess;
                userRoleSingleResModel.baseViewModel.Message = "角色可以添加";
                userRoleSingleResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("添加角色标识唯一性验证,角色可以添加");
                return Ok(userRoleSingleResModel);
            }
            else
            {
                userRoleSingleResModel.IsSuccess = false;
                userRoleSingleResModel.baseViewModel.Message = "角色id重复请修改";
                userRoleSingleResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("添加角色标识唯一性验证,角色id重复请修改");
                return BadRequest(userRoleSingleResModel);
            }
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="userRoleDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UserRoleDeleteResModel> Manage_UserRole_Delete(UserRoleDeleteViewModel  userRoleDeleteViewModel)
        {
            UserRoleDeleteResModel userRoleDeleteResModel = new UserRoleDeleteResModel();
            int DeleteResult = _roleService.User_Role_Delete(userRoleDeleteViewModel);

            if (DeleteResult > 0)
            {
                userRoleDeleteResModel.AddCount = DeleteResult;
                userRoleDeleteResModel.IsSuccess = true;
                userRoleDeleteResModel.baseViewModel.Message = "删除成功";
                userRoleDeleteResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除角色成功");
                return Ok(userRoleDeleteResModel);
            }
            else
            {
                userRoleDeleteResModel.AddCount = -1;
                userRoleDeleteResModel.IsSuccess = false;
                userRoleDeleteResModel.baseViewModel.Message = "删除失败";
                userRoleDeleteResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除角色失败");
                return BadRequest(userRoleDeleteResModel);
            }
        }

        /// <summary>
        /// 角色查询
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UserRoleSearchResModel> Manage_UserRole_Search(UserRoleSearchViewModel  userRoleSearchViewModel)
        {
            UserRoleSearchResModel userRoleSearchResModel=new UserRoleSearchResModel();
            var UserRoleSearchResult = _roleService.User_Role_Search(userRoleSearchViewModel);
            var TotalNum = _roleService.Role_Get_ALLNum(userRoleSearchViewModel);
            userRoleSearchResModel.userRoles = UserRoleSearchResult;
            userRoleSearchResModel.isSuccess = true;
            userRoleSearchResModel.baseViewModel.Message = "查询成功";
            userRoleSearchResModel.baseViewModel.ResponseCode = 200;
            userRoleSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("角色查询成功");
            return Ok(userRoleSearchResModel);

        }


        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="userRoleUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<UserUpdateResModel> Manage_UserRole_Update(UserRoleUpdateViewModel  userRoleUpdateViewModel)
        {
            UserUpdateResModel userUpdateResModel = new UserUpdateResModel();
            int UpdateRowNum = _roleService.User_Role_Update(userRoleUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                userUpdateResModel.IsSuccess = true;
                userUpdateResModel.AddCount = UpdateRowNum;
                userUpdateResModel.baseViewModel.Message = "更新成功";
                userUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("角色更新成功");
                return Ok(userUpdateResModel);
            }
            else
            {
                userUpdateResModel.IsSuccess = false;
                userUpdateResModel.AddCount = 0;
                userUpdateResModel.baseViewModel.Message = "更新失败";
                userUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("角色更新失败");
                return BadRequest(userUpdateResModel);
            }
        }

        /// <summary>
        /// 给角色配置人员 / 给人员配置角色
        /// </summary>
        /// <param name="relateRoleToUserAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RelateRoleToUserAddResModel> Manage_UserRoleToUser_Add(RelateRoleToUserAddViewModel  relateRoleToUserAddViewModel)
        {
           RelateRoleToUserAddResModel relateRoleToUserAddResModel=new RelateRoleToUserAddResModel();
            int UpdateRowNum = _roleService.User_RoleToUser_Add(relateRoleToUserAddViewModel);

            if (UpdateRowNum > 0)
            {
                relateRoleToUserAddResModel.IsSuccess = true;
                relateRoleToUserAddResModel.AddCount = UpdateRowNum;
                relateRoleToUserAddResModel.baseViewModel.Message = "角色分配用户成功";
                relateRoleToUserAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("给角色分配用户成功");
                return Ok(relateRoleToUserAddResModel);
            }
            else
            {
                relateRoleToUserAddResModel.IsSuccess = false;
                relateRoleToUserAddResModel.AddCount = 0;
                relateRoleToUserAddResModel.baseViewModel.Message = "角色分配用户失败";
                relateRoleToUserAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("给角色分配用户失败");
                return BadRequest(relateRoleToUserAddResModel);
            }
        }

        /// <summary>
        /// 根据角色删除人员 / 根据人员删除角色
        /// </summary>
        /// <param name="relateRoleToUserDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RelateRoleToRightDelResModel> Manage_UserRoleToUser_Del(RelateRoleToUserDelViewModel relateRoleToUserDelViewModel)
        {
            RelateRoleToRightDelResModel relateRoleToUserDelResModel = new RelateRoleToRightDelResModel();
            int DeleteRowNum = _roleService.User_RoleToUser_Del(relateRoleToUserDelViewModel);

            if (DeleteRowNum > 0)
            {
                relateRoleToUserDelResModel.IsSuccess = true;
                relateRoleToUserDelResModel.DelCount = DeleteRowNum;
                relateRoleToUserDelResModel.baseViewModel.Message = "角色删除用户成功";
                relateRoleToUserDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据角色删除人员成功");
                return Ok(relateRoleToUserDelResModel);
            }
            else
            {
                relateRoleToUserDelResModel.IsSuccess = false;
                relateRoleToUserDelResModel.DelCount = 0;
                relateRoleToUserDelResModel.baseViewModel.Message = "角色删除用户失败";
                relateRoleToUserDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据角色删除人员失败");
                return BadRequest(relateRoleToUserDelResModel);
            }
        }


        /// <summary>
        /// 给角色配置权限 
        /// </summary>
        /// <param name="relateRoleToRightAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<RelateRoleToRightAddResModel> Manage_UserRoleToRight_Add(RelateRoleToRightAddViewModel relateRoleToRightAddViewModel)
        {
            RelateRoleToRightAddResModel relateRoleToRightAddResModel = new RelateRoleToRightAddResModel();
            int AddRowNum = _roleService.User_RoleToRights_Add(relateRoleToRightAddViewModel);

            if (AddRowNum > 0)
            {
                relateRoleToRightAddResModel.IsSuccess = true;
                relateRoleToRightAddResModel.AddCount = AddRowNum;
                relateRoleToRightAddResModel.baseViewModel.Message = "角色分配权限成功";
                relateRoleToRightAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("给角色配置权限成功");
                return Ok(relateRoleToRightAddResModel);
            }
            else
            {
                relateRoleToRightAddResModel.IsSuccess = false;
                relateRoleToRightAddResModel.AddCount = 0;
                relateRoleToRightAddResModel.baseViewModel.Message = "角色分配权限失败";
                relateRoleToRightAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("给角色配置权限失败");
                return BadRequest(relateRoleToRightAddResModel);
            }
        }

        /// <summary>
        /// 给角色删除权限
        /// </summary>
        /// <param name="relateRoleToRightDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
       
        public ActionResult<RelateRoleToRightDelResModel> Manage_UserRoleToRight_Del(RelateRoleToRightDelViewModel relateRoleToRightDelViewModel)
        {
            RelateRoleToRightDelResModel relateRoleToRightDelResModel = new RelateRoleToRightDelResModel();
            int DeleteRowNum = _roleService.User_RoleToRight_Del(relateRoleToRightDelViewModel);

            if (DeleteRowNum > 0)
            {
                relateRoleToRightDelResModel.IsSuccess = true;
                relateRoleToRightDelResModel.DelCount = DeleteRowNum;
                relateRoleToRightDelResModel.baseViewModel.Message = "权限删除用户成功";
                relateRoleToRightDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("给角色删除权限成功");
                return Ok(relateRoleToRightDelResModel);
            }
            else
            {
                relateRoleToRightDelResModel.IsSuccess = false;
                relateRoleToRightDelResModel.DelCount = 0;
                relateRoleToRightDelResModel.baseViewModel.Message = "权限删除用户失败";
                relateRoleToRightDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("给角色删除权限失败");
                return BadRequest(relateRoleToRightDelResModel);
            }
        }


        /// <summary>
        /// 根据用户查角色
        /// </summary>
        /// <param name="roleByUserSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RoleByUserSearchResModel> Manage_Role_By_User_Search(RoleByUserSearchViewModel roleByUserSearchViewModel)
        {
            RoleByUserSearchResModel roleByUserSearchResModel = new RoleByUserSearchResModel();
            roleByUserSearchResModel.userRoles = _roleService.Role_By_User_Search(roleByUserSearchViewModel);


                roleByUserSearchResModel.IsSuccess = true;
                roleByUserSearchResModel.TotalNum = _roleService.Role_By_User_Get_ALLNum(roleByUserSearchViewModel);
                roleByUserSearchResModel.baseViewModel.Message = "根据用户查询角色成功";
                roleByUserSearchResModel.baseViewModel.ResponseCode = 200;
               _ILogger.Information("根据用户查询角色成功");
            return Ok(roleByUserSearchResModel);
          
        }


        /// <summary>
        /// 根据权限查角色
        /// </summary>
        /// <param name="roleByRightsSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RoleByRightsSearchResModel> Manage_Role_By_Rights_Search(RoleByRightsSearchViewModel roleByRightsSearchViewModel)
        {
            RoleByRightsSearchResModel roleByRightsSearchResModel = new RoleByRightsSearchResModel();
            roleByRightsSearchResModel.userRoles = _roleService.Role_By_Rights_Search(roleByRightsSearchViewModel);

         
                roleByRightsSearchResModel.IsSuccess = true;
                roleByRightsSearchResModel.TotalNum = _roleService.Role_By_Rights_Get_ALLNum(roleByRightsSearchViewModel);
                roleByRightsSearchResModel.baseViewModel.Message = "根据权限查询角色成功";
                roleByRightsSearchResModel.baseViewModel.ResponseCode = 200;
               _ILogger.Information("根据权限查询角色成功");
            return Ok(roleByRightsSearchResModel);
          
        }
    }
}