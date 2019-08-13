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
                _ILogger.Information("增添菜单信息成功");
                return Ok(bulletinBoardAddResModel);
            }
            else
            {
                bulletinBoardAddResModel.IsSuccess = false;
                bulletinBoardAddResModel.AddCount = 0;
                bulletinBoardAddResModel.baseViewModel.Message = "添加失败";
                bulletinBoardAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添菜单信息失败");
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
                _ILogger.Information("更新菜单信息成功");
                return Ok(bulletinBoardUpdateResModel);
            }
            else
            {
                bulletinBoardUpdateResModel.IsSuccess = false;
                bulletinBoardUpdateResModel.AddCount = 0;
                bulletinBoardUpdateResModel.baseViewModel.Message = "更新失败";
                bulletinBoardUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新菜单信息失败");
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
                _ILogger.Information("删除菜单信息失败");
                return BadRequest(bulletinBoardDelResModel);
            }
        }
    }
}