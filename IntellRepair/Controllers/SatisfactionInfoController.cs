using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Serilog;
using Dto.IService.IntellRepair;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.RepairsViewModel.ResponseModel;
using ILogger = Serilog.ILogger;

namespace IntellRepair.Controllers
{
    [Route("RepairManageApi/[controller]/[action]")]
    [ApiController]
    public class SatisfactionInfoController : ControllerBase
    {
        private readonly ISatisfactionInfoService _ISatisfactionInfoService;
        private readonly ILogger _ILogger;
        public SatisfactionInfoController(ISatisfactionInfoService  satisfactionInfoService, ILogger logger)
        {
            _ISatisfactionInfoService = satisfactionInfoService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增加评论信息
        /// </summary>
        /// <param name="satisfactionInfoAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Satisfaction_Add(SatisfactionInfoAddViewModel satisfactionInfoAddViewModel)
        {
            int Node_Add_Count;
            Node_Add_Count = _ISatisfactionInfoService.SatisfactionInfo_Add(satisfactionInfoAddViewModel);
            SatisfactionInfoAddResModel  satisfactionInfoAddResModel = new SatisfactionInfoAddResModel();
            if (Node_Add_Count > 0)
            {
                satisfactionInfoAddResModel.IsSuccess = true;
                satisfactionInfoAddResModel.AddCount = Node_Add_Count;
                satisfactionInfoAddResModel.baseViewModel.Message = "添加成功";
                satisfactionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加评论信息成功");
                return Ok(satisfactionInfoAddResModel);
            }
            else
            {
                satisfactionInfoAddResModel.IsSuccess = false;
                satisfactionInfoAddResModel.AddCount = 0;
                satisfactionInfoAddResModel.baseViewModel.Message = "添加失败";
                satisfactionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加评论信息失败");
                return BadRequest(satisfactionInfoAddResModel);
            }
        }

        /// <summary>
        /// 查询评论信息
        /// </summary>
        /// <param name="satisfactionInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Satisfaction_Search(SatisfactionInfoSearchViewModel satisfactionInfoSearchViewModel)
        {
            SatisfactionInfoSearchResModel  satisfactionInfoSearchResModel = new SatisfactionInfoSearchResModel();
            var satisfactionSearchResult = _ISatisfactionInfoService.Satisfaction_Search(satisfactionInfoSearchViewModel);
            var TotalNum = _ISatisfactionInfoService.Satisfaction_Get_ALLNum(satisfactionInfoSearchViewModel);
            satisfactionInfoSearchResModel.SatisfactionInfo_Info = satisfactionSearchResult;
            satisfactionInfoSearchResModel.isSuccess = true;
            satisfactionInfoSearchResModel.baseViewModel.Message = "查询成功";
            satisfactionInfoSearchResModel.baseViewModel.ResponseCode = 200;
            satisfactionInfoSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询评论信息成功");
            return Ok(satisfactionInfoSearchResModel);

        }
    }
}