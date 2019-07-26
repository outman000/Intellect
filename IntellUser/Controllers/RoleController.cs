
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
        public ActionResult Manage_UserRole_Search(UserRoleSearchViewModel  userRoleSearchViewModel)
        {
            UserRoleSearchResModel userRoleSearchResModel=new UserRoleSearchResModel();
            var UserRoleSearchResult = _roleService.User_Role_Search(userRoleSearchViewModel);
            var TotalNum = _roleService.Role_Get_ALLNum(userRoleSearchViewModel);
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
        /// 给角色配置人员 / 给人员配置角色
        /// </summary>
        /// <param name="relateRoleToUserAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_UserRoleToUser_Add(RelateRoleToUserAddViewModel  relateRoleToUserAddViewModel)
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

        /// <summary>
        /// 根据角色删除人员 / 根据人员删除角色
        /// </summary>
        /// <param name="relateRoleToUserDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_UserRoleToUser_Del(RelateRoleToUserDelViewModel relateRoleToUserDelViewModel)
        {
            RelateRoleToRightDelResModel relateRoleToUserDelResModel = new RelateRoleToRightDelResModel();
            int DeleteRowNum = _roleService.User_RoleToUser_Del(relateRoleToUserDelViewModel);

            if (DeleteRowNum > 0)
            {
                relateRoleToUserDelResModel.IsSuccess = true;
                relateRoleToUserDelResModel.DelCount = DeleteRowNum;
                relateRoleToUserDelResModel.baseViewModel.Message = "角色删除用户成功";
                relateRoleToUserDelResModel.baseViewModel.ResponseCode = 200;
                return Ok(relateRoleToUserDelResModel);
            }
            else
            {
                relateRoleToUserDelResModel.IsSuccess = false;
                relateRoleToUserDelResModel.DelCount = 0;
                relateRoleToUserDelResModel.baseViewModel.Message = "角色删除用户失败";
                relateRoleToUserDelResModel.baseViewModel.ResponseCode = 400;
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
        public ActionResult Manage_UserRoleToRight_Add(RelateRoleToRightAddViewModel relateRoleToRightAddViewModel)
        {
            RelateRoleToRightAddResModel relateRoleToRightAddResModel = new RelateRoleToRightAddResModel();
            int AddRowNum = _roleService.User_RoleToRights_Add(relateRoleToRightAddViewModel);

            if (AddRowNum > 0)
            {
                relateRoleToRightAddResModel.IsSuccess = true;
                relateRoleToRightAddResModel.AddCount = AddRowNum;
                relateRoleToRightAddResModel.baseViewModel.Message = "角色分配权限户成功";
                relateRoleToRightAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(relateRoleToRightAddResModel);
            }
            else
            {
                relateRoleToRightAddResModel.IsSuccess = false;
                relateRoleToRightAddResModel.AddCount = 0;
                relateRoleToRightAddResModel.baseViewModel.Message = "角色分配权限失败";
                relateRoleToRightAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(relateRoleToRightAddResModel);
            }
        }

        /// <summary>
        /// 给角色删除权限
        /// </summary>
        /// <param name="relateRoleToRightDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
       
        public ActionResult Manage_UserRoleToRight_Del(RelateRoleToRightDelViewModel relateRoleToRightDelViewModel)
        {
            RelateRoleToRightDelResModel relateRoleToRightDelResModel = new RelateRoleToRightDelResModel();
            int DeleteRowNum = _roleService.User_RoleToRight_Del(relateRoleToRightDelViewModel);

            if (DeleteRowNum > 0)
            {
                relateRoleToRightDelResModel.IsSuccess = true;
                relateRoleToRightDelResModel.DelCount = DeleteRowNum;
                relateRoleToRightDelResModel.baseViewModel.Message = "权限删除用户成功";
                relateRoleToRightDelResModel.baseViewModel.ResponseCode = 200;
                return Ok(relateRoleToRightDelResModel);
            }
            else
            {
                relateRoleToRightDelResModel.IsSuccess = false;
                relateRoleToRightDelResModel.DelCount = 0;
                relateRoleToRightDelResModel.baseViewModel.Message = "权限删除用户失败";
                relateRoleToRightDelResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(relateRoleToRightDelResModel);
            }
        }


        /// <summary>
        /// 根据用户查角色
        /// </summary>
        /// <param name="roleByUserSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Role_By_User_Search(RoleByUserSearchViewModel roleByUserSearchViewModel)
        {
            RoleByUserSearchResModel roleByUserSearchResModel = new RoleByUserSearchResModel();
            roleByUserSearchResModel.userRoles = _roleService.Role_By_User_Search(roleByUserSearchViewModel);

            if (roleByUserSearchResModel.userRoles.Count > 0)
            {
                roleByUserSearchResModel.IsSuccess = true;
                roleByUserSearchResModel.TotalNum = _roleService.Role_By_User_Get_ALLNum(roleByUserSearchViewModel);
                roleByUserSearchResModel.baseViewModel.Message = "根据用户查询角色成功";
                roleByUserSearchResModel.baseViewModel.ResponseCode = 200;
                return Ok(roleByUserSearchResModel);
            }
            else
            {
                roleByUserSearchResModel.IsSuccess = false;
                roleByUserSearchResModel.TotalNum = roleByUserSearchResModel.userRoles.Count;
                roleByUserSearchResModel.baseViewModel.Message = "根据用户查询角色失败";
                roleByUserSearchResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(roleByUserSearchResModel);
            }
        }


        /// <summary>
        /// 根据权限查角色
        /// </summary>
        /// <param name="roleByRightsSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Role_By_Rights_Search(RoleByRightsSearchViewModel roleByRightsSearchViewModel)
        {
            RoleByRightsSearchResModel roleByRightsSearchResModel = new RoleByRightsSearchResModel();
            roleByRightsSearchResModel.userRoles = _roleService.Role_By_Rights_Search(roleByRightsSearchViewModel);

            if (roleByRightsSearchResModel.userRoles.Count > 0)
            {
                roleByRightsSearchResModel.IsSuccess = true;
                roleByRightsSearchResModel.TotalNum = _roleService.Role_By_Rights_Get_ALLNum(roleByRightsSearchViewModel);
                roleByRightsSearchResModel.baseViewModel.Message = "根据权限查询角色成功";
                roleByRightsSearchResModel.baseViewModel.ResponseCode = 200;
                return Ok(roleByRightsSearchResModel);
            }
            else
            {
                roleByRightsSearchResModel.IsSuccess = false;
                roleByRightsSearchResModel.TotalNum = roleByRightsSearchResModel.userRoles.Count;
                roleByRightsSearchResModel.baseViewModel.Message = "根据权限查询角色失败";
                roleByRightsSearchResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(roleByRightsSearchResModel);
            }
        }
    }
}