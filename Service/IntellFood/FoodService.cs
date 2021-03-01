using AutoMapper;
using Dto.IRepository.IntellOpinionInfo;
using Dto.IService.IntellFood;
using Dtol.Attribute;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.Service.IntellFood
{
    public class FoodService : IFoodService
    {
        private readonly IFoodInfoRepository _IFoodInfoRepository;
        private readonly IRelate_Food_UserRepository  _IRelate_Food_UserRepository;
        private readonly IMapper _IMapper;
        NPOIClass EP_Plus = new NPOIClass();
        public FoodService(IFoodInfoRepository  foodInfoRepository, 
                            IRelate_Food_UserRepository relate_Food_UserRepository,
                            IMapper mapper)
        {
            _IFoodInfoRepository = foodInfoRepository;
            _IRelate_Food_UserRepository = relate_Food_UserRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 菜单增加
        /// </summary>
        /// <param name="foodInfoAddViewModel"></param>
        /// <returns></returns>
        public int Food_Add(FoodInfoAddViewModel foodInfoAddViewModel)
        {
          
            System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();
            var t = DateTime.Now;
            var tt = Convert.ToInt32(t.DayOfWeek) == 0 ? 7 : Convert.ToInt32(t.DayOfWeek);
            DateTime tmpDay1 = t.AddDays(8 - tt);

            //var t1 = DateTime.Parse("2020-12-31");


            int NextweekOfYear = gc.GetWeekOfYear(tmpDay1, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            string year = "";
            if (foodInfoAddViewModel.WeekNumber=="1"&& NextweekOfYear == 1)
            {
                 year = (DateTime.Now.Year+1).ToString();
            }
            else
            {
                year = DateTime.Now.Year .ToString();
            }
            var food_Info = _IMapper.Map<FoodInfoAddViewModel, Food_Info>(foodInfoAddViewModel);
            food_Info.AddDate = DateTime.Now;
            food_Info.status = "0";
            food_Info.isDelete = "0";
            food_Info.Year = year;
            _IFoodInfoRepository.Add(food_Info);
            return _IFoodInfoRepository.SaveChanges();
        }

      
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="foodInfoDelViewModel"></param>
        /// <returns></returns>
        public int Food_Delete(FoodInfoDelViewModel foodInfoDelViewModel)
        {

            int DeleteRowsNum = _IFoodInfoRepository
                 .DeleteByFoodInfoIdList(foodInfoDelViewModel.DeleleIdList);
            if (DeleteRowsNum == foodInfoDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取菜单数量
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        public int Food_Get_ALLNum(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            return _IFoodInfoRepository.GetFoodAll(foodInfoSearchViewModel).Count();
        }
        /// <summary>
        /// 菜单查询
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<FoodInfoSearchMiddle> Food_Search(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {

            List<Food_Info> food_info = _IFoodInfoRepository.SearchFoodInfoByWhere(foodInfoSearchViewModel);
            var food_Info_result = _IMapper.Map<List<Food_Info>, List< FoodInfoSearchMiddle>>(food_info);
         
            if (foodInfoSearchViewModel.userId!="0")
            {

                foreach (var food in food_Info_result)
                {
                    string temp = "2";
                    int up= _IRelate_Food_UserRepository.SearchByUserAndFoodId(food.Id, Convert.ToInt32(foodInfoSearchViewModel.userId), "0");
                     int down = _IRelate_Food_UserRepository.SearchByUserAndFoodId(food.Id, Convert.ToInt32(foodInfoSearchViewModel.userId), "1");
                    if (up > 0 )
                    {
                        temp = "0";//存在点赞
                    }
                    if (down > 0)
                    {
                        temp = "1";//存在差评
                    }
                    food.UpDownStatus = temp;
                
                }
             
            }
           

            return food_Info_result;
        }
        /// 只查询菜品种类
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<string> FoodType_Search(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
        
            List<string> foodType = _IFoodInfoRepository.SearchFoodTypeInfoByWhere(foodInfoSearchViewModel);
            return foodType;
        }
        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="foodInfoUpdateViewModel"></param>
        /// <returns></returns>
        public int Food_Update(FoodInfoUpdateViewModel foodInfoUpdateViewModel)
        {
            var food_Info = _IFoodInfoRepository.GetInfoByFoodId(foodInfoUpdateViewModel.Id);
            var food_Info_update = _IMapper.Map<FoodInfoUpdateViewModel, Food_Info>(foodInfoUpdateViewModel, food_Info);
            food_Info_update.updateDate = DateTime.Now;
            food_Info_update.updateUser = foodInfoUpdateViewModel.createUser;
            _IFoodInfoRepository.Update(food_Info_update);
            return _IFoodInfoRepository.SaveChanges();
        }

        public bool Food_Single(FoodInfoValideRepeat foodInfoValideRepeat)
        {

            IQueryable<Food_Info> Queryable_UserDepart = _IFoodInfoRepository
                                                                 .GetInfoByFoodId(foodInfoValideRepeat.Code);
            return (Queryable_UserDepart.Count() < 1) ?
                   true : false;
        }
        /// <summary>
        /// 根据用户和菜单点赞
        /// </summary>
        /// <param name="foodByUserSearchViewMode"></param>
        /// <returns></returns>
        public int Food_Relate_User(FoodByUserPraiseViewModel foodByUserSearchViewMode)
        {
            int count = _IRelate_Food_UserRepository.SearchFoodInfoByWhere(foodByUserSearchViewMode);
         
            if(count>0)
            {

                int DelNum = _IRelate_Food_UserRepository
                         .RelateFoodToUserDel(foodByUserSearchViewMode);
            
                return 0;
            }
            else
            {
                var node_Info = _IMapper.Map<FoodByUserPraiseViewModel, User_Relate_Food>(foodByUserSearchViewMode);
                _IRelate_Food_UserRepository.Add(node_Info);
                 _IRelate_Food_UserRepository.SaveChanges();
                return 1;
            }
        }
        /// <summary>
        /// 根据用户和菜单点差评
        /// </summary>
        /// <param name="foodByUserCpViewModel"></param>
        /// <returns></returns>
        public int Food_Relate_UserCp(FoodByUserAddCpViewModel foodByUserAddCpViewModel)
        {
            int count = _IRelate_Food_UserRepository.SearchFoodCpInfoByWhere(foodByUserAddCpViewModel);

            if (count > 0)
            {

                return -1;
            }
            else
            {
                var node_Info = _IMapper.Map<FoodByUserAddCpViewModel, User_Relate_Food>(foodByUserAddCpViewModel);
                _IRelate_Food_UserRepository.Add(node_Info);
                _IRelate_Food_UserRepository.SaveChanges();
                return 1;
            }
        }

        /// <summary>
        /// 根据用户和菜单查询差评信息
        /// </summary>
        /// <param name="foodByUserSearchCpViewModel"></param>
        /// <returns></returns>
        public List<FoodCpMiddlecs>  Food_Relate_User_Search_CP(FoodByUserSearchCpViewModel  foodByUserSearchCpViewModel)
        {

            List <User_Relate_Food>  user_Relate_Foods = _IRelate_Food_UserRepository.SearchFoodInfoByWhere(foodByUserSearchCpViewModel);
            var Cp_Info = _IMapper.Map<List<User_Relate_Food>, List<FoodCpMiddlecs>>(user_Relate_Foods);
            return Cp_Info;
        }
        /// <summary>
        /// 根据用户和菜单增加评价信息
        /// </summary>
        /// <param name="foodByUserSearchViewMode"></param>
        /// <returns></returns>
        public int Food_Relate_User_ADD_Pj(FoodByUserAddCpViewModel  foodByUserAddCpViewModel)
        {
            int count = _IRelate_Food_UserRepository.SearchFoodInfoByWhere(foodByUserAddCpViewModel);

            if (count > 0)
            {

                return -1;
            }
            else
            {
                var node_Info = _IMapper.Map<FoodByUserAddCpViewModel, User_Relate_Food>(foodByUserAddCpViewModel);
                _IRelate_Food_UserRepository.Add(node_Info);
                _IRelate_Food_UserRepository.SaveChanges();
                return 1;
            }
        }


        public int Food_Relate_User_Del(FoodByUserPraiseViewModel foodByUserSearchViewModelt)
        {
            int DelNum = _IRelate_Food_UserRepository
                     .RelateFoodToUserDel(foodByUserSearchViewModelt);

            return DelNum;
        }
        /// <summary>
        /// 点赞数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        public List<FoodPraiseNumMiddlecs> PraiseNumByFoodId(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs)
        {
            List < FoodPraiseNumMiddlecs > fp= _IRelate_Food_UserRepository.RelateFoodToFoodIdSearch(praiseNumSearchMiddlecs);
            return fp;
        }

        /// <summary>
        /// 差评数量
        /// </summary>
        /// <param name="praiseNumSearchMiddlecs"></param>
        /// <returns></returns>
        public List<FoodPraiseNumMiddlecs> CpNumByFoodId(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs)
        {
            List<FoodPraiseNumMiddlecs> fp = _IRelate_Food_UserRepository.RelateFoodToFoodIdCpSearch(praiseNumSearchMiddlecs);
            return fp;
        }
        /// <summary>
        ///根据菜Id删除点赞数量
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        public int By_Food_Id_Del(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel)
        {
            int DeleteRowsNum = _IRelate_Food_UserRepository
                  .ByFoodIdDel(foodByUserPraiseDelViewModel);
         
            return DeleteRowsNum;
         
        }
        /// <summary>
        ///根据菜Id删除差评数量
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        public int By_Food_Id_DelCp(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel)
        {
            int DeleteRowsNum = _IRelate_Food_UserRepository
                  .ByFoodIdDelCp(foodByUserPraiseDelViewModel);

            return DeleteRowsNum;

        }
        /// <summary>
        /// 食物差评数量
        /// </summary>
        /// <param name="foodByUserSearchCpViewModel"></param>
        /// <returns></returns>
        public int FoodCp_Get_ALLNum(FoodByUserSearchCpViewModel foodByUserSearchCpViewModel)
        {
            return _IRelate_Food_UserRepository.SearchFoodInfoByWhere(foodByUserSearchCpViewModel).Count();
        }


        /// <summary>
        /// 建议增加的菜
        /// </summary>
        /// <param name="suggestFoodAddViewModel"></param>
        /// <returns></returns>
        public int SuggestFood_Add(SuggestFoodAddViewModel  suggestFoodAddViewModel)
        {

            var suggestFood_Info = _IMapper.Map<SuggestFoodAddViewModel, Suggest_Food>(suggestFoodAddViewModel);
            suggestFood_Info.AddDate = DateTime.Now;
            suggestFood_Info.isDelete= "0";
            suggestFood_Info.User_InfoId = suggestFoodAddViewModel.createUser;
            _IFoodInfoRepository.Add_Suggest_Food(suggestFood_Info);
            return _IFoodInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 查询建议增加的菜
        /// </summary>
        /// <param name="suggestFoodSearchViewModel"></param>
        /// <returns></returns>
        public List<SuggestFoodSearchMiddleModel> SuggestFood_Search(SuggestFoodSearchViewModel  suggestFoodSearchViewModel)
        {
        
            List<Suggest_Food> suggestFood = _IFoodInfoRepository.SearchSuggestFoodInfoByWhere(suggestFoodSearchViewModel);
            var suggestFood_Info = _IMapper.Map<List<Suggest_Food>, List< SuggestFoodSearchMiddleModel>>(suggestFood);
            
            return suggestFood_Info;
        }
        /// <summary>
        /// 查询建议增加的菜数量
        /// </summary>
        /// <param name="suggestFoodSearchViewModel"></param>
        /// <returns></returns>
        public int SuggesttFood_Get_ALLNum(SuggestFoodSearchViewModel suggestFoodSearchViewModel)
        {
            return _IFoodInfoRepository.SearchSuggestFoodInfoByWhereNum(suggestFoodSearchViewModel).Count();
        }


        /// <summary>
        /// 生成模板
        /// </summary>
        /// <param name="templateAddViewModel"></param>
        /// <returns></returns>
        public int Template_Add(TemplateAddViewModel templateAddViewModel)
        {
            int n = 0;
            string year = "";
            System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();

            var t = DateTime.Now;
            var tt = Convert.ToInt32(t.DayOfWeek) == 0 ? 7 : Convert.ToInt32(t.DayOfWeek);
            DateTime tmpDay1 = t.AddDays(8 - tt);
            int weekOfYear = gc.GetWeekOfYear(tmpDay1, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);//获取下一周数



        //    int MaxWeekNumber = _IFoodInfoRepository.GetMaxWeekNumber();//查询当前菜单里面最大周数
            var foodInfo = _IFoodInfoRepository.GetInfoByWeekNumber(templateAddViewModel.Year ,templateAddViewModel.WeekNumber, templateAddViewModel.FoodType);
            if (weekOfYear == 1)//如果下一周是第一周，说明跨年了
                year= (DateTime.Now.Year + 1).ToString();
            else
                year = DateTime.Now.Year.ToString();
            foreach (var temp in foodInfo)
            {
                 
                    var food_temp = _IMapper.Map<Food_Info, TemplateAddMiddleViewModel>(temp);//去掉主键列
                    var food_result = _IMapper.Map<TemplateAddMiddleViewModel, Food_Info>(food_temp);//去掉主键列
                    food_result.WeekNumber = weekOfYear.ToString();
                    food_result.AddDate = DateTime.Now;
                    food_result.Year = year;
                    food_result.updateDate = temp.AddDate;
                    food_result.createUser = templateAddViewModel.createUser;
                    food_result.updateUser = templateAddViewModel.createUser;

                    var check = _IFoodInfoRepository.CheckTemplateAdd(year, weekOfYear.ToString(), food_result.Remark,food_result.FoodName, food_result.FoodType);
                    if (check.Count == 0)
                    {
                        _IFoodInfoRepository.Add(food_result);
                        _IFoodInfoRepository.SaveChanges();
                        n++;
                    }

            }
            return n;
        }

        /// <summary>
        /// 日期转化为第几周
        /// </summary>
        /// <param name="day"></param>
        /// <param name="WeekStart"></param>
        /// <returns></returns>
        public List<int> WeekOfMonthSearch()
        {

            System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();
            var t = DateTime.Now;
            int weekOfYear = gc.GetWeekOfYear(t, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);//本周

            var tt = Convert.ToInt32(t.DayOfWeek) == 0 ? 7 : Convert.ToInt32(t.DayOfWeek);
            DateTime tmpDay1 = t.AddDays(8 - tt);//下周时间
            int NextweekOfYear = gc.GetWeekOfYear(tmpDay1, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            if (weekOfYear != 0)
            {
                List<int> vs = new List<int>();
                vs.Add(weekOfYear);
                vs.Add(NextweekOfYear);
                return vs;
            }
            else
                return null;
        }

        /// <summary>
        /// 日期转化为第几周
        /// </summary>
        /// <param name="day"></param>
        /// <param name="WeekStart"></param>
        /// <returns></returns>
        public int WeekOfMonth(DateTime day, int WeekStart)
        {
            //WeekStart
            //1表示 周一至周日 为一周
            //2表示 周日至周六 为一周
            DateTime FirstofMonth;
            FirstofMonth = Convert.ToDateTime(day.Date.Year + "-" + day.Date.Month + "-" + 1);
            int i = (int)FirstofMonth.Date.DayOfWeek;
            if (i == 0)
            {
                i = 7;
            }
            if (WeekStart == 1)
            {
                return (day.Date.Day + i - 2) / 7 + 1;
            }
            if (WeekStart == 2)
            {
                return (day.Date.Day + i - 1) / 7;
            }
            return 0;
            //错误返回值0
        }


        //随机名称
        public string fileRandName(string fileRealname)
        {
            string RandName = "";
            string[] fileTail = fileRealname.Split('.');
            RandName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileTail[1];
            return RandName;
        }
        public string saveAttachInfo(IFormCollection fileinfo, string randomName)
        {
            string attid = Guid.NewGuid().ToString();
            var com_Attachs = new ComAttachs
            {
                Id = attid,
                UploadUserId = fileinfo["UploadUserId"],
                HrDeptId = Convert.ToInt32(fileinfo["HrDeptId"].ToString()),
                Filename = fileinfo["FileName"],
                FileType = fileinfo["FileType"],
                Employeeid = fileinfo["userid"],
                Physicsname = randomName,
                Createdate = DateTime.Now,
                Isdelete = "0",
                Formtablename = fileinfo["tablename"],
                //Filesize = fileinfo["filesize"],
                //Remark = fileinfo["Remark"]
            };
            _IFoodInfoRepository.Add2(com_Attachs);
            _IFoodInfoRepository.SaveChanges();
            return attid;
        }

        public string getUserID(IFormCollection fileinfo, string randomName)
        { 

            return fileinfo["UploadUserId"].ToString();
                   
        }

        //导入文件并存入数据库（菜单信息）
        public int uploadTodatabase_User_Info(string filepath, string tableName, string tag, string userID)
        {
            var list = EP_Plus.ExcelToList<Food_Info>(filepath, tag, tableName);
            _IFoodInfoRepository.AddRange_User_Info(list, userID);
            _IFoodInfoRepository.SaveChanges();
            return list.Count;
        }
    }
}
