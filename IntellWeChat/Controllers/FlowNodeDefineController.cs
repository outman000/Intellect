using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRepair;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.RepairsViewModel.ResponseModel;
using Microsoft.AspNetCore.Authorization;

namespace IntellRepair.Controllers
{
    [Route("RepairManageApi/[controller]/[action]")]
    [ApiController]
    public class FlowNodeDefineController : ControllerBase
    {
        private readonly IFlowNodeDefineService _IFlowNodeDefineService;
        private readonly ILogger _ILogger;
        public FlowNodeDefineController(IFlowNodeDefineService flowNodeDefineService, ILogger logger)
        {
            _IFlowNodeDefineService = flowNodeDefineService;
            _ILogger = logger;
        }

        /// <summary>
        /// 查询节点定义信息
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<FlowNodeDefineSearchResModel> Repair_Search(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            FlowNodeDefineSearchResModel flowNodeDefineSearchResModel = new FlowNodeDefineSearchResModel();
            var nodeSearchResult = _IFlowNodeDefineService.NodeDefine_Search(flowNodeDefineSearchViewModel);
            var TotalNum = _IFlowNodeDefineService.NodeDefine_Get_ALLNum(flowNodeDefineSearchViewModel);
            flowNodeDefineSearchResModel.flowNodeDefine_Info = nodeSearchResult;
            flowNodeDefineSearchResModel.isSuccess = true;
            flowNodeDefineSearchResModel.baseViewModel.Message = "查询成功";
            flowNodeDefineSearchResModel.baseViewModel.ResponseCode = 200;
            flowNodeDefineSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询节点定义信息成功");
            return Ok(flowNodeDefineSearchResModel);
        }
        /// <summary>
        /// 增加节点定义信息
        /// </summary>
        /// <param name="flowNodeDefineAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        [Authorize]
        public ActionResult<FlowNodeDefineAddResModel> Manage_NodeDefine_Add(FlowNodeDefineAddViewModel flowNodeDefineAddViewModel)
        {
            int Node_Add_Count;
            Node_Add_Count = _IFlowNodeDefineService.NodeDefine_Add(flowNodeDefineAddViewModel);
            FlowNodeDefineAddResModel  flowNodeDefineAddResModel = new FlowNodeDefineAddResModel();
            if (Node_Add_Count > 0)
            {
                flowNodeDefineAddResModel.IsSuccess = true;
                flowNodeDefineAddResModel.AddCount = Node_Add_Count;
                flowNodeDefineAddResModel.baseViewModel.Message = "添加成功";
                flowNodeDefineAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加节点定义信息成功");
                return Ok(flowNodeDefineAddResModel);
            }
            else
            {
                flowNodeDefineAddResModel.IsSuccess = false;
                flowNodeDefineAddResModel.AddCount = 0;
                flowNodeDefineAddResModel.baseViewModel.Message = "添加失败";
                flowNodeDefineAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增加节点定义信息失败");
                return BadRequest(flowNodeDefineAddResModel);
            }
        }

        /// <summary>
        /// 删除节点定义信息
        /// </summary>
        /// <param name="flowNodeDefineDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<FlowNodeDefineDelResModel> Manage_NodeDefine_Delete(FlowNodeDefineDelViewModel flowNodeDefineDelViewModel)
        {
            FlowNodeDefineDelResModel  flowNodeDefineDelResModel = new FlowNodeDefineDelResModel();
            int DeleteResult = _IFlowNodeDefineService.NodeDefine_Delete(flowNodeDefineDelViewModel);

            if (DeleteResult > 0)
            {
                flowNodeDefineDelResModel.DelCount = DeleteResult;
                flowNodeDefineDelResModel.IsSuccess = true;
                flowNodeDefineDelResModel.baseViewModel.Message = "删除成功";
                flowNodeDefineDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除节点定义信息成功");
                return Ok(flowNodeDefineDelResModel);
            }
            else
            {
                flowNodeDefineDelResModel.DelCount = -1;
                flowNodeDefineDelResModel.IsSuccess = false;
                flowNodeDefineDelResModel.baseViewModel.Message = "删除失败";
                flowNodeDefineDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除节点定义信息失败");
                return BadRequest(flowNodeDefineDelResModel);
            }
        }

        /// <summary>
        /// 更新节点定义信息
        /// </summary>
        /// <param name="flowNodeDefineUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        [Authorize]
        public ActionResult<FlowNodeDefineUpdateResModel> Manage_NodeDefine_Update(FlowNodeDefineUpdateViewModel flowNodeDefineUpdateViewModel)
        {
            FlowNodeDefineUpdateResModel  flowNodeDefineUpdateResModel = new FlowNodeDefineUpdateResModel();
            int UpdateRowNum = _IFlowNodeDefineService.NodeDefine_Update(flowNodeDefineUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                flowNodeDefineUpdateResModel.IsSuccess = true;
                flowNodeDefineUpdateResModel.AddCount = UpdateRowNum;
                flowNodeDefineUpdateResModel.baseViewModel.Message = "更新成功";
                flowNodeDefineUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新节点定义信息成功");
                return Ok(flowNodeDefineUpdateResModel);
            }
            else
            {
                flowNodeDefineUpdateResModel.IsSuccess = false;
                flowNodeDefineUpdateResModel.AddCount = 0;
                flowNodeDefineUpdateResModel.baseViewModel.Message = "更新失败";
                flowNodeDefineUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新节点定义信息失败");
                return BadRequest(flowNodeDefineUpdateResModel);
            }
        }
        /// <summary>
        /// 根据流程定义增加节点 / 根据节点定义增加流程定义
        /// </summary>
        /// <param name="flowProcedureByNodeIdAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<FlowProcedureByNodeIdAddResModel> Manage_ProcedureDefineByNodeId_Add(FlowProcedureByNodeIdAddViewModel flowProcedureByNodeIdAddViewModel)
        {
            FlowProcedureByNodeIdAddResModel  flowProcedureByNodeIdAddResModel = new FlowProcedureByNodeIdAddResModel();
            int UpdateRowNum = _IFlowNodeDefineService.ProcedureDefine_To_Node_Add(flowProcedureByNodeIdAddViewModel);
            if (UpdateRowNum > 0)
            {
                flowProcedureByNodeIdAddResModel.IsSuccess = true;
                flowProcedureByNodeIdAddResModel.AddCount = UpdateRowNum;
                flowProcedureByNodeIdAddResModel.baseViewModel.Message = "根据流程定义增加节点/根据节点定义增加流程定义,成功";
                flowProcedureByNodeIdAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据流程定义增加节点/根据节点定义增加流程定义,成功");
                return Ok(flowProcedureByNodeIdAddResModel);
            }
            else
            {
                flowProcedureByNodeIdAddResModel.IsSuccess = false;
                flowProcedureByNodeIdAddResModel.AddCount = 0;
                flowProcedureByNodeIdAddResModel.baseViewModel.Message = "根据流程定义增加节点 / 根据节点定义增加流程定义，失败";
                flowProcedureByNodeIdAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据流程定义增加节点/根据节点定义增加流程定义，失败");
                return BadRequest(flowProcedureByNodeIdAddResModel);

            }

        }

        /// <summary>
        /// 给节点配置角色 
        /// </summary>
        /// <param name="relateRoleByNodeAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<RelateRoleByNodeAddResModel> Manage_NodeToRole_Add(RelateRoleByNodeAddViewModel relateRoleByNodeAddViewModel)
        {
            RelateRoleByNodeAddResModel relateRoleByNodeAddResModel = new RelateRoleByNodeAddResModel();
            int UpdateRowNum = _IFlowNodeDefineService.NodeDefine_RoleToNode_Add(relateRoleByNodeAddViewModel);

            if (UpdateRowNum > 0)
            {
                relateRoleByNodeAddResModel.IsSuccess = true;
                relateRoleByNodeAddResModel.AddCount = UpdateRowNum;
                relateRoleByNodeAddResModel.baseViewModel.Message = "节点配置角色成功";
                relateRoleByNodeAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("给节点配置角色成功");
                return Ok(relateRoleByNodeAddResModel);
            }
            else
            {
                relateRoleByNodeAddResModel.IsSuccess = false;
                relateRoleByNodeAddResModel.AddCount = 0;
                relateRoleByNodeAddResModel.baseViewModel.Message = "节点配置角色失败";
                relateRoleByNodeAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("给节点配置角色失败");
                return BadRequest(relateRoleByNodeAddResModel);
            }
        }
        /// <summary>
        /// 给节点删除角色
        /// </summary>
        /// <param name="relateRoleByNodeDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<RelateRoleByNodeDelResModel> Manage_NodeToRole_Del(RelateRoleByNodeDelViewModel relateRoleByNodeDelViewModel)
        {
            RelateRoleByNodeDelResModel relateRoleByNodeDelResModel = new RelateRoleByNodeDelResModel();
            int DeleteRowNum = _IFlowNodeDefineService.NodeDefine_RoleToNode_Del(relateRoleByNodeDelViewModel);

            if (DeleteRowNum > 0)
            {
                relateRoleByNodeDelResModel.IsSuccess = true;
                relateRoleByNodeDelResModel.DelCount = DeleteRowNum;
                relateRoleByNodeDelResModel.baseViewModel.Message = "节点删除角色成功";
                relateRoleByNodeDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据节点删除角色成功");
                return Ok(relateRoleByNodeDelResModel);
            }
            else
            {
                relateRoleByNodeDelResModel.IsSuccess = false;
                relateRoleByNodeDelResModel.DelCount = 0;
                relateRoleByNodeDelResModel.baseViewModel.Message = "节点删除角色失败";
                relateRoleByNodeDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据节点删除角色失败");
                return BadRequest(relateRoleByNodeDelResModel);
            }
        }


        /// <summary>
        /// 根据节点查角色
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<RoleByNodeSearchResModel> Manage_Role_By_User_Search(RoleByNodeSearchViewModel  roleByNodeSearchViewModel)
        {
            RoleByNodeSearchResModel  roleByNodeSearchResModel = new RoleByNodeSearchResModel();
            roleByNodeSearchResModel.userRoles = _IFlowNodeDefineService.User_By_Node_Search(roleByNodeSearchViewModel);


                roleByNodeSearchResModel.IsSuccess = true;
                roleByNodeSearchResModel.TotalNum = _IFlowNodeDefineService.Role_By_Node_Get_ALLNum(roleByNodeSearchViewModel);
                roleByNodeSearchResModel.baseViewModel.Message = "根据用户查询角色成功";
                roleByNodeSearchResModel.baseViewModel.ResponseCode = 200;
               _ILogger.Information("根据用户查询角色成功");
            return Ok(roleByNodeSearchResModel);
          
        }
        /// <summary>
        /// 给当前节点配下一节点
        /// </summary>
        /// <param name="currentNodeToNextNodeAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<CurrentNodeToNextNodeAddResModel> Manage_CurrentNodeToNextNode_Add(CurrentNodeToNextNodeAddViewModel currentNodeToNextNodeAddViewModel)
        {
            CurrentNodeToNextNodeAddResModel  currentNodeToNextNodeAddResModel = new CurrentNodeToNextNodeAddResModel();
            int UpdateRowNum = _IFlowNodeDefineService.CurrentNodeToNextNode_Add(currentNodeToNextNodeAddViewModel);

            if (UpdateRowNum > 0)
            {
                currentNodeToNextNodeAddResModel.IsSuccess = true;
                currentNodeToNextNodeAddResModel.AddCount = UpdateRowNum;
                currentNodeToNextNodeAddResModel.baseViewModel.Message = "给当前节点配下一节点成功";
                currentNodeToNextNodeAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("给当前节点配下一节点成功");
                return Ok(currentNodeToNextNodeAddResModel);
            }
            else
            {
                currentNodeToNextNodeAddResModel.IsSuccess = false;
                currentNodeToNextNodeAddResModel.AddCount = 0;
                currentNodeToNextNodeAddResModel.baseViewModel.Message = "给当前节点配下一节点失败";
                currentNodeToNextNodeAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("给当前节点配下一节点失败");
                return BadRequest(currentNodeToNextNodeAddResModel);
            }
        }

        /// <summary>
        /// 给当前节点删除下一节点
        /// </summary>
        /// <param name="currentNodeToNextNodeDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<CurrentNodeToNextNodeDelResModel> Manage_CurrentNodeToNextNode_Del(CurrentNodeToNextNodeDelViewModel currentNodeToNextNodeDelViewModel)
        {
            CurrentNodeToNextNodeDelResModel   currentNodeToNextNodeDelResModel = new CurrentNodeToNextNodeDelResModel();
            int DeleteRowNum = _IFlowNodeDefineService.CurrentNodeToNextNode_Del(currentNodeToNextNodeDelViewModel);

            if (DeleteRowNum > 0)
            {
                currentNodeToNextNodeDelResModel.IsSuccess = true;
                currentNodeToNextNodeDelResModel.DelCount = DeleteRowNum;
                currentNodeToNextNodeDelResModel.baseViewModel.Message = "给当前节点删除下一节点成功";
                currentNodeToNextNodeDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("给当前节点删除下一节点成功");
                return Ok(currentNodeToNextNodeDelResModel);
            }
            else
            {
                currentNodeToNextNodeDelResModel.IsSuccess = false;
                currentNodeToNextNodeDelResModel.DelCount = 0;
                currentNodeToNextNodeDelResModel.baseViewModel.Message = "给当前节点删除下一节点成功";
                currentNodeToNextNodeDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("给当前节点删除下一节点成功");
                return BadRequest(currentNodeToNextNodeDelResModel);
            }
        }
        /// <summary>
        /// 根据当前节点查下一节点信息
        /// </summary>
        /// <param name="nextNodeByCurrentNodeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<FlowNodeDefineSearchResModel> Manage_CurrentNodeToNextNode_Search(NextNodeByCurrentNodeSearchViewModel  nextNodeByCurrentNodeSearchViewModel)
        {
            FlowNodeDefineSearchResModel  flowNodeDefineSearchResModel = new FlowNodeDefineSearchResModel();
            flowNodeDefineSearchResModel.flowNodeDefine_Info = _IFlowNodeDefineService.NextNodeDefine_Search(nextNodeByCurrentNodeSearchViewModel);


            flowNodeDefineSearchResModel.isSuccess = true;
            flowNodeDefineSearchResModel.TotalNum = _IFlowNodeDefineService.NodeDefine_Get_ALLNum(nextNodeByCurrentNodeSearchViewModel);
            flowNodeDefineSearchResModel.baseViewModel.Message = "根据当前节点查下一节点信息成功";
            flowNodeDefineSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据当前节点查下一节点信息成功");
            return Ok(flowNodeDefineSearchResModel);

        }
    }
}