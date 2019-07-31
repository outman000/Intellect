using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellSuggestBox;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.SuggestBoxViewModel.RequestViewModel;
using ViewModel.SuggestBoxViewModel.ResponseModel;

namespace IntellSuggest.Controllers
{
    [Route("SuggestBoxManageApi/[controller]/[action]")]
    [ApiController]
    public class SuggestBoxController : ControllerBase
    {
        private readonly ISuggestBoxService _suggestBoxService;



        public SuggestBoxController(ISuggestBoxService suggestBoxService)
        {
            _suggestBoxService = suggestBoxService;
        }

        /// <summary>
        /// 增添意见箱表单信息
        /// </summary>
        /// <param name="suggestBoxAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult Manage_SuggestBox_Add(SuggestBoxAddViewModel suggestBoxAddViewModel)
        {
            int SuggestBox_Add_Count;
            SuggestBox_Add_Count = _suggestBoxService.SuggestBox_Add(suggestBoxAddViewModel);
            SuggestBoxAddResModel suggestBoxAddResModel = new SuggestBoxAddResModel();
            if (SuggestBox_Add_Count > 0)
            {
                suggestBoxAddResModel.IsSuccess = true;
                suggestBoxAddResModel.AddCount = SuggestBox_Add_Count;
                suggestBoxAddResModel.baseViewModel.Message = "添加成功";
                suggestBoxAddResModel.baseViewModel.ResponseCode = 200;
                return Ok(suggestBoxAddResModel);
            }
            else
            {
                suggestBoxAddResModel.IsSuccess = false;
                suggestBoxAddResModel.AddCount = 0;
                suggestBoxAddResModel.baseViewModel.Message = "添加失败";
                suggestBoxAddResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(suggestBoxAddResModel);
            }
        }
        /// <summary>
        /// 更新意见箱表单信息
        /// </summary>
        /// <param name="suggestBoxUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_SuggestBox_Update(SuggestBoxUpdateViewModel suggestBoxUpdateViewModel)
        {
            SuggestBoxUpdateResModel suggestBoxUpdateResModel = new SuggestBoxUpdateResModel();
            int UpdateRowNum = _suggestBoxService.SuggestBox_Update(suggestBoxUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                suggestBoxUpdateResModel.IsSuccess = true;
                suggestBoxUpdateResModel.AddCount = UpdateRowNum;
                suggestBoxUpdateResModel.baseViewModel.Message = "更新成功";
                suggestBoxUpdateResModel.baseViewModel.ResponseCode = 200;
                return Ok(suggestBoxUpdateResModel);
            }
            else
            {
                suggestBoxUpdateResModel.IsSuccess = false;
                suggestBoxUpdateResModel.AddCount = 0;
                suggestBoxUpdateResModel.baseViewModel.Message = "更新失败";
                suggestBoxUpdateResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(suggestBoxUpdateResModel);
            }
        }

        /// <summary>
        /// 删除意见箱表单信息
        /// </summary>
        /// <param name="suggestBoxDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Food_Delete(SuggestBoxDelViewModel  suggestBoxDelViewModel)
        {
            SuggestBoxDelResModel  suggestBoxDelResModel = new SuggestBoxDelResModel();
            int DeleteResult = _suggestBoxService.SuggestBox_Delete(suggestBoxDelViewModel);

            if (DeleteResult > 0)
            {
                suggestBoxDelResModel.DelCount = DeleteResult;
                suggestBoxDelResModel.IsSuccess = true;
                suggestBoxDelResModel.baseViewModel.Message = "删除成功";
                suggestBoxDelResModel.baseViewModel.ResponseCode = 200;
                return Ok(suggestBoxDelResModel);
            }
            else
            {
                suggestBoxDelResModel.DelCount = -1;
                suggestBoxDelResModel.IsSuccess = false;
                suggestBoxDelResModel.baseViewModel.Message = "删除失败";
                suggestBoxDelResModel.baseViewModel.ResponseCode = 400;
                return BadRequest(suggestBoxDelResModel);
            }
        }
        /// <summary>
        /// 查询意见箱表单信息
        /// </summary>
        /// <param name="suggestBoxSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Food_Search(SuggestBoxSearchViewModel  suggestBoxSearchViewModel)
        {
            SuggestBoxSearchResModel   suggestBoxSearchResModel = new SuggestBoxSearchResModel();
            var BusSearchResult = _suggestBoxService.SuggestBox_Search(suggestBoxSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _suggestBoxService.SuggestBox_Get_ALLNum(suggestBoxSearchViewModel);
            suggestBoxSearchResModel.suggestBoxInfo = BusSearchResult;
            suggestBoxSearchResModel.IsSuccess = true;
            suggestBoxSearchResModel.baseViewModel.Message = "查询成功";
            suggestBoxSearchResModel.baseViewModel.ResponseCode = 200;
            suggestBoxSearchResModel.TotalNum = TotalNum;
            return Ok(suggestBoxSearchResModel);

        }


       
    }
}