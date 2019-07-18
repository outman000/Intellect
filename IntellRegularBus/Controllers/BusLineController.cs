using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;
using ViewModel.BusViewModel.ResponseModel.LineInforResModel;

namespace IntellRegularBus.Controllers
{
    [Route("BusManageApi/[controller]/[action]")]
    [ApiController]
    public class BusLineController : ControllerBase
    {
        private readonly ILineService _lineService;

        public BusLineController(ILineService lineService)
        {
            _lineService = lineService;

        }

        /// <summary>
        /// 添加线路
        /// </summary>
        /// <param name="lineAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Line_Add(LineAddViewModel lineAddViewModel)
        {
            int Line_Add_Count;
            Line_Add_Count = _lineService.Line_Add(lineAddViewModel);
            LineAddResModel userAddResModel = new LineAddResModel();
            if (Line_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = Line_Add_Count;
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
    }
}