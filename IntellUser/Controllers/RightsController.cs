using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellUser;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;

// For more information on enabling Web API for empty projects, visit 

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class RightsController : ControllerBase
    {
        private readonly IRightsService _rightsService;

        public RightsController(IRightsService rightsService)
        {
            _rightsService = rightsService;

        }
        /// <summary>
        /// 增添权限信息
        /// </summary>
        /// <param name="rightsAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Rights_add(RightsAddViewModel rightsAddViewModel)
        {
            int Rights_Add_Count;
            Rights_Add_Count = _rightsService.Rights_Add(rightsAddViewModel);
            RightsAddResModel rightsAddResModel = new RightsAddResModel();
            if (Rights_Add_Count > 0)
            {
                rightsAddResModel.IsSuccess = true;
                rightsAddResModel.AddCount = Rights_Add_Count;
                rightsAddResModel.baseViewModel.Message = "添加成功";
                rightsAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(rightsAddResModel);
            }
            else
            {
                rightsAddResModel.IsSuccess = false;
                rightsAddResModel.AddCount = 0;
                rightsAddResModel.baseViewModel.Message = "添加失败";
                rightsAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(rightsAddResModel);
            }
        }

        /// <summary>
        /// 权限名id验证是否重复
        /// </summary>
        /// <param name="rightsValideRepeat"></param>

        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Rights_ValideRepeat(RightsValideRepeat rightsValideRepeat)
        {
            RightsValideResRepeat rightsValideResRepeat = new RightsValideResRepeat();
            bool ValideResutlt = _rightsService.Rights_Single(rightsValideRepeat);
            rightsValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                rightsValideResRepeat.IsSuccess = true;
                rightsValideResRepeat.baseViewModel.Message = "此id可以使用";
                rightsValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(rightsValideResRepeat);
            }
            else
            {
                rightsValideResRepeat.IsSuccess = false;
                rightsValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                rightsValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(rightsValideResRepeat);
            }
        }

        /// <summary>
        /// 删除权限信息（直接删除）
        /// </summary>
        /// <param name="rightsDeleteViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Manage_Rights_Delete(RightsDeleteViewModel rightsDeleteViewModel)
        {
            RightsDeleteResModel rightsDeleteResModel = new RightsDeleteResModel();
            int DeleteResult = _rightsService.Rights_Delete(rightsDeleteViewModel);

            if (DeleteResult > 0)
            {
                rightsDeleteResModel.AddCount = DeleteResult;
                rightsDeleteResModel.IsSuccess = true;
                rightsDeleteResModel.baseViewModel.Message = "删除成功";
                rightsDeleteResModel.baseViewModel.ResponseCode = 200;
                return Ok(rightsDeleteResModel);
            }
            else
            {
                rightsDeleteResModel.AddCount = -1;
                rightsDeleteResModel.IsSuccess = false;
                rightsDeleteResModel.baseViewModel.Message = "删除失败";
                rightsDeleteResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(rightsDeleteResModel);
            }

        }

        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="rightsUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Rights_Update(RightsUpdateViewModel rightsUpdateViewModel)
        {
            RightsUpdateResModel rightsValideResRepeat = new RightsUpdateResModel();
            int UpdateRowNum = _rightsService.Rights_Update(rightsUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                rightsValideResRepeat.IsSuccess = true;
                rightsValideResRepeat.AddCount = UpdateRowNum;
                rightsValideResRepeat.baseViewModel.Message = "更新成功";
                rightsValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(rightsValideResRepeat);
            }
            else
            {
                rightsValideResRepeat.IsSuccess = false;
                rightsValideResRepeat.AddCount = 0;
                rightsValideResRepeat.baseViewModel.Message = "更新失败";
                rightsValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(rightsValideResRepeat);
            }
        }
        /// <summary>
        /// 查询权限信息
        /// </summary>
        /// <param name="rightsSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult Manage_Rights_Search(RightsSearchViewModel rightsSearchViewModel)
        {
            RightsSearchResModel rightsSearchResModel = new RightsSearchResModel();
            var RightsSearchResult = _rightsService.Rights_Search(rightsSearchViewModel);
            var TotalNum = _rightsService.Rights_Get_ALLNum();
            rightsSearchResModel.user_Rights = RightsSearchResult;
            rightsSearchResModel.isSuccess = true;
            rightsSearchResModel.baseViewModel.Message = "查询成功";
            rightsSearchResModel.baseViewModel.ResponseCode = 200;
            rightsSearchResModel.TotalNum = TotalNum;
            return Ok(rightsSearchResModel);

        }
        /// <summary>
        /// 根据角色查权限
        /// </summary>
        /// <param name="rightsByRoleSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Rights_By_Role_Search(RightsByRoleSearchViewModel rightsByRoleSearchViewModel)
        {
            RightsByRoleSearchResModel rightsByRoleSearchResModel = new RightsByRoleSearchResModel();
            rightsByRoleSearchResModel.userRights = _rightsService.Rights_By_Role_Search(rightsByRoleSearchViewModel);

            if (rightsByRoleSearchResModel.userRights.Count > 0)
            {
                rightsByRoleSearchResModel.IsSuccess = true;
                rightsByRoleSearchResModel.TotalNum = rightsByRoleSearchResModel.userRights.Count;
                rightsByRoleSearchResModel.baseViewModel.Message = "根据角色查询权限成功";
                rightsByRoleSearchResModel.baseViewModel.ResponseCode = 200;
                return Ok(rightsByRoleSearchResModel);
            }
            else
            {
                rightsByRoleSearchResModel.IsSuccess = false;
                rightsByRoleSearchResModel.TotalNum = rightsByRoleSearchResModel.userRights.Count;
                rightsByRoleSearchResModel.baseViewModel.Message = "根据角色查询权限失败";
                rightsByRoleSearchResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(rightsByRoleSearchResModel);
            }
        }

    }
}
