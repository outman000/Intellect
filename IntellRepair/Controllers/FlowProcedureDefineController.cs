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
    public class FlowProcedureDefineController : ControllerBase
    {

        private readonly IFlowProcedureDefineService _IFlowProcedureDefineService;
        private readonly ILogger _ILogger;
        public FlowProcedureDefineController(IFlowProcedureDefineService flowProcedureDefineService, ILogger logger)
        {
            _IFlowProcedureDefineService = flowProcedureDefineService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增加流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<FlowProcedureDefineAddResModel> Manage_ProcedureDefine_Add(FlowProcedureDefineAddViewModel  flowProcedureDefineAddViewModel)
        {
            int Node_Add_Count;
            Node_Add_Count = _IFlowProcedureDefineService.ProcedureDefine_Add(flowProcedureDefineAddViewModel);
            FlowProcedureDefineAddResModel  flowProcedureDefineAddResModel = new FlowProcedureDefineAddResModel();
            if (Node_Add_Count > 0)
            {
                flowProcedureDefineAddResModel.IsSuccess = true;
                flowProcedureDefineAddResModel.AddCount = Node_Add_Count;
                flowProcedureDefineAddResModel.baseViewModel.Message = "添加成功";
                flowProcedureDefineAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加流程定义信息成功");
                return Ok(flowProcedureDefineAddResModel);
            }
            else
            {
                flowProcedureDefineAddResModel.IsSuccess = false;
                flowProcedureDefineAddResModel.AddCount = 0;
                flowProcedureDefineAddResModel.baseViewModel.Message = "添加失败";
                flowProcedureDefineAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加流程定义信息失败");
                return BadRequest(flowProcedureDefineAddResModel);
            }
        }
        /// <summary>
        /// 查询流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FlowProcedureDefineSearchResModel> ProcedureDefine_Search(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel)
        {
            FlowProcedureDefineSearchResModel  flowProcedureDefineSearchResModel = new FlowProcedureDefineSearchResModel();
            var procedurSearchResult = _IFlowProcedureDefineService.ProcedureDefine_Search(flowProcedureDefineSearchViewModel);
            var TotalNum = _IFlowProcedureDefineService.ProcedureDefine_Get_ALLNum(flowProcedureDefineSearchViewModel);
            flowProcedureDefineSearchResModel.flowProcedureDefine_Info = procedurSearchResult;
            flowProcedureDefineSearchResModel.isSuccess = true;
            flowProcedureDefineSearchResModel.baseViewModel.Message = "查询成功";
            flowProcedureDefineSearchResModel.baseViewModel.ResponseCode = 200;
            flowProcedureDefineSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询流程定义信息成功");
            return Ok(flowProcedureDefineSearchResModel);
        }

        /// <summary>
        /// 删除流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FlowProcedureDefineDelResModel> Manage_ProcedureDefine_Delete(FlowProcedureDefineDelViewModel  flowProcedureDefineDelViewModel)
        {
            FlowProcedureDefineDelResModel  flowProcedureDefineDelResModel = new FlowProcedureDefineDelResModel();
            int DeleteResult = _IFlowProcedureDefineService.ProcedureDefine_Delete(flowProcedureDefineDelViewModel);

            if (DeleteResult > 0)
            {
                flowProcedureDefineDelResModel.DelCount = DeleteResult;
                flowProcedureDefineDelResModel.IsSuccess = true;
                flowProcedureDefineDelResModel.baseViewModel.Message = "删除成功";
                flowProcedureDefineDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除流程定义信息成功");
                return Ok(flowProcedureDefineDelResModel);
            }
            else
            {
                flowProcedureDefineDelResModel.DelCount = -1;
                flowProcedureDefineDelResModel.IsSuccess = false;
                flowProcedureDefineDelResModel.baseViewModel.Message = "删除失败";
                flowProcedureDefineDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除流程定义信息失败");
                return BadRequest(flowProcedureDefineDelResModel);
            }
        }

        /// <summary>
        /// 更新流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<FlowProcedureDefineUpdateResModel> Manage_ProcedureDefine_Update(FlowProcedureDefineUpdateViewModel  flowProcedureDefineUpdateViewModel)
        {
            FlowProcedureDefineUpdateResModel  flowProcedureDefineUpdateResModel = new FlowProcedureDefineUpdateResModel();
            int UpdateRowNum = _IFlowProcedureDefineService.ProcedureDefine_Update(flowProcedureDefineUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                flowProcedureDefineUpdateResModel.IsSuccess = true;
                flowProcedureDefineUpdateResModel.AddCount = UpdateRowNum;
                flowProcedureDefineUpdateResModel.baseViewModel.Message = "更新成功";
                flowProcedureDefineUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新流程定义信息成功");
                return Ok(flowProcedureDefineUpdateResModel);
            }
            else
            {
                flowProcedureDefineUpdateResModel.IsSuccess = false;
                flowProcedureDefineUpdateResModel.AddCount = 0;
                flowProcedureDefineUpdateResModel.baseViewModel.Message = "更新失败";
                flowProcedureDefineUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新流程定义信息失败");
                return BadRequest(flowProcedureDefineUpdateResModel);
            }
        }

        /// <summary>
        /// 流程标识验证是否重复
        /// </summary>
        /// <param name="flowProcedureDefineSingleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<FlowProcedureDefineSingleResModel> Manage_ProcedureDefine_Single(FlowProcedureDefineSingleViewModel  flowProcedureDefineSingleViewModel)
        {
            FlowProcedureDefineSingleResModel  flowProcedureDefineSingleResModel = new FlowProcedureDefineSingleResModel();
            bool ValideResutlt = _IFlowProcedureDefineService.ProcedureDefine_Single(flowProcedureDefineSingleViewModel);
            flowProcedureDefineSingleResModel.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                flowProcedureDefineSingleResModel.IsSuccess = true;
                flowProcedureDefineSingleResModel.baseViewModel.Message = "此标识可以使用";
                flowProcedureDefineSingleResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("流程标识验证是否重复，此标识可以使用");
                return Ok(flowProcedureDefineSingleResModel);
            }
            else
            {
                flowProcedureDefineSingleResModel.IsSuccess = false;
                flowProcedureDefineSingleResModel.baseViewModel.Message = "此标识已经存在，请更换";
                flowProcedureDefineSingleResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("流程标识验证是否重复，此标识已经存在，请更换");
                return BadRequest(flowProcedureDefineSingleResModel);
            }
        }
    }
}