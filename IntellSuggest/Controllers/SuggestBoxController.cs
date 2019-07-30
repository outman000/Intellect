using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.IntellSuggestBox;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SuggestBoxViewModel.RequestViewModel;
using ViewModel.SuggestBoxViewModel.ResponseModel;

namespace IntellSuggest.Controllers
{
    [Route("SuggestBoxManageApi/[controller]/[action]")]
    [ApiController]
    public class SuggestBoxController : ControllerBase
    {
        private readonly ISuggestBoxService _suggestBoxService;
     


        public SuggestBoxController(ISuggestBoxService  suggestBoxService)
        {
            _suggestBoxService = suggestBoxService;
        }

        /// <summary>
        /// 增添班车信息
        /// </summary>
        /// <param name="suggestBoxAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        //[ValidateModel]
        public ActionResult Manage_SuggestBox_Add(SuggestBoxAddViewModel  suggestBoxAddViewModel)
        {
            int SuggestBox_Add_Count;
            SuggestBox_Add_Count = _suggestBoxService.SuggestBox_Add(suggestBoxAddViewModel);
            SuggestBoxAddResModel  suggestBoxAddResModel = new SuggestBoxAddResModel();
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

    }
}