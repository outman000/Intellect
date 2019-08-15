using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellBulletinBoard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.BulletinBoardViewModel.RequestViewModel;
using ViewModel.BulletinBoardViewModel.ResponseModel;
using SystemFilter.PublicFilter;

namespace IntellBulletinBoard.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BulletinBoardController : ControllerBase
    {
        private readonly IBulletinBoardService _bulletinBoardService;
        private readonly ILogger _ILogger;


        public BulletinBoardController(IBulletinBoardService  bulletinBoardService, ILogger logger)
        {
            _bulletinBoardService = bulletinBoardService;
            _ILogger = logger;

        }
        /// <summary>
        /// 增添公告栏信息
        /// </summary>
        /// <param name="bulletinBoardAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Food_Add(BulletinBoardAddViewModel bulletinBoardAddViewModel)
        {
            int BulletinBoard_Add_Count;
            BulletinBoard_Add_Count = _bulletinBoardService.BulletinBoard_Add(bulletinBoardAddViewModel);
            BulletinBoardAddResModel bulletinBoardAddResModel = new BulletinBoardAddResModel();
            if (BulletinBoard_Add_Count > 0)
            {
                bulletinBoardAddResModel.IsSuccess = true;
                bulletinBoardAddResModel.AddCount = BulletinBoard_Add_Count;
                bulletinBoardAddResModel.baseViewModel.Message = "添加成功";
                bulletinBoardAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添公告栏信息成功");
                return Ok(bulletinBoardAddResModel);
            }
            else
            {
                bulletinBoardAddResModel.IsSuccess = false;
                bulletinBoardAddResModel.AddCount = 0;
                bulletinBoardAddResModel.baseViewModel.Message = "添加失败";
                bulletinBoardAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添公告栏信息失败");
                return BadRequest(bulletinBoardAddResModel);
            }
        }
        /// <summary>
        /// 查询公告栏信息
        /// </summary>
        /// <param name="bulletinBoardSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_BulletinBoard_Search(BulletinBoardSearchViewModel bulletinBoardSearchViewModel)
        {
            BulletinBoardSearchResModel  bulletinBoardSearchResModel = new BulletinBoardSearchResModel();
            var BusSearchResult = _bulletinBoardService.Bulletin_Board_Search(bulletinBoardSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _bulletinBoardService.BulletinBoard_Get_ALLNum(bulletinBoardSearchViewModel);
            bulletinBoardSearchResModel.bulletinBoard_Infos = BusSearchResult;
            bulletinBoardSearchResModel.isSuccess = true;
            bulletinBoardSearchResModel.baseViewModel.Message = "查询成功";
            bulletinBoardSearchResModel.baseViewModel.ResponseCode = 200;
            bulletinBoardSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询公告栏信息成功");
            return Ok(bulletinBoardSearchResModel);

        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="bulletinBoardUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_BulletinBoard_Update(BulletinBoardUpdateViewModel bulletinBoardUpdateViewModel)
        {
            BulletinBoardUpdateResModel  bulletinBoardUpdateResModel = new BulletinBoardUpdateResModel();
            int UpdateRowNum = _bulletinBoardService.BulletinBoard_Update(bulletinBoardUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                bulletinBoardUpdateResModel.IsSuccess = true;
                bulletinBoardUpdateResModel.AddCount = UpdateRowNum;
                bulletinBoardUpdateResModel.baseViewModel.Message = "更新成功";
                bulletinBoardUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新公告栏信息成功");
                return Ok(bulletinBoardUpdateResModel);
            }
            else
            {
                bulletinBoardUpdateResModel.IsSuccess = false;
                bulletinBoardUpdateResModel.AddCount = 0;
                bulletinBoardUpdateResModel.baseViewModel.Message = "更新失败";
                bulletinBoardUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新公告栏信息失败");
                return BadRequest(bulletinBoardUpdateResModel);
            }
        }
        /// <summary>
        /// 删除公告栏信息
        /// </summary>
        /// <param name="bulletinBoardDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_BulletinBoard_Delete(BulletinBoardDelViewModel  bulletinBoardDelViewModel)
        {
            BulletinBoardDelResModel  bulletinBoardDelResModel = new BulletinBoardDelResModel();
            int DeleteResult = _bulletinBoardService.BulletinBoard_Delete(bulletinBoardDelViewModel);

            if (DeleteResult > 0)
            {
                bulletinBoardDelResModel.DelCount = DeleteResult;
                bulletinBoardDelResModel.IsSuccess = true;
                bulletinBoardDelResModel.baseViewModel.Message = "删除成功";
                bulletinBoardDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除公告栏信息成功");
                return Ok(bulletinBoardDelResModel);
            }
            else
            {
                bulletinBoardDelResModel.DelCount = -1;
                bulletinBoardDelResModel.IsSuccess = false;
                bulletinBoardDelResModel.baseViewModel.Message = "删除失败";
                bulletinBoardDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除公告栏信息失败");
                return BadRequest(bulletinBoardDelResModel);
            }
        }

        /// <summary>
        /// 根据公告栏查角色
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Role_By_Bulletin_Search(RoleByBulletinSearchViewModel  roleByBulletinSearchViewModel)
        {
            RoleByBulletinSearchResModel  roleByBulletinSearchResModel = new RoleByBulletinSearchResModel();
            roleByBulletinSearchResModel.userRoles = _bulletinBoardService.Role_By_Bulletin_Search(roleByBulletinSearchViewModel);


            roleByBulletinSearchResModel.IsSuccess = true;
            roleByBulletinSearchResModel.TotalNum = _bulletinBoardService.Role_By_Bulletin_Get_ALLNum(roleByBulletinSearchViewModel);
            roleByBulletinSearchResModel.baseViewModel.Message = "根据公告栏信息查询角色成功";
            roleByBulletinSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据公告栏信息查询角色成功");
            return Ok(roleByBulletinSearchResModel);

        }
        /// <summary>
        /// 给公告栏添加角色
        /// </summary>
        /// <param name="roleByBulletinAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_BulletinBoardToRole_Add(RoleByBulletinAddViewModel  roleByBulletinAddViewModel)
        {
            RoleByBulletinAddResModel  roleByBulletinAddResModel = new RoleByBulletinAddResModel();
            int UpdateRowNum = _bulletinBoardService.BulletinBoardToRole_Add(roleByBulletinAddViewModel);

            if (UpdateRowNum > 0)
            {
                roleByBulletinAddResModel.IsSuccess = true;
                roleByBulletinAddResModel.AddCount = UpdateRowNum;
                roleByBulletinAddResModel.baseViewModel.Message = "公告栏信息分配角色成功";
                roleByBulletinAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("给公告栏分配角色成功");
                return Ok(roleByBulletinAddResModel);
            }
            else
            {
                roleByBulletinAddResModel.IsSuccess = false;
                roleByBulletinAddResModel.AddCount = 0;
                roleByBulletinAddResModel.baseViewModel.Message = "公告栏信息分配角色失败";
                roleByBulletinAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("给公告栏分配角色失败");
                return BadRequest(roleByBulletinAddResModel);
            }
        }
        /// <summary>
        ///  根据公告栏删除角色
        /// </summary>
        /// <param name="roleByBulletinDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_UserRoleToUser_Del(RoleByBulletinDelViewModel  roleByBulletinDelViewModel)
        {
            RoleByBulletinDelResModel roleByBulletinDelResModel = new RoleByBulletinDelResModel();
            int DeleteRowNum = _bulletinBoardService.BulletinBoardToRole_Del(roleByBulletinDelViewModel);

            if (DeleteRowNum > 0)
            {
                roleByBulletinDelResModel.IsSuccess = true;
                roleByBulletinDelResModel.DelCount = DeleteRowNum;
                roleByBulletinDelResModel.baseViewModel.Message = "公告栏删除角色成功";
                roleByBulletinDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据公告栏删除角色成功");
                return Ok(roleByBulletinDelResModel);
            }
            else
            {
                roleByBulletinDelResModel.IsSuccess = false;
                roleByBulletinDelResModel.DelCount = 0;
                roleByBulletinDelResModel.baseViewModel.Message = "公告栏删除角色失败";
                roleByBulletinDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据公告栏删除角色失败");
                return BadRequest(roleByBulletinDelResModel);
            }
        }

        /// <summary>
        /// 根据用户id查询角色和公告栏信息
        /// </summary>
        /// <param name="bulletinByUserSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_BulletinByLogin_Search(BulletinByUserSearchViewModel bulletinByUserSearchViewModel)
        {
            BulletinByUserSearchResModel  bulletinByUserSearchResModel = new BulletinByUserSearchResModel();
            var UserSearchResult = _bulletinBoardService.BulletinByUserId_Search(bulletinByUserSearchViewModel);
            if (UserSearchResult.Bulletin_Board.Count < 1)
            {
                bulletinByUserSearchResModel.IsSuccess = false;
                bulletinByUserSearchResModel.baseViewModel.Message = "用户无权限查看公告信息";
                bulletinByUserSearchResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("用户无权限，查看公告失败");
                return BadRequest(bulletinByUserSearchResModel);
            }
            else
            {

                bulletinByUserSearchResModel.userInfo = UserSearchResult;
                bulletinByUserSearchResModel.IsSuccess = true;
                bulletinByUserSearchResModel.baseViewModel.Message = "存在可显示的公告，查询成功";
                bulletinByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询公告信息成功");
                return Ok(bulletinByUserSearchResModel);
            }
        }
    }
}