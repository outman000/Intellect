using System;
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

namespace IntellFood.Controllers
{
    [Route("FoodManageApi/[controller]/[action]")]
    [ApiController]
    public class FoodInfoController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly ILogger _ILogger;


        public FoodInfoController(IFoodService foodService, ILogger logger)
        {
            _foodService = foodService;
            _ILogger = logger;

        }


        /// <summary>
        /// 查询菜单信息
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_Food_Search(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            FoodInfoSearchResModel foodInfoSearchResModel = new FoodInfoSearchResModel();
            var BusSearchResult = _foodService.Food_Search(foodInfoSearchViewModel);

            // var TotalNum = _userService.User_Get_ALLNum();
            var TotalNum = _foodService.Food_Get_ALLNum(foodInfoSearchViewModel);
            foodInfoSearchResModel.foodInfo = BusSearchResult;
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
        public ActionResult Manage_Food_Add(FoodInfoAddViewModel foodInfoAddViewModel)
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
        public ActionResult Manage_Food_Delete(FoodInfoDelViewModel foodInfoDelViewModel)
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
        public ActionResult Manage_Food_Update(FoodInfoUpdateViewModel foodInfoUpdateViewModel)
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
        public ActionResult Manage_Food_ValideRepeat(FoodInfoValideRepeat foodInfoValideRepeat)
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
        public ActionResult Manage_FoodToUser_Del(FoodByUserPraiseViewModel foodByUserPraiseViewModel)
        {
            FoodByUserSearchResModel foodByUserSearchResModel = new FoodByUserSearchResModel();
            int SearchRowNum = _foodService.Food_Relate_User(foodByUserPraiseViewModel);

            if (SearchRowNum > 0)
            {
                foodByUserSearchResModel.IsSuccess = true;
                foodByUserSearchResModel.TotalNum = SearchRowNum;
                foodByUserSearchResModel.baseViewModel.Message = "用户点赞/取消赞成功";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("根据用户id和菜单id，用户点赞/取消赞成功");
                return Ok(foodByUserSearchResModel);
            }
            else
            {
                foodByUserSearchResModel.IsSuccess = false;
                foodByUserSearchResModel.TotalNum = 0;
                foodByUserSearchResModel.baseViewModel.Message = "用户点赞/取消赞成功";
                foodByUserSearchResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("根据用户id和菜单id，用户点赞/取消赞成功");
                return BadRequest(foodByUserSearchResModel);
            }
        }

        /// <summary>
        /// 查询菜单点赞数量
        /// </summary>
        /// <param name="foodByFoodIdSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_PraiseNum_Search()
        {
            FoodByFoodIdSearchResModel foodIdSearchResModel = new FoodByFoodIdSearchResModel();
            var BusSearchResult = _foodService.PraiseNumByFoodId();


            foodIdSearchResModel.PraiseInfo = BusSearchResult;
            foodIdSearchResModel.IsSuccess = true;
            foodIdSearchResModel.baseViewModel.Message = "查询成功";
            foodIdSearchResModel.baseViewModel.ResponseCode = 200;
            foodIdSearchResModel.TotalNum = BusSearchResult.Count;
            _ILogger.Information("查询菜单点赞数量，查询成功");
            return Ok(foodIdSearchResModel);

        }

        /// <summary>
        /// 根据菜Id删除点赞信息
        /// </summary>
        /// <param name="foodInfoDelViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Manage_FoodId_Del(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel)
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
    }
}