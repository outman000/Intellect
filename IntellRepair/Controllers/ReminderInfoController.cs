using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRepair;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.RepairsViewModel.RequestViewModel;
using SystemFilter.PublicFilter;
using ViewModel.RepairsViewModel.ResponseModel;
using Microsoft.AspNetCore.Authorization;

namespace IntellRepair.Controllers
{
    [Route("RepairManageApi/[controller]/[action]")]
    [ApiController]
    public class ReminderInfoController : ControllerBase
    {
        private readonly IReminderInfoService _IReminderInfoService;
        private readonly ILogger _ILogger;
        public ReminderInfoController(IReminderInfoService  reminderInfoService, ILogger logger)
        {
            _IReminderInfoService = reminderInfoService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增加催单信息
        /// </summary>
        /// <param name="reminderInfoAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]

        public ActionResult<ReminderInfoAddResModel> Manage_Reminder_Add(ReminderInfoAddViewModel reminderInfoAddViewModel)
        {
            int Node_Add_Count;
            Node_Add_Count = _IReminderInfoService.ReminderInfo_Add(reminderInfoAddViewModel);
            ReminderInfoAddResModel  reminderInfoAddResModel = new ReminderInfoAddResModel();
            if (Node_Add_Count > 0)
            {
                reminderInfoAddResModel.IsSuccess = true;
                reminderInfoAddResModel.AddCount = Node_Add_Count;
                reminderInfoAddResModel.baseViewModel.Message = "添加成功";
                reminderInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加催单信息成功");
                return Ok(reminderInfoAddResModel);
            }
            else
            {
                reminderInfoAddResModel.IsSuccess = false;
                reminderInfoAddResModel.AddCount = 0;
                reminderInfoAddResModel.baseViewModel.Message = "添加失败";
                reminderInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加催单信息失败");
                return Ok(reminderInfoAddResModel);
            }
        }

        /// <summary>
        /// 查询催单信息
        /// </summary>
        /// <param name="reminderInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<ReminderInfoSearchResModel> Manage_Satisfaction_Search(ReminderInfoSearchViewModel reminderInfoSearchViewModel)
        {
            ReminderInfoSearchResModel  reminderInfoSearchResModel = new ReminderInfoSearchResModel();
            var satisfactionSearchResult = _IReminderInfoService.ReminderInfo_Search(reminderInfoSearchViewModel);
            var TotalNum = _IReminderInfoService.ReminderInfo_Get_ALLNum(reminderInfoSearchViewModel);
            reminderInfoSearchResModel.Reminder_Info = satisfactionSearchResult;
            reminderInfoSearchResModel.isSuccess = true;
            reminderInfoSearchResModel.baseViewModel.Message = "查询成功";
            reminderInfoSearchResModel.baseViewModel.ResponseCode = 200;
            reminderInfoSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询催单信息成功");
            return Ok(reminderInfoSearchResModel);

        }
    }
}