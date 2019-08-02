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
    public class FlowProcedureInfoController : ControllerBase
    {
        private readonly IFlowProcedureInfoService _IFlowProcedureInfoService;
        private readonly ILogger _ILogger;
        public FlowProcedureInfoController(IFlowProcedureInfoService flowProcedureInfoService, ILogger logger)
        {
            _IFlowProcedureInfoService = flowProcedureInfoService;
            _ILogger = logger;
        }
        /// <summary>
        /// 查询流程信息
        /// </summary>
        /// <param name="flowProcedureSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Procedure_Search(FlowProcedureSearchViewModel flowProcedureAddViewModel)
        {
            FlowProcedureSearchResModel  flowProcedureSearchResModel = new FlowProcedureSearchResModel();
            var nodeSearchResult = _IFlowProcedureInfoService.Procedure_Search(flowProcedureAddViewModel);
            var TotalNum = _IFlowProcedureInfoService.Procedure_Get_ALLNum(flowProcedureAddViewModel);
            flowProcedureSearchResModel.procedure_Infos = nodeSearchResult;
            flowProcedureSearchResModel.isSuccess = true;
            flowProcedureSearchResModel.baseViewModel.Message = "查询成功";
            flowProcedureSearchResModel.baseViewModel.ResponseCode = 200;
            flowProcedureSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询流程信息成功");
            return Ok(flowProcedureSearchResModel);
        
         }

        /// <summary>
        /// 删除流程信息
        /// </summary>
        /// <param name="flowProcedureDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Procedure_Delete(FlowProcedureDelViewModel flowProcedureDelViewModel)
        {
            FlowProcedureDelResModel  flowProcedureDelResModel = new FlowProcedureDelResModel();
            int DeleteResult = _IFlowProcedureInfoService.Procedure_Delete(flowProcedureDelViewModel);

            if (DeleteResult > 0)
            {
                flowProcedureDelResModel.DelCount = DeleteResult;
                flowProcedureDelResModel.IsSuccess = true;
                flowProcedureDelResModel.baseViewModel.Message = "删除成功";
                flowProcedureDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除流程信息成功");
                return Ok(flowProcedureDelResModel);
            }
            else
            {
                flowProcedureDelResModel.DelCount = -1;
                flowProcedureDelResModel.IsSuccess = false;
                flowProcedureDelResModel.baseViewModel.Message = "删除失败";
                flowProcedureDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除流程信息失败");
                return BadRequest(flowProcedureDelResModel);
            }
        }
        /// <summary>
        /// 更新流程信息
        /// </summary>
        /// <param name="flowProcedureUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Procedure_Update(FlowProcedureUpdateViewModel flowProcedureUpdateViewModel)
        {
            FlowProcedureUpdateResModel  flowProcedureUpdateResModel = new FlowProcedureUpdateResModel();
            int UpdateRowNum = _IFlowProcedureInfoService.Procedure_Update(flowProcedureUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                flowProcedureUpdateResModel.IsSuccess = true;
                flowProcedureUpdateResModel.AddCount = UpdateRowNum;
                flowProcedureUpdateResModel.baseViewModel.Message = "更新成功";
                flowProcedureUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新流程信息成功");
                return Ok(flowProcedureUpdateResModel);
            }
            else
            {
                flowProcedureUpdateResModel.IsSuccess = false;
                flowProcedureUpdateResModel.AddCount = 0;
                flowProcedureUpdateResModel.baseViewModel.Message = "更新失败";
                flowProcedureUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新流程信息失败");
                return BadRequest(flowProcedureUpdateResModel);
            }
        }

        /// <summary>
        /// 增加流程信息
        /// </summary>
        /// <param name="flowProcedureAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Procedure_Add(FlowProcedureAddViewModel flowProcedureAddViewModel)
        {
            int Node_Add_Count;
            Node_Add_Count = _IFlowProcedureInfoService.Procedure_Add(flowProcedureAddViewModel);
            FlowProcedureAddResModel flowNodeAddResModel = new FlowProcedureAddResModel();
            if (Node_Add_Count > 0)
            {
                flowNodeAddResModel.IsSuccess = true;
                flowNodeAddResModel.AddCount = Node_Add_Count;
                flowNodeAddResModel.baseViewModel.Message = "添加成功";
                flowNodeAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加流程信息成功");
                return Ok(flowNodeAddResModel);
            }
            else
            {
                flowNodeAddResModel.IsSuccess = false;
                flowNodeAddResModel.AddCount = 0;
                flowNodeAddResModel.baseViewModel.Message = "添加失败";
                flowNodeAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加流程信息失败");
                return BadRequest(flowNodeAddResModel);
            }
        }
    }
}