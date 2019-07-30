using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
   
       

       public WorkFlowController(IWorkFlowService workFlowService,IFlowNodeDefineService flowNodeDefineService)
       {
            _IWorkFlowService = workFlowService;
           
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
                return Ok(userSearchResModel);
           
        }

        


    }
}