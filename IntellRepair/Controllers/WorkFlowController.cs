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
        /// <param name="roleByNodeSearchSingleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Role_By_Search(RoleByNodeSearchSingleViewModel roleByNodeSearchSingleViewModel)
        {
            UserSearchResModel userSearchResModel = new UserSearchResModel();
            userSearchResModel.user_Infos = _IWorkFlowService.User_By_Node_Search(roleByNodeSearchSingleViewModel);
            userSearchResModel.isSuccess = true;
            userSearchResModel.TotalNum = userSearchResModel.user_Infos.Count;
            userSearchResModel.baseViewModel.Message = "根据用户查询角色成功";
            userSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据节点查用户列表成功");
            return Ok(userSearchResModel);

        }

        /// <summary>
        /// 查当前节点是否到达结束(已处理)
        /// </summary>
        /// <param name="nodeEndSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_CurrentNode_Search(NodeEndSearchViewModel  nodeEndSearchViewModel)
        {

            RepairIsEndResModel  repairIsEndResModel = new RepairIsEndResModel();
            repairIsEndResModel.repair = _IWorkFlowService.CurrentNodeSearch(nodeEndSearchViewModel);
         
            if (repairIsEndResModel.repair.Count >0)
            {
                repairIsEndResModel.isSuccess = true;
                repairIsEndResModel.baseViewModel.Message = "查询成功，当前节点为结束";
                repairIsEndResModel.baseViewModel.ResponseCode = 200;
                repairIsEndResModel.TotalNum = repairIsEndResModel.repair.Count;
                _ILogger.Information("查询成功，当前节点为结束");
                return Ok(repairIsEndResModel);

            }
            else
            {

                repairIsEndResModel.isSuccess = false;
                repairIsEndResModel.baseViewModel.Message = "查询成功，当前节点不是结束";
                repairIsEndResModel.baseViewModel.ResponseCode = 200;
                repairIsEndResModel.TotalNum = 0;
                _ILogger.Information("查询成功，当前节点不是结束");
                return Ok(repairIsEndResModel);
            }
        }

        /// <summary>
        /// 查当前节点未到达结束(正在进行的)
        /// </summary>
        /// <param name="nodeEndSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_CurrentNodeNoEnd_Search(NodeEndSearchViewModel nodeEndSearchViewModel)
        {
       
            RepairIsEndResModel repairIsEndResModel = new RepairIsEndResModel();
            repairIsEndResModel.repair = _IWorkFlowService.CurrentNodeSearchNoEnd(nodeEndSearchViewModel);

            if (repairIsEndResModel.repair.Count > 1)
            {
                repairIsEndResModel.isSuccess = true;
                repairIsEndResModel.baseViewModel.Message = "查询成功，存在未处理";
                repairIsEndResModel.baseViewModel.ResponseCode = 200;
                repairIsEndResModel.TotalNum = repairIsEndResModel.repair.Count;
                _ILogger.Information("查询成功，存在未处理");
                return Ok(repairIsEndResModel);

            }
            else
            {

                repairIsEndResModel.isSuccess = false;
                repairIsEndResModel.baseViewModel.Message = "查询失败，不存在未处理";
                repairIsEndResModel.baseViewModel.ResponseCode = 200;
                repairIsEndResModel.TotalNum = 0;
                _ILogger.Information("查询失败，不存在未处理");
                return Ok(repairIsEndResModel);
            }


        }
        /// <summary>
        /// 查当前节点是否超时(如果超时，拟稿人可以发起催单)
        /// </summary>
        /// <param name="flowNodeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_CurrentNodeOverTime_Search(FlowNodeSearchViewModel flowNodeSearchViewModel)
        {
            FlowNodeSearchResModel flowNodeSearchResModel = new FlowNodeSearchResModel();
           
            int temp = _IWorkFlowService.CurrentNodeOverTimeSearch(flowNodeSearchViewModel);
            if (temp==1)
            {
                flowNodeSearchResModel.isSuccess = true;
                flowNodeSearchResModel.baseViewModel.Message = "查询成功，当前流程已超时";
                flowNodeSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询成功，当前流程已超时");
                return Ok(temp);

            }
            else
            {

                flowNodeSearchResModel.isSuccess = false;
                flowNodeSearchResModel.baseViewModel.Message = "查询成功，当前流程未超时";
                flowNodeSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询成功，当前流程未超时");
                return Ok(temp);
            }
           

        }
        /// <summary>
        /// 增添报修以及流程信息(增加意见箱以及流程信息)
        /// </summary>
        /// <param name="repairAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Repair_Add(RepairAddViewModel repairAddViewModel)
        {
            WorkFlowFistReturnIdList  workFlowFistReturnIdList = new WorkFlowFistReturnIdList();
            workFlowFistReturnIdList = _IRepairService.Repair_Add(repairAddViewModel, repairAddViewModel.Flow_ProcedureDefineId);
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
            if(flowNodePreMiddlecs==null)
            {
                flowInfoSearchResModel.IsSuccess = false;
                flowInfoSearchResModel.flowNodePreMiddlecs = null;
                flowInfoSearchResModel.baseViewModel.Message = "生产当前节点未办失败，当前节点的当前类型角色下配有多个人或没有配人，请检查当前类型的角色下的人";
                flowInfoSearchResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("生产当前节点未办失败，当前节点的当前类型角色下配有多个人或没有配人，请检查当前类型的角色");
                return BadRequest(flowInfoSearchResModel);
            }
             else if (flowNodePreMiddlecs.NodeType!="结束类型")
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



        /// <summary>
        /// 增加流转信息(【跳转】)
        /// </summary>
        /// <param name="flowInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_WorkFlowInfoJump_Add(FlowInfoSearchViewModel flowInfoSearchViewModel)
        {

            FlowNodePreMiddlecs flowNodePreMiddlecs = new FlowNodePreMiddlecs();
            flowNodePreMiddlecs = _IWorkFlowService.Work_FlowNodeJump_Add(flowInfoSearchViewModel);

            FlowInfoSearchResModel flowInfoSearchResModel = new FlowInfoSearchResModel();
           
            if (flowNodePreMiddlecs.NodeType != "结束类型")
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