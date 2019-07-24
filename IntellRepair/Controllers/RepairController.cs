using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellRepair;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.RepairsViewModel.RequestViewModel;
using ViewModel.RepairsViewModel.ResponseModel;

namespace IntellRepair.Controllers
{
    [Route("RepairManageApi/[controller]/[action]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService _IRepairService;

        public RepairController(IRepairService repairService)
        {
            _IRepairService = repairService;
        }

        /// <summary>
        /// 查询所有用户缴费信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Repair_Search(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            RepairInfoSearchResModel repairInfoSearchResModel = new RepairInfoSearchResModel();
            var repairSearchResult = _IRepairService.Repair_Search(repairInfoSearchViewModel);
            var TotalNum = repairSearchResult.Count;
            repairInfoSearchResModel.repair_Infos = repairSearchResult;
            repairInfoSearchResModel.isSuccess = true;
            repairInfoSearchResModel.baseViewModel.Message = "查询成功";
            repairInfoSearchResModel.baseViewModel.ResponseCode = 200;
            repairInfoSearchResModel.TotalNum = TotalNum;
            return Ok(repairInfoSearchResModel);
        }

    }
}