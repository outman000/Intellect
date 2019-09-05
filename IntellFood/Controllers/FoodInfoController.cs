﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.IntellFood;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;
using ViewModel.FoodViewModel.ResponseModel;
using SystemFilter.PublicFilter;
using ViewModel.SuggestBoxViewModel.RequestViewModel;
using ViewModel.SuggestBoxViewModel.ResponseModel;
using Dto.IService.IntellSuggestBox;

namespace IntellFood.Controllers
{
    [Route("FoodManageApi/[controller]/[action]")]
    [ApiController]
    public class FoodInfoController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly ISuggestBoxService _suggestBoxService;
        private readonly ILogger _ILogger;


        public FoodInfoController(IFoodService foodService, ISuggestBoxService suggestBoxService, ILogger logger)
        {
            _foodService = foodService;
            _suggestBoxService = suggestBoxService;
            _ILogger = logger;

        }


        /// <summary>
        /// 查询菜单信息
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodInfoSearchResModel> Manage_Food_Search(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            FoodInfoSearchResModel foodInfoSearchResModel = new FoodInfoSearchResModel();
            var BusSearchResult = _foodService.Food_Search(foodInfoSearchViewModel);
            var foodtype= _foodService.FoodType_Search(foodInfoSearchViewModel);
            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _foodService.Food_Get_ALLNum(foodInfoSearchViewModel);
            foodInfoSearchResModel.foodInfo = BusSearchResult;
            foodInfoSearchResModel.foodType = foodtype;
            foodInfoSearchResModel.IsSuccess = true;
            foodInfoSearchResModel.baseViewModel.Message = "查询成功";
            foodInfoSearchResModel.baseViewModel.ResponseCode = 200;
            foodInfoSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询菜单信息成功");
            return Ok(foodInfoSearchResModel);

        }

        /// <summary>
        /// 增添菜单信息
        /// </summary>
        /// <param name="foodInfoAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]
        public ActionResult<FoodInfoAddResModel> Manage_Food_Add(FoodInfoAddViewModel foodInfoAddViewModel)
        {
            int Food_Add_Count;
            Food_Add_Count = _foodService.Food_Add(foodInfoAddViewModel);
            FoodInfoAddResModel foodInfoAddResModel = new FoodInfoAddResModel();
            if (Food_Add_Count > 0)
            {
                foodInfoAddResModel.IsSuccess = true;
                foodInfoAddResModel.AddCount = Food_Add_Count;
                foodInfoAddResModel.baseViewModel.Message = "添加成功";
                foodInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添菜单信息成功");
                return Ok(foodInfoAddResModel);
            }
            else
            {
                foodInfoAddResModel.IsSuccess = false;
                foodInfoAddResModel.AddCount = 0;
                foodInfoAddResModel.baseViewModel.Message = "添加失败";
                foodInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添菜单信息失败");
                return BadRequest(foodInfoAddResModel);
            }
        }

        /// <summary>
        /// 删除菜单信息
        /// </summary>
        /// <param name="foodInfoDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodInfoDelResModel> Manage_Food_Delete(FoodInfoDelViewModel foodInfoDelViewModel)
        {
            FoodInfoDelResModel foodInfoDelResModel = new FoodInfoDelResModel();
            int DeleteResult = _foodService.Food_Delete(foodInfoDelViewModel);

            if (DeleteResult > 0)
            {
                foodInfoDelResModel.DelCount = DeleteResult;
                foodInfoDelResModel.IsSuccess = true;
                foodInfoDelResModel.baseViewModel.Message = "删除成功";
                foodInfoDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除菜单信息成功");
                return Ok(foodInfoDelResModel);
            }
            else
            {
                foodInfoDelResModel.DelCount = -1;
                foodInfoDelResModel.IsSuccess = false;
                foodInfoDelResModel.baseViewModel.Message = "删除失败";
                foodInfoDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除菜单信息失败");
                return BadRequest(foodInfoDelResModel);
            }
        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="foodInfoUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<FoodInfoUpdateResModel> Manage_Food_Update(FoodInfoUpdateViewModel foodInfoUpdateViewModel)
        {
            FoodInfoUpdateResModel foodInfoUpdateResModel = new FoodInfoUpdateResModel();
            int UpdateRowNum = _foodService.Food_Update(foodInfoUpdateViewModel);

            if (UpdateRowNum > 0)
            {
                foodInfoUpdateResModel.IsSuccess = true;
                foodInfoUpdateResModel.AddCount = UpdateRowNum;
                foodInfoUpdateResModel.baseViewModel.Message = "更新成功";
                foodInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更新菜单信息成功");
                return Ok(foodInfoUpdateResModel);
            }
            else
            {
                foodInfoUpdateResModel.IsSuccess = false;
                foodInfoUpdateResModel.AddCount = 0;
                foodInfoUpdateResModel.baseViewModel.Message = "更新失败";
                foodInfoUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更新菜单信息失败");
                return BadRequest(foodInfoUpdateResModel);
            }
        }
        /// <summary>
        /// 验证菜单标识是否重复
        /// </summary>
        /// <param name="foodInfoValideRepeat   "></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<FoodInfoValideResRepeat> Manage_Food_ValideRepeat(FoodInfoValideRepeat foodInfoValideRepeat)
        {
            FoodInfoValideResRepeat foodInfoValideResRepeat = new FoodInfoValideResRepeat();
            bool ValideResutlt = _foodService.Food_Single(foodInfoValideRepeat);
            foodInfoValideResRepeat.IsSuccess = ValideResutlt;
            if (ValideResutlt)
            {
                foodInfoValideResRepeat.IsSuccess = true;
                foodInfoValideResRepeat.baseViewModel.Message = "此id可以使用";
                foodInfoValideResRepeat.baseViewModel.ResponseCode = 200;
                _ILogger.Information("验证菜单标识是否重复，此id可以使用");
                return Ok(foodInfoValideResRepeat);
            }
            else
            {
                foodInfoValideResRepeat.IsSuccess = false;
                foodInfoValideResRepeat.baseViewModel.Message = "此id已经存在，请更换";
                foodInfoValideResRepeat.baseViewModel.ResponseCode = 400;
                _ILogger.Information("验证菜单标识是否重复，此id已经存在，请更换");
                return BadRequest(foodInfoValideResRepeat);
            }
        }



        /// <summary>
        /// 根据用户id和菜单id点赞 /取消点赞
        /// </summary>
        /// <param name="foodByUserPraiseViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByUserSearchResModel> Manage_FoodToUser_Del(FoodByUserPraiseViewModel foodByUserPraiseViewModel)
        {
            FoodByUserSearchResModel foodByUserSearchResModel = new FoodByUserSearchResModel();
            int SearchRowNum = _foodService.Food_Relate_User(foodByUserPraiseViewModel);

            if (SearchRowNum > 0)
            {
                foodByUserSearchResModel.IsSuccess = true;
                foodByUserSearchResModel.TotalNum = SearchRowNum;
                foodByUserSearchResModel.baseViewModel.Message = "用户点赞成功";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据用户id和菜单id，用户点赞成功");
                return Ok(foodByUserSearchResModel);
            }
            else
            {
                foodByUserSearchResModel.IsSuccess = false;
                foodByUserSearchResModel.TotalNum = 0;
                foodByUserSearchResModel.baseViewModel.Message = "用户取消赞成功";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据用户id和菜单id，用户取消赞成功");
                return Ok(foodByUserSearchResModel);
            }
        }
        /// <summary>
        /// 根据用户id和菜单id点差评
        /// </summary>
        /// <param name="foodByUserAddCpViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByUserSearchResModel> Manage_FoodToUserCp_Del(FoodByUserAddCpViewModel foodByUserAddCpViewModel)
        {
            FoodByUserSearchResModel foodByUserSearchResModel = new FoodByUserSearchResModel();
            int SearchRowNum = _foodService.Food_Relate_UserCp(foodByUserAddCpViewModel);

            if (SearchRowNum > 0)
            {
                foodByUserSearchResModel.IsSuccess = true;
                foodByUserSearchResModel.TotalNum = SearchRowNum;
                foodByUserSearchResModel.baseViewModel.Message = "用户点差评成功";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据用户id和菜单id，用户点差评成功");
                return Ok(foodByUserSearchResModel);
            }
            else
            {
                foodByUserSearchResModel.IsSuccess = false;
                foodByUserSearchResModel.TotalNum = 0;
                foodByUserSearchResModel.baseViewModel.Message = "用户已经点过差评";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("用户已经点过差评");
                return Ok(foodByUserSearchResModel);
            }
        }


        /// <summary>
        /// 根据用户id和菜单id，查询评价信息(包括差评)
        /// </summary>
        /// <param name="foodByUserSearchCpViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByUserSearchCpResModel> Manage_FoodToUser_Search_Cp(FoodByUserSearchCpViewModel foodByUserSearchCpViewModel)
        {
            FoodByUserSearchCpResModel  foodByUserSearchCpResModel = new FoodByUserSearchCpResModel();
            foodByUserSearchCpResModel.CpInfo = _foodService.Food_Relate_User_Search_CP(foodByUserSearchCpViewModel);
            var TotalNum = _foodService.FoodCp_Get_ALLNum(foodByUserSearchCpViewModel);

            foodByUserSearchCpResModel.IsSuccess = true;
            foodByUserSearchCpResModel.TotalNum = TotalNum;
                foodByUserSearchCpResModel.baseViewModel.Message = "查询用户发表的差评成功";
                foodByUserSearchCpResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询用户发表的差评成功");
                return Ok(foodByUserSearchCpResModel);
            
        }
        /// <summary>
        /// 根据用户id和菜单id增加评价信息
        /// </summary>
        /// <param name="foodByUserAddCpViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByUserSearchResModel> Manage_FoodToUser_AddCp(FoodByUserAddCpViewModel foodByUserAddCpViewModel)
        {
            FoodByUserSearchResModel foodByUserSearchResModel = new FoodByUserSearchResModel();
            int SearchRowNum = _foodService.Food_Relate_User_ADD_Pj(foodByUserAddCpViewModel);

            if (SearchRowNum > 0)
            {
                foodByUserSearchResModel.IsSuccess = true;
                foodByUserSearchResModel.TotalNum = SearchRowNum;
                foodByUserSearchResModel.baseViewModel.Message = "用户发表差评成功";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据用户id和菜单id，用户发表差评成功");
                return Ok(foodByUserSearchResModel);
            }
            else
            {
                foodByUserSearchResModel.IsSuccess = false;
                foodByUserSearchResModel.TotalNum = 0;
                foodByUserSearchResModel.baseViewModel.Message = "该用户对该菜发表过评价，因此用户发表差评失败";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据用户id和菜单id，该用户对该菜发表过评价，因此用户发表差评失败");
                return Ok(foodByUserSearchResModel);
            }
        }
        /// <summary>
        /// 查询菜单点赞数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByFoodIdSearchResModel> Manage_PraiseNum_Search(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs)
        {
            FoodByFoodIdSearchResModel foodIdSearchResModel = new FoodByFoodIdSearchResModel();
            var BusSearchResult = _foodService.PraiseNumByFoodId(praiseNumSearchMiddlecs);


            foodIdSearchResModel.PraiseInfo = BusSearchResult;
            foodIdSearchResModel.IsSuccess = true;
            foodIdSearchResModel.baseViewModel.Message = "查询菜单点赞数量成功";
            foodIdSearchResModel.baseViewModel.ResponseCode = 200;
            foodIdSearchResModel.TotalNum = BusSearchResult.Count;
            _ILogger.Information("查询菜单点赞数量，查询成功");
            return Ok(foodIdSearchResModel);

        }
        /// <summary>
        /// 查询菜单差评数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByFoodIdSearchResModel> Manage_CpNum_Search(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs)
        {
            FoodByFoodIdSearchResModel foodIdSearchResModel = new FoodByFoodIdSearchResModel();
            var BusSearchResult = _foodService.CpNumByFoodId(praiseNumSearchMiddlecs);


            foodIdSearchResModel.PraiseInfo = BusSearchResult;
            foodIdSearchResModel.IsSuccess = true;
            foodIdSearchResModel.baseViewModel.Message = "查询菜单差评数量成功";
            foodIdSearchResModel.baseViewModel.ResponseCode = 200;
            foodIdSearchResModel.TotalNum = BusSearchResult.Count;
            _ILogger.Information(" 查询菜单差评数量，查询成功");
            return Ok(foodIdSearchResModel);

        }

        /// <summary>
        /// 根据菜Id删除点赞信息
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByUserPraiseDelResModel> Manage_FoodId_Del(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel)
        {
            FoodByUserPraiseDelResModel foodByUserPraiseDelResModel = new FoodByUserPraiseDelResModel();
            int DeleteResult = _foodService.By_Food_Id_Del(foodByUserPraiseDelViewModel);
            if (DeleteResult > 0)
            {
                foodByUserPraiseDelResModel.DelCount = DeleteResult;
                foodByUserPraiseDelResModel.IsSuccess = true;
                foodByUserPraiseDelResModel.baseViewModel.Message = "根据菜Id删除点赞信息成功";
                foodByUserPraiseDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除菜单点赞信息成功");
                return Ok(foodByUserPraiseDelResModel);
            }
            else
            {
                foodByUserPraiseDelResModel.DelCount = -1;
                foodByUserPraiseDelResModel.IsSuccess = false;
                foodByUserPraiseDelResModel.baseViewModel.Message = "根据菜Id删除点赞信息失败";
                foodByUserPraiseDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除菜单点赞信息失败");
                return BadRequest(foodByUserPraiseDelResModel);
            }
        }
        /// <summary>
        /// 根据菜Id删除差评信息
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FoodByUserPraiseDelResModel> Manage_FoodId_DelCp(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel)
        {
            FoodByUserPraiseDelResModel foodByUserPraiseDelResModel = new FoodByUserPraiseDelResModel();
            int DeleteResult = _foodService.By_Food_Id_DelCp(foodByUserPraiseDelViewModel);
            if (DeleteResult > 0)
            {
                foodByUserPraiseDelResModel.DelCount = DeleteResult;
                foodByUserPraiseDelResModel.IsSuccess = true;
                foodByUserPraiseDelResModel.baseViewModel.Message = "根据菜Id删除差评信息成功";
                foodByUserPraiseDelResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除菜单差评信息成功");
                return Ok(foodByUserPraiseDelResModel);
            }
            else
            {
                foodByUserPraiseDelResModel.DelCount = -1;
                foodByUserPraiseDelResModel.IsSuccess = false;
                foodByUserPraiseDelResModel.baseViewModel.Message = "根据菜Id删除差评信息失败";
                foodByUserPraiseDelResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除菜单差评信息失败");
                return BadRequest(foodByUserPraiseDelResModel);
            }
        }
        /// <summary>
        /// 查询建议增加的菜信息
        /// </summary>
        /// <param name="suggestBoxSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SuggestBoxSearchResModel> Manage_Suggest_Add_Food(SuggestBoxSearchViewModel suggestBoxSearchViewModel)
        {
            SuggestBoxSearchResModel suggestBoxSearchResModel = new SuggestBoxSearchResModel();
            var BusSearchResult = _suggestBoxService.SuggestBox_Search(suggestBoxSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _suggestBoxService.SuggestBox_Get_ALLNum(suggestBoxSearchViewModel);
            suggestBoxSearchResModel.suggestBoxInfo = BusSearchResult;
            suggestBoxSearchResModel.IsSuccess = true;
            suggestBoxSearchResModel.baseViewModel.Message = "查询成功";
            suggestBoxSearchResModel.baseViewModel.ResponseCode = 200;
            suggestBoxSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询意见箱表单信息成功");
            return Ok(suggestBoxSearchResModel);

        }


        /// <summary>
        /// 增添建议增加的菜信息
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
                _ILogger.Information("增添建议增加的菜信息成功");
                return Ok(suggestBoxAddResModel);
            }
            else
            {
                suggestBoxAddResModel.IsSuccess = false;
                suggestBoxAddResModel.AddCount = 0;
                suggestBoxAddResModel.baseViewModel.Message = "添加失败";
                suggestBoxAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添建议增加的菜信息失败");
                return BadRequest(suggestBoxAddResModel);
            }
        }

        /// <summary>
        /// 删除建议增加的菜信息
        /// </summary>
        /// <param name="suggestBoxDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SuggestBoxDelResModel> Manage_Suggest_Delete(SuggestBoxDelViewModel suggestBoxDelViewModel)
        {
            SuggestBoxDelResModel suggestBoxDelResModel = new SuggestBoxDelResModel();
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
                _ILogger.Information("删除意见箱表单信息失败");
                return BadRequest(suggestBoxDelResModel);
            }
        }
    }
}