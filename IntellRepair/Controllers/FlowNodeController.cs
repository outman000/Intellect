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
    public class FlowNodeController : ControllerBase
    {
        private readonly IFlowNodeService _IFlowNodeService;
        private readonly ILogger _ILogger;
        public FlowNodeController(IFlowNodeService flowNodeService, ILogger logger)
        {
            _IFlowNodeService = flowNodeService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增加流转信息
        /// </summary>
        /// <param name="flowNodeAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Node_Add(FlowNodeAddViewModel flowNodeAddViewModel)
        {
            int Node_Add_Count;
            Node_Add_Count = _IFlowNodeService.FlowNode_Add(flowNodeAddViewModel);
            FlowNodeAddResModel   flowNodeAddResModel = new FlowNodeAddResModel();
            if (Node_Add_Count > 0)
            {
                flowNodeAddResModel.IsSuccess = true;
                flowNodeAddResModel.AddCount = Node_Add_Count;
                flowNodeAddResModel.baseViewModel.Message = "添加成功";
                flowNodeAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加流转信息成功");
                return Ok(flowNodeAddResModel);
            }
            else
            {
                flowNodeAddResModel.IsSuccess = false;
                flowNodeAddResModel.AddCount = 0;
                flowNodeAddResModel.baseViewModel.Message = "添加失败";
                flowNodeAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加流转信息失败");
                return BadRequest(flowNodeAddResModel);
            }
        }

        /// <summary>
        /// 更新流转信息
        /// </summary>
        /// <param name="flowNodeUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Node_Update(FlowNodeUpdateViewModel flowNodeUpdateViewModel)
        {
            FlowNodeUpdateResModels  flowNodeUpdateResModels = new FlowNodeUpdateResModels();
            int UpdateRowNum = _IFlowNodeService.FlowNode_Update(flowNodeUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                flowNodeUpdateResModels.IsSuccess = true;
                flowNodeUpdateResModels.AddCount = UpdateRowNum;
                flowNodeUpdateResModels.baseViewModel.Message = "更新成功";
                flowNodeUpdateResModels.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新流转信息成功");
                return Ok(flowNodeUpdateResModels);
            }
            else
            {
                flowNodeUpdateResModels.IsSuccess = false;
                flowNodeUpdateResModels.AddCount = 0;
                flowNodeUpdateResModels.baseViewModel.Message = "更新失败";
                flowNodeUpdateResModels.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新流转信息失败");
                return BadRequest(flowNodeUpdateResModels);
            }
        }

        /// <summary>
        /// 删除流转信息
        /// </summary>
        /// <param name="flowNodeDefineDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Node_Delete(FlowNodeDelViewModel flowNodeDelViewModel)
        {
            FlowNodeDelResModel flowNodeDelResModel = new FlowNodeDelResModel();
            int DeleteResult = _IFlowNodeService.Node_Delete(flowNodeDelViewModel);

            if (DeleteResult > 0)
            {
                flowNodeDelResModel.DelCount = DeleteResult;
                flowNodeDelResModel.IsSuccess = true;
                flowNodeDelResModel.baseViewModel.Message = "删除成功";
                flowNodeDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除流转信息成功");
                return Ok(flowNodeDelResModel);
            }
            else
            {
                flowNodeDelResModel.DelCount = -1;
                flowNodeDelResModel.IsSuccess = false;
                flowNodeDelResModel.baseViewModel.Message = "删除失败";
                flowNodeDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除流转信息失败");
                return BadRequest(flowNodeDelResModel);
            }
        }

        /// <summary>
        /// 查询流转信息
        /// </summary>
        /// <param name="flowNodeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Node_Search(FlowNodeSearchViewModel flowNodeSearchViewModel)
        {
            FlowNodeSearchResModel flowNodeSearchResModel = new FlowNodeSearchResModel();
            var nodeSearchResult = _IFlowNodeService.Node_Search(flowNodeSearchViewModel);
            var TotalNum = _IFlowNodeService.Node_Get_ALLNum(flowNodeSearchViewModel);

            flowNodeSearchResModel.flowNodeDefine_Info = nodeSearchResult;
            flowNodeSearchResModel.isSuccess = true;
            flowNodeSearchResModel.baseViewModel.Message = "查询成功";
            flowNodeSearchResModel.baseViewModel.ResponseCode = 200;
            flowNodeSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询流转信息成功");
            return Ok(flowNodeSearchResModel);
        }
    }
}