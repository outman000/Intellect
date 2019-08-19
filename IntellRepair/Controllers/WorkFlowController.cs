using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellRepair;
using Dto.IService.IntellUser;
using Dto.Service.IntellUser;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.RepairsViewModel.ResponseModel;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;

namespace IntellRepair.Controllers
{
    [Route("RepairManageApi/[controller]/[action]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IWorkFlowService _IWorkFlowService;
        private readonly IRepairService _IRepairService;
        private readonly ILogger _ILogger;


        public WorkFlowController(IWorkFlowService workFlowService,
                                  IRepairService repairService,     
                                  ILogger logger)
        {
            _IWorkFlowService = workFlowService;
            _IRepairService = repairService;
            _ILogger = logger;

        }

        /// <summary>
        /// 根据节点查用户列表
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Role_By_User_Search(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            UserSearchResModel  userSearchResModel = new UserSearchResModel();
            userSearchResModel.user_Infos = _IWorkFlowService.User_By_Node_Search(roleByNodeSearchViewModel);
                userSearchResModel.isSuccess = true;
                userSearchResModel.TotalNum = userSearchResModel.user_Infos.Count;
                userSearchResModel.baseViewModel.Message = "根据用户查询角色成功";
                userSearchResModel.baseViewModel.ResponseCode = 200;
               _ILogger.Information("根据节点查用户列表成功");
            return Ok(userSearchResModel);
           
        }
        /// <summary>
        /// 根据节点查用户列表（内部使用）
        /// </summary>
        /// <param name="userListByNodeIdSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Role_By_Search(UserListByNodeIdSearchViewModel userListByNodeIdSearchViewModel)
        {
            UserSearchResModel userSearchResModel = new UserSearchResModel();
            userSearchResModel.user_Infos = _IWorkFlowService.User_By_Node_Search(userListByNodeIdSearchViewModel);
            userSearchResModel.isSuccess = true;
            userSearchResModel.TotalNum = userSearchResModel.user_Infos.Count;
            userSearchResModel.baseViewModel.Message = "根据用户查询角色成功";
            userSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据节点查用户列表成功");
            return Ok(userSearchResModel);

        }
        /// <summary>
        /// 增添报修以及流程信息(增加意见箱以及流程信息)
        /// </summary>
        /// <param name="repairAddViewModel"></param>
        /// <param name="Flow_ProcedureDefineId"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Repair_Add(RepairAddViewModel repairAddViewModel, int Flow_ProcedureDefineId)
        {
            WorkFlowFistReturnIdList  workFlowFistReturnIdList = new WorkFlowFistReturnIdList();
            workFlowFistReturnIdList = _IRepairService.Repair_Add(repairAddViewModel,Flow_ProcedureDefineId);
            RepairAddResModel repairAddResModel = new RepairAddResModel();
            if (workFlowFistReturnIdList!=null)
            {
                repairAddResModel.IsSuccess = true;
                repairAddResModel.workFlowFistReturnIdList = workFlowFistReturnIdList;
                repairAddResModel.baseViewModel.Message = "添加成功";
                repairAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添报修信息成功");
                return Ok(repairAddResModel);
            }
            else
            {
                repairAddResModel.IsSuccess = false;
                repairAddResModel.workFlowFistReturnIdList = null;
                repairAddResModel.baseViewModel.Message = "添加失败";
                repairAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添报修信息失败");
                return BadRequest(repairAddResModel);
            }
        }

        /// <summary>
        /// 增加流转信息(正式增加****究极进化****)
        /// </summary>
        /// <param name="flowInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_WorkFlowInfo_Add(FlowInfoSearchViewModel flowInfoSearchViewModel)
        {

            FlowNodePreMiddlecs flowNodePreMiddlecs = new FlowNodePreMiddlecs();
            flowNodePreMiddlecs = _IWorkFlowService.Work_FlowNodeAll_Add(flowInfoSearchViewModel);
   
            FlowInfoSearchResModel  flowInfoSearchResModel = new FlowInfoSearchResModel();
            if (flowNodePreMiddlecs.NodeType!="结束类型")
            {
                flowInfoSearchResModel.IsSuccess = true;
                flowInfoSearchResModel.flowNodePreMiddlecs = flowNodePreMiddlecs;
                flowInfoSearchResModel.baseViewModel.Message = "增加流转信息成功，该流程还没有结束";
                flowInfoSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增加流转信息成功，该流程还没有结束");
                return Ok(flowInfoSearchResModel);
            }
            else
            {
                flowInfoSearchResModel.IsSuccess = false;
                flowInfoSearchResModel.flowNodePreMiddlecs = null;
                flowInfoSearchResModel.baseViewModel.Message = "所有流转信息增加完毕，本条流程已结束";
                flowInfoSearchResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("所有流转信息增加完毕，本条流程已结束");
                return BadRequest(flowInfoSearchResModel);
            }

        }

    }
}