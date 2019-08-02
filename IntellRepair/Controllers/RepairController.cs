using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRepair;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.RepairsViewModel.ResponseModel;

namespace IntellRepair.Controllers
{
    [Route("RepairManageApi/[controller]/[action]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService _IRepairService;
        private readonly ILogger _ILogger;
        public RepairController(IRepairService repairService, ILogger logger)
        {
            _IRepairService = repairService;
            _ILogger = logger;
        }

        /// <summary>
        /// 查询报修信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Repair_Search(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            RepairInfoSearchResModel repairInfoSearchResModel = new RepairInfoSearchResModel();
            var repairSearchResult = _IRepairService.Repair_Search(repairInfoSearchViewModel);
            var TotalNum = _IRepairService.Repair_Get_ALLNum(repairInfoSearchViewModel);
            repairInfoSearchResModel.repair_Infos = repairSearchResult;
            repairInfoSearchResModel.isSuccess = true;
            repairInfoSearchResModel.baseViewModel.Message = "查询成功";
            repairInfoSearchResModel.baseViewModel.ResponseCode = 200;
            repairInfoSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询报修信息成功");
            return Ok(repairInfoSearchResModel);
        }


        /// <summary>
        /// 增添报修信息
        /// </summary>
        /// <param name="repairAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Repair_Add(RepairAddViewModel repairAddViewModel)
        {
            int Repair_Add_Count;
            Repair_Add_Count = _IRepairService.Repair_Add(repairAddViewModel);
            RepairAddResModel repairAddResModel = new RepairAddResModel();
            if (Repair_Add_Count > 0)
            {
                repairAddResModel.IsSuccess = true;
                repairAddResModel.AddCount = Repair_Add_Count;
                repairAddResModel.baseViewModel.Message = "添加成功";
                repairAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添报修信息成功");
                return Ok(repairAddResModel);
            }
            else
            {
                repairAddResModel.IsSuccess = false;
                repairAddResModel.AddCount = 0;
                repairAddResModel.baseViewModel.Message = "添加失败";
                repairAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添报修信息失败");
                return BadRequest(repairAddResModel);
            }
        }

        /// <summary>
        /// 删除报修表单
        /// </summary>
        /// <param name="repairDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Bus_Delete(RepairDelViewModel repairDelViewModel)
        {
            RpairDelResModel rpairDelResModel = new RpairDelResModel();
            int DeleteResult = _IRepairService.Repair_Delete(repairDelViewModel);

            if (DeleteResult > 0)
            {
                rpairDelResModel.DelCount = DeleteResult;
                rpairDelResModel.IsSuccess = true;
                rpairDelResModel.baseViewModel.Message = "删除成功";
                rpairDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除报修表单成功");
                return Ok(rpairDelResModel);
            }
            else
            {
                rpairDelResModel.DelCount = -1;
                rpairDelResModel.IsSuccess = false;
                rpairDelResModel.baseViewModel.Message = "删除失败";
                rpairDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除报修表单失败");
                return BadRequest(rpairDelResModel);
            }
        }
        /// <summary>
        /// 更新报修信息
        /// </summary>
        /// <param name="repairUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Bus_Update(RepairUpdateViewModel repairUpdateViewModel)
        {
            RepairUpdateResModel repairUpdateResModel = new RepairUpdateResModel();
            int UpdateRowNum = _IRepairService.Repair_Update(repairUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                repairUpdateResModel.IsSuccess = true;
                repairUpdateResModel.AddCount = UpdateRowNum;
                repairUpdateResModel.baseViewModel.Message = "更新成功";
                repairUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新报修信息成功");
                return Ok(repairUpdateResModel);
            }
            else
            {
                repairUpdateResModel.IsSuccess = false;
                repairUpdateResModel.AddCount = 0;
                repairUpdateResModel.baseViewModel.Message = "更新失败";
                repairUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新报修信息失败");
                return BadRequest(repairUpdateResModel);
            }
        }

    }
}