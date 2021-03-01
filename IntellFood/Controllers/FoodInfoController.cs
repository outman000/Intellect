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
using ViewModel.SuggestBoxViewModel.RequestViewModel;
using ViewModel.SuggestBoxViewModel.ResponseModel;
using Dto.IService.IntellSuggestBox;
using Microsoft.AspNetCore.Authorization;
using ViewModel.UserViewModel.ResponseModel;
using System.IO;
using Dto.IService.IntellUser;

namespace IntellFood.Controllers
{
    [Route("FoodManageApi/[controller]/[action]")]
    [ApiController]
    public class FoodInfoController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly ISuggestBoxService _suggestBoxService;
        private readonly IUserService _userService;
        private readonly ILogger _ILogger;


        public FoodInfoController(IFoodService foodService, ISuggestBoxService suggestBoxService, IUserService userService, ILogger logger)
        {
            _foodService = foodService;
            _suggestBoxService = suggestBoxService;
            _userService = userService;
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
                return Ok(foodInfoAddResModel);
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
                return Ok(foodInfoDelResModel);
            }
        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="foodInfoUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]


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
                return Ok(foodInfoUpdateResModel);
            }
        }
        /// <summary>
        /// 验证菜单标识是否重复
        /// </summary>
        /// <param name="foodInfoValideRepeat   "></param>
        /// <returns></returns>
        [HttpPost]


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
                return Ok(foodInfoValideResRepeat);
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
                return Ok(foodByUserPraiseDelResModel);
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
                return Ok(foodByUserPraiseDelResModel);
            }
        }
        /// <summary>
        /// 查询建议增加的菜信息
        /// </summary>
        /// <param name="suggestFoodSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<SuggestFoodSearchResModel> Manage_Suggest_Search_Food(SuggestFoodSearchViewModel suggestFoodSearchViewModel)
        {
            SuggestFoodSearchResModel  suggestFoodSearchResModel = new SuggestFoodSearchResModel();
            var BusSearchResult = _foodService.SuggestFood_Search(suggestFoodSearchViewModel);
            var TotalNum = _foodService.SuggesttFood_Get_ALLNum(suggestFoodSearchViewModel);
            suggestFoodSearchResModel.suggest_Foods = BusSearchResult;
            suggestFoodSearchResModel.IsSuccess = true;
            suggestFoodSearchResModel.baseViewModel.Message = "查询成功";
            suggestFoodSearchResModel.baseViewModel.ResponseCode = 200;
            suggestFoodSearchResModel.TotalNum = TotalNum;
            _ILogger.Information("查询意见箱表单信息成功");
            return Ok(suggestFoodSearchResModel);

        }


        /// <summary>
        /// 增添建议增加的菜信息
        /// </summary>
        /// <param name="suggestFoodAddViewModel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateModel]

        public ActionResult<SuggestBoxAddResModel> Manage_SuggestBox_Add(SuggestFoodAddViewModel suggestFoodAddViewModel)
        {
            int SuggestBox_Add_Count;
            SuggestBox_Add_Count = _foodService.SuggestFood_Add(suggestFoodAddViewModel);
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
                return Ok(suggestBoxAddResModel);
            }
        }

        /// <summary>
        /// 查询当前周和下周
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<FoodWeekOfMonthSearchResModel> Manage_WeekOfMonth_Search()
        {
            FoodWeekOfMonthSearchResModel  foodWeekOfMonthSearchResModel = new FoodWeekOfMonthSearchResModel();
            var list = _foodService.WeekOfMonthSearch();

            if (list!=null)
            {
                foodWeekOfMonthSearchResModel.vs = list;
  
                foodWeekOfMonthSearchResModel.IsSuccess = true;
                foodWeekOfMonthSearchResModel.baseViewModel.Message = "查询成功";
                foodWeekOfMonthSearchResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询当前周和下周成功");
                return Ok(foodWeekOfMonthSearchResModel);
            }
            else
            {
                foodWeekOfMonthSearchResModel.vs = list;
                foodWeekOfMonthSearchResModel.IsSuccess = false;
                foodWeekOfMonthSearchResModel.baseViewModel.Message = "查询失败";
                foodWeekOfMonthSearchResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("查询当前周和下周失败");
                return Ok(foodWeekOfMonthSearchResModel);
            }
        }


        /// <summary>
        /// 按照菜品模板生成
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public ActionResult<FoodTemplateAddResModel> Manage_Template_Add(TemplateAddViewModel templateAddViewModel)
        {
            FoodTemplateAddResModel  foodTemplateAddResModel = new FoodTemplateAddResModel();
            int Template_Add_Count;
            Template_Add_Count = _foodService.Template_Add(templateAddViewModel);
            SuggestBoxAddResModel suggestBoxAddResModel = new SuggestBoxAddResModel();
            if (Template_Add_Count > 0)
            {
                foodTemplateAddResModel.IsSuccess = true;
                foodTemplateAddResModel.AddCount = Template_Add_Count;
                foodTemplateAddResModel.baseViewModel.Message = "添加成功";
                foodTemplateAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("按照菜品模板生成信息成功");
                return Ok(foodTemplateAddResModel);
            }
            else
            {
                foodTemplateAddResModel.IsSuccess = false;
                foodTemplateAddResModel.AddCount = 0;
                foodTemplateAddResModel.baseViewModel.Message = "添加失败";
                foodTemplateAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("按照菜品模板生成信息失败");
                return Ok(foodTemplateAddResModel);
            }
        }


        /// <summary>
        /// 上传文件并且得到上传文件的所有信息(导入用户信息)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FileUploadAddResModel> Manage_uploadfileAndGetInfo_UserInfo()
        {
            FileUploadAddResModel fileUploadAddResModel = new FileUploadAddResModel();
            int fileUpload_Add_Count = 0;

            try
            {
                    var files = Request.Form.Files;
          
                    string filePath = "";//上传文件的路径

                    if (files.Count == 0)
                    {
                        fileUploadAddResModel.IsSuccess = true;
                        fileUploadAddResModel.AddCount = fileUpload_Add_Count;
                        fileUploadAddResModel.baseViewModel.Message = "找不到上传的文件";
                        fileUploadAddResModel.baseViewModel.ResponseCode = 200;
                        _ILogger.Information("找不到上传的文件");
                        return Ok(fileUploadAddResModel);
                 
                    }
                    // full path to file in temp location
                    foreach (var formFile in files)
                    {
                        //FileInfo fi = new FileInfo(formFile.FileName);
                        //if (fi.Extension != ".xlsx" || fi.Extension != ".xls")
                        //{
                        //    fileUploadAddResModel.IsSuccess = true;
                        //    fileUploadAddResModel.AddCount = fileUpload_Add_Count;
                        //    fileUploadAddResModel.baseViewModel.Message = "上传的文件后缀不是.xlsx或者.xls格式，请更换文件";
                        //    fileUploadAddResModel.baseViewModel.ResponseCode = 200;
                        //    _ILogger.Information("上传的文件后缀不是.xlsx或者.xls格式，请更换文件");
                        //    return Ok(fileUploadAddResModel);   
                        //}

                        string randomname = _foodService.fileRandName(formFile.FileName);
                        filePath = Directory.GetCurrentDirectory() + "\\StaticFiles\\" + randomname;
                        if (formFile.Length > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                        string tag = _foodService.saveAttachInfo(Request.Form, randomname);
                        string userID= _foodService.getUserID(Request.Form, randomname);
                        fileUpload_Add_Count = _foodService.uploadTodatabase_User_Info(filePath, Request.Form["tablename"], tag,userID);
                    }

                    if (fileUpload_Add_Count > 0)
                    {
                        fileUploadAddResModel.IsSuccess = true;
                        fileUploadAddResModel.AddCount = fileUpload_Add_Count;
                        fileUploadAddResModel.baseViewModel.Message = "导入附件成功";
                        fileUploadAddResModel.baseViewModel.ResponseCode = 200;
                        _ILogger.Information("导入附件成功");
                        return Ok(fileUploadAddResModel);
                    }
                    else
                    {
                        fileUploadAddResModel.IsSuccess = false;
                        fileUploadAddResModel.AddCount = 0;
                        fileUploadAddResModel.baseViewModel.Message = "导入附件失败";
                        fileUploadAddResModel.baseViewModel.ResponseCode = 400;
                        _ILogger.Information("导入附件失败");
                        return Ok(fileUploadAddResModel);
                    }
            }
            catch (Exception e)
            {
                fileUploadAddResModel.IsSuccess = true;
                fileUploadAddResModel.AddCount = fileUpload_Add_Count;
                fileUploadAddResModel.baseViewModel.Message = "导入附件失败";
                fileUploadAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("导入附件失败");
                return Ok(fileUploadAddResModel);
            }
        }



    }
}