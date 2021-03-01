using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellUser;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.RoomViewModel.RequestViewModel;
using ViewModel.RoomViewModel.ResponseModel;
using Serilog;

namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class DataBaseTypeController : ControllerBase
    {
        private readonly IDataBaseTypeService _DataBaseTypeService;
        private readonly ILogger _ILogger;

        public DataBaseTypeController(IDataBaseTypeService dataBaseTypeService, ILogger logger)
        {
            _DataBaseTypeService = dataBaseTypeService;
            _ILogger = logger;
        }

        /// <summary>
        /// 根据楼查询区
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<DataBase_Type> Manage_FloorSearchArea(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {
            DataBaseTypeSearchResModel databasetypeSearchResModel = new DataBaseTypeSearchResModel();
            var Result = _DataBaseTypeService.SearchAreaByFloor(dataBaseTypeSearchViewModel);
            int count = _DataBaseTypeService.SearchAreaByFloorNum(dataBaseTypeSearchViewModel);

            databasetypeSearchResModel.Room_info = Result;
            databasetypeSearchResModel.TotalNum = count;
            databasetypeSearchResModel.isSuccess = true;
            databasetypeSearchResModel.baseViewModel.Message = "查询成功";
            databasetypeSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(databasetypeSearchResModel);

        }

        /// <summary>
        /// 查询基础信息
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<DataBase_Type> Manage_SearchAll(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {
            DataBaseTypeSearchResModel databasetypeSearchResModel = new DataBaseTypeSearchResModel();
            var Result = _DataBaseTypeService.DataBase_Search(dataBaseTypeSearchViewModel);
            int count = _DataBaseTypeService.DataBase_SearchNum(dataBaseTypeSearchViewModel);

            databasetypeSearchResModel.Room_info = Result;
            databasetypeSearchResModel.TotalNum = count;
            databasetypeSearchResModel.isSuccess = true;
            databasetypeSearchResModel.baseViewModel.Message = "查询成功";
            databasetypeSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据会议室信息，查询成功");
            return Ok(databasetypeSearchResModel);

        }
    }
}
