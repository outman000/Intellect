using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellOpinionInfo;


using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.OpinionInfoViewModel.RequestViewModel;
using ViewModel.OpinionInfoViewModel.ResponseModel;
using ViewModel.SuggestBoxViewModel.RequestViewModel;
using Microsoft.AspNetCore.Authorization;

namespace IntellSuggest.Controllers
{
    [Route("OpinionInfoManageApi/[controller]/[action]")]
    [ApiController]
    public class OpinionInfoController : ControllerBase
    {
        private readonly IOpinionInfoService _opinionInfoService;
        private readonly ILogger _ILogger;
        public OpinionInfoController(IOpinionInfoService  opinionInfoService, ILogger logger)
        {
            _opinionInfoService = opinionInfoService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增添领导回复意见信息
        /// </summary>
        /// <param name="opinionInfoAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        [Authorize]
        public ActionResult<OpinionInfoAddResModel> Manage_OpinionInfo_Add(OpinionInfoAddViewModel opinionInfoAddViewModel)
        {
            int OpinionInfo_Add_Count;
            OpinionInfo_Add_Count = _opinionInfoService.OpinionInfo_Add(opinionInfoAddViewModel);
            OpinionInfoAddResModel  opinionInfoAddResModel = new OpinionInfoAddResModel();
            if (OpinionInfo_Add_Count > 0)
            {
                opinionInfoAddResModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = OpinionInfo_Add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添领导回复意见信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添领导回复意见信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
        }


        /// <summary>
        /// 删除领导回复意见信息
        /// </summary>
        /// <param name="opinionInfoDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<OpinionInfoDelResModel> Manage_OpinionInfo_Delete(OpinionInfoDelViewModel  opinionInfoDelViewModel)
        {
            OpinionInfoDelResModel  opinionInfoDelResModel = new OpinionInfoDelResModel();
            int DeleteResult = _opinionInfoService.OpinionInfo_Delete(opinionInfoDelViewModel);

            if (DeleteResult > 0)
            {
                opinionInfoDelResModel.DelCount = DeleteResult;
                opinionInfoDelResModel.IsSuccess = true;
                opinionInfoDelResModel.baseViewModel.Message = "删除成功";
                opinionInfoDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除领导回复意见信息成功");
                return Ok(opinionInfoDelResModel);
            }
            else
            {
                opinionInfoDelResModel.DelCount = -1;
                opinionInfoDelResModel.IsSuccess = false;
                opinionInfoDelResModel.baseViewModel.Message = "删除失败";
                opinionInfoDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除领导回复意见信息失败");
                return BadRequest(opinionInfoDelResModel);
            }
        }
        /// <summary>
        /// 更新领导回复意见信息
        /// </summary>
        /// <param name="opinionInfoUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<OpinionInfoUpdateResModel> Manage_OpinionInfo_Update(OpinionInfoUpdateViewModel  opinionInfoUpdateViewModel)
        {
            OpinionInfoUpdateResModel  opinionInfoUpdateResModel = new OpinionInfoUpdateResModel();
            int UpdateRowNum = _opinionInfoService.OpinionInfo_Update(opinionInfoUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                opinionInfoUpdateResModel.IsSuccess = true;
                opinionInfoUpdateResModel.AddCount = UpdateRowNum;
                opinionInfoUpdateResModel.baseViewModel.Message = "更新成功";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新领导回复意见信息成功");
                return Ok(opinionInfoUpdateResModel);
            }
            else
            {
                opinionInfoUpdateResModel.IsSuccess = false;
                opinionInfoUpdateResModel.AddCount = 0;
                opinionInfoUpdateResModel.baseViewModel.Message = "更新失败";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新领导回复意见信息失败");
                return BadRequest(opinionInfoUpdateResModel);
            }
        }

        /// <summary>
        /// 查询领导回复意见信息
        /// </summary>
        /// <param name="opinionInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<OpinionInfoSearchResModel> Manage_OpinionInfo_Search(OpinionInfoSearchViewModel opinionInfoSearchViewModel)
        {
            OpinionInfoSearchResModel  opinionInfoSearchResModel = new OpinionInfoSearchResModel();
            var BusSearchResult = _opinionInfoService.OpinionInfo_Search(opinionInfoSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _opinionInfoService.OpinionInfo_Get_ALLNum(opinionInfoSearchViewModel);
            opinionInfoSearchResModel.suggestBoxInfo = BusSearchResult;
            opinionInfoSearchResModel.IsSuccess = true;
            opinionInfoSearchResModel.baseViewModel.Message = "查询成功";
            opinionInfoSearchResModel.baseViewModel.ResponseCode = 200;
            opinionInfoSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询领导回复意见信息成功");
            return Ok(opinionInfoSearchResModel);

        }
    }
}