using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.BusViewModel.RequestViewModel.BusInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.BusInfoViewModel;

namespace IntellRegularBus.Controllers
{
    [Route("BusManageApi/[controller]/[action]")]
    [ApiController]
    public class BusInfoController : ControllerBase
    {

        private readonly IBusService _busService;



        public BusInfoController(IBusService busService)
        {
            _busService = busService;

        }

        /// <summary>
        /// 查询班车信息
        /// </summary>
        /// <param name="busSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Bus_Search(BusSearchViewModel busSearchViewModel)
        {
            BusSearchResModel busSearchResModel = new BusSearchResModel();
            var BusSearchResult = _busService.Bus_Search(busSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = BusSearchResult.Count;
            busSearchResModel.bus_Infos = BusSearchResult;
            busSearchResModel.isSuccess = true;
            busSearchResModel.baseViewModel.Message = "查询成功";
            busSearchResModel.baseViewModel.ResponseCode = 200;
            busSearchResModel.TotalNum = TotalNum;
            return Ok(busSearchResModel);

        }
    }
}