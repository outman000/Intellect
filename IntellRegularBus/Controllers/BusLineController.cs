using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellRegularBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.BusViewModel.MiddleModel;
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

        /// <summary>
        /// 查询线路信息
        /// </summary>
        /// <param name="lineSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Line_Search(LineSearchViewModel lineSearchViewModel)
        {
            LineSearchResModel lineSearchResModel = new LineSearchResModel();
            var LineSearchResult = _lineService.Line_Search(lineSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = LineSearchResult.Count;
            lineSearchResModel.bus_Line  = LineSearchResult;
            lineSearchResModel.isSuccess = true;
            lineSearchResModel.baseViewModel.Message = "查询成功";
            lineSearchResModel.baseViewModel.ResponseCode = 200;
            lineSearchResModel.TotalNum = TotalNum;
            return Ok(lineSearchResModel);

        }

        /// <summary>
        /// 删除线路
        /// </summary>
        /// <param name="busDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Line_Del(LineDelViewModel lineDelViewModel)
        {
            LineDelResModel lineDelResModel = new LineDelResModel();
            int DeleteResult = _lineService.Line_Delete(lineDelViewModel);

            if (DeleteResult > 0)
            {
                lineDelResModel.DelCount = DeleteResult;
                lineDelResModel.IsSuccess = true;
                lineDelResModel.baseViewModel.Message = "删除成功";
                lineDelResModel.baseViewModel.ResponseCode = 200;
                return Ok(lineDelResModel);
            }
            else
            {
                lineDelResModel.DelCount = -1;
                lineDelResModel.IsSuccess = false;
                lineDelResModel.baseViewModel.Message = "删除失败";
                lineDelResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(lineDelResModel);
            }
        }

        /// <summary>
        /// 验证线路id是否重复
        /// </summary>
        /// <param name="busValideRepeat"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Line_ValideRepeat(BusValideRepeat busValideRepeat)
        {
            BusValideResRepeat busValideResRepeat = new BusValideResRepeat();
            bool ValideResutlt = _lineService.Line_Single(busValideRepeat);
            busValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                busValideResRepeat.IsSuccess = true;
                busValideResRepeat.baseViewModel.Message = "此id可以使用";
                busValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(busValideResRepeat);
            }
            else
            {
                busValideResRepeat.IsSuccess = false;
                busValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                busValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(busValideResRepeat);
            }
        }

        /// <summary>
        /// 更新线路信息
        /// </summary>
        /// <param name="lineUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Line_Update(LineUpdateViewModel lineUpdateViewModel)
        {
            LineUpdateResModel lineUpdateResModel = new LineUpdateResModel();
            int UpdateRowNum = _lineService.Line_Update(lineUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                lineUpdateResModel.IsSuccess = true;
                lineUpdateResModel.AddCount = UpdateRowNum;
                lineUpdateResModel.baseViewModel.Message = "更新成功";
                lineUpdateResModel.baseViewModel.ResponseCode = 200;
                return Ok(lineUpdateResModel);
            }
            else
            {
                lineUpdateResModel.IsSuccess = false;
                lineUpdateResModel.AddCount = 0;
                lineUpdateResModel.baseViewModel.Message = "更新失败";
                lineUpdateResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(lineUpdateResModel);
            }
        }

    }
}