using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellSuggestBox;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.SuggestBoxViewModel.RequestViewModel;
using ViewModel.SuggestBoxViewModel.ResponseModel;
using Microsoft.AspNetCore.Authorization;

namespace IntellSuggest.Controllers
{
    [Route("SuggestBoxManageApi/[controller]/[action]")]
    [ApiController]
    public class SuggestBoxController : ControllerBase
    {
        private readonly ISuggestBoxService _suggestBoxService;
        private readonly ILogger _ILogger;


        public SuggestBoxController(ISuggestBoxService suggestBoxService, ILogger logger)
        {
            _suggestBoxService = suggestBoxService;
            _ILogger = logger;
        }

        /// <summary>
        /// 增添意见箱表单信息
        /// </summary>
        /// <param name="suggestBoxAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult<SuggestBoxAddResModel> Manage_SuggestBox_Add(SuggestBoxAddViewModel suggestBoxAddViewModel)
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
                _ILogger.Information("增添意见箱信息成功");
                return Ok(suggestBoxAddResModel);
            }
            else
            {
                suggestBoxAddResModel.IsSuccess = false;
                suggestBoxAddResModel.AddCount = 0;
                suggestBoxAddResModel.baseViewModel.Message = "添加失败";
                suggestBoxAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添意见箱信息失败");
                return BadRequest(suggestBoxAddResModel);
            }
        }
        /// <summary>
        /// 更新意见箱表单信息
        /// </summary>
        /// <param name="suggestBoxUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<SuggestBoxUpdateResModel> Manage_SuggestBox_Update(SuggestBoxUpdateViewModel suggestBoxUpdateViewModel)
        {
            SuggestBoxUpdateResModel suggestBoxUpdateResModel = new SuggestBoxUpdateResModel();
            int UpdateRowNum = _suggestBoxService.SuggestBox_Update(suggestBoxUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                suggestBoxUpdateResModel.IsSuccess = true;
                suggestBoxUpdateResModel.AddCount = UpdateRowNum;
                suggestBoxUpdateResModel.baseViewModel.Message = "更新成功";
                suggestBoxUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新意见箱表单信息成功");
                return Ok(suggestBoxUpdateResModel);
            }
            else
            {
                suggestBoxUpdateResModel.IsSuccess = false;
                suggestBoxUpdateResModel.AddCount = 0;
                suggestBoxUpdateResModel.baseViewModel.Message = "更新失败";
                suggestBoxUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新意见箱信息失败");
                return BadRequest(suggestBoxUpdateResModel);
            }
        }

        /// <summary>
        /// 删除意见箱表单信息
        /// </summary>
        /// <param name="suggestBoxDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SuggestBoxDelResModel> Manage_SuggestBox_Delete(SuggestBoxDelViewModel  suggestBoxDelViewModel)
        {
            SuggestBoxDelResModel  suggestBoxDelResModel = new SuggestBoxDelResModel();
            int DeleteResult = _suggestBoxService.SuggestBox_Delete(suggestBoxDelViewModel);

            if (DeleteResult > 0)
            {
                suggestBoxDelResModel.DelCount = DeleteResult;
                suggestBoxDelResModel.IsSuccess = true;
                suggestBoxDelResModel.baseViewModel.Message = "删除成功";
                suggestBoxDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除意见箱表单信息成功");
                return Ok(suggestBoxDelResModel);
            }
            else
            {
                suggestBoxDelResModel.DelCount = -1;
                suggestBoxDelResModel.IsSuccess = false;
                suggestBoxDelResModel.baseViewModel.Message = "删除失败";
                suggestBoxDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除意见箱信息失败");
                return BadRequest(suggestBoxDelResModel);
            }
        }

        /// <summary>
        /// 查询意见信息
        /// </summary>
        /// <param name="suggestBoxSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SuggestBoxSearchResModel> Manage_SuggestBox_Search(SuggestBoxSearchViewModel  suggestBoxSearchViewModel)
        {
            SuggestBoxSearchResModel   suggestBoxSearchResModel = new SuggestBoxSearchResModel();
            var BusSearchResult = _suggestBoxService.SuggestBox_Search(suggestBoxSearchViewModel);

            var TotalNum = _suggestBoxService.SuggestBox_Get_ALLNum(suggestBoxSearchViewModel);
            suggestBoxSearchResModel.suggestBoxInfo = BusSearchResult;
            suggestBoxSearchResModel.IsSuccess = true;
            suggestBoxSearchResModel.baseViewModel.Message = "查询成功";
            suggestBoxSearchResModel.baseViewModel.ResponseCode = 200;
            suggestBoxSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询意见箱信息成功");
            return Ok(suggestBoxSearchResModel);

        }


        /// <summary>
        /// 根据主键ID查询意见箱信息
        /// </summary>
        /// <param name="suggestBoxSearchByIdViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SuggestBoxSearchByIdResModel> Manage_SuggestBox_Search_ById(SuggestBoxSearchByIdViewModel suggestBoxSearchByIdViewModel)
        {
            SuggestBoxSearchByIdResModel  suggestBoxSearchByIdResModel = new SuggestBoxSearchByIdResModel();
            var BusSearchResult = _suggestBoxService.SuggestBox_SearchById(suggestBoxSearchByIdViewModel);
            suggestBoxSearchByIdResModel.suggestBoxInfo = BusSearchResult;
            suggestBoxSearchByIdResModel.IsSuccess = true;
            suggestBoxSearchByIdResModel.baseViewModel.Message = "查询成功";
            suggestBoxSearchByIdResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("根据主键ID查询意见箱信息成功");
            return Ok(suggestBoxSearchByIdResModel);

        }

        /// <summary>
        /// 根据用户主键Id查询意见信息
        /// </summary>
        /// <param name="suggestBoxByIdSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SuggestBoxSearchResModel> Manage_SuggestBoxById_Search(SuggestBoxByIdSearchViewModel suggestBoxByIdSearchViewModel)
        {
            SuggestBoxSearchResModel suggestBoxSearchResModel = new SuggestBoxSearchResModel();
            var suggestBoxSearchResult = _suggestBoxService.SuggestBoxById_Search(suggestBoxByIdSearchViewModel);
            var TotalNum = suggestBoxSearchResult.Count;
            suggestBoxSearchResModel.suggestBoxInfo = suggestBoxSearchResult;
            suggestBoxSearchResModel.IsSuccess = true;
            suggestBoxSearchResModel.baseViewModel.Message = "查询成功";
            suggestBoxSearchResModel.baseViewModel.ResponseCode = 200;
            suggestBoxSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("根据用户主键Id查询意见信息成功");
            return Ok(suggestBoxSearchResModel);

        }

        /// <summary>
        /// 查询意见分类信息
        /// </summary>
        /// <param name="suggestBoxTypeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SuggestBoxTypeSearchResModel> Manage_SuggestBoxType_Search(SuggestBoxTypeSearchViewModel  suggestBoxTypeSearchViewModel)
        {
            SuggestBoxTypeSearchResModel  suggestBoxTypeSearchResModel = new SuggestBoxTypeSearchResModel();
            var suggestBoxTypeSearchResult = _suggestBoxService.SuggestBoxType_Search(suggestBoxTypeSearchViewModel);

            suggestBoxTypeSearchResModel.suggestBoxTypeInfo= suggestBoxTypeSearchResult;
            suggestBoxTypeSearchResModel.IsSuccess = true;
            suggestBoxTypeSearchResModel.baseViewModel.Message = "查询成功";
            suggestBoxTypeSearchResModel.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询意见箱表单信息成功");
            return Ok(suggestBoxTypeSearchResModel);

        }

    }
}