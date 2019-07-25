using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;


namespace IntellUser.Controllers
{
    [Route("UserManageApi/[controller]/[action]")]
    [ApiController]
    public class DepartController : ControllerBase
    {
        private readonly IDepartService _departService;

        // private readonly IValidator<UserAddViewModel> _validator;



        public DepartController(IDepartService departService)
        {
            _departService = departService;

        }
        /// <summary>
        /// 增添部门信息
        /// </summary>
        /// <param name="departAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Depart_add(DepartAddViewModel departAddViewModel)
        {
            int Depart_Add_Count;
            Depart_Add_Count = _departService.Depart_Add(departAddViewModel);
            DepartAddResModel userAddResModel = new DepartAddResModel();
            if (Depart_Add_Count > 0)
            {
                userAddResModel.IsSuccess = true;
                userAddResModel.AddCount = Depart_Add_Count;
                userAddResModel.baseViewModel.Message = "添加成功";
                userAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(userAddResModel);
            }
            else
            {
                userAddResModel.IsSuccess = false;
                userAddResModel.AddCount = 0;
                userAddResModel.baseViewModel.Message = "添加失败";
                userAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(userAddResModel);
            }
        }

        /// <summary>
        /// 部门名id验证是否重复
        /// </summary>
        /// <param name="departValideRepeat"></param>
  
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Depart_ValideRepeat(DepartValideRepeat departValideRepeat)
        {
            DepartValideResRepeat departValideResRepeat = new DepartValideResRepeat();
            bool ValideResutlt = _departService.Depart_Single(departValideRepeat);
            departValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                departValideResRepeat.IsSuccess = true;
                departValideResRepeat.baseViewModel.Message = "此id可以使用";
                departValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(departValideResRepeat);
            }
            else
            {
                departValideResRepeat.IsSuccess = false;
                departValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                departValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(departValideResRepeat);
            }
        }
        /// <summary>
        /// 删除部门信息（直接删除）
        /// </summary>
        /// <param name="departDeleteViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Manage_Depart_Delete(DepartDeleteViewModel departDeleteViewModel)
        {
            DepartDeleteResModel departDeleteResModel = new DepartDeleteResModel();
            int DeleteResult = _departService.Depart_Delete(departDeleteViewModel);

            if (DeleteResult > 0)
            {
                departDeleteResModel.AddCount = DeleteResult;
                departDeleteResModel.IsSuccess = true;
                departDeleteResModel.baseViewModel.Message = "删除成功";
                departDeleteResModel.baseViewModel.ResponseCode = 200;
                return Ok(departDeleteResModel);
            }
            else
            {
                departDeleteResModel.AddCount = -1;
                departDeleteResModel.IsSuccess = false;
                departDeleteResModel.baseViewModel.Message = "删除失败";
                departDeleteResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(departDeleteResModel);
            }

        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="departUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_Depart_Update(DepartUpdateViewModel departUpdateViewModel)
        {
            DepartUpdateResModel departValideResRepeat = new DepartUpdateResModel();
            int UpdateRowNum = _departService.Depart_Update(departUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                departValideResRepeat.IsSuccess = true;
                departValideResRepeat.AddCount = UpdateRowNum;
                departValideResRepeat.baseViewModel.Message = "更新成功";
                departValideResRepeat.baseViewModel.ResponseCode = 200;
                return Ok(departValideResRepeat);
            }
            else
            {
                departValideResRepeat.IsSuccess = false;
                departValideResRepeat.AddCount = 0;
                departValideResRepeat.baseViewModel.Message = "更新失败";
                departValideResRepeat.baseViewModel.ResponseCode = 400;
                return BadRequest(departValideResRepeat);
            }
        }
        /// <summary>
        /// 查询部门信息
        /// </summary>
        /// <param name="departSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult Manage_Depart_Search(DepartSearchViewModel departSearchViewModel)
        {
            DepartSearchResModel departSearchResModel = new DepartSearchResModel();
            var DepartSearchResult = _departService.Depart_Search(departSearchViewModel);
            var TotalNum = DepartSearchResult.Count;
            departSearchResModel.user_Departs= DepartSearchResult;
            departSearchResModel.isSuccess = true;
            departSearchResModel.baseViewModel.Message = "查询成功";
            departSearchResModel.baseViewModel.ResponseCode = 200;
            departSearchResModel.TotalNum = TotalNum;
            return Ok(departSearchResModel);

        }


    }
}