using Dto.IRepository.IntellOpinionInfo;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.Repository.IntellFood
{
    public class FoodInfoRepository : IFoodInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Food_Info> DbSet;
        protected readonly DbSet<FoodTypeMiddlecs> DbSet2;
        protected readonly DbSet<Suggest_Food> DbSet3;
        protected readonly DbSet<ComAttachs> DbSet4;
        public FoodInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Food_Info>();
            DbSet2 = Db.Set<FoodTypeMiddlecs>();
            DbSet3 = Db.Set<Suggest_Food>();
            DbSet4 = Db.Set<ComAttachs>();
        }

        public  void Add(Food_Info obj)
        {
            DbSet.Add(obj);
        }
        public void Add_Suggest_Food(Suggest_Food obj)
        {
            DbSet3.Add(obj);
        }
        public virtual void Add2(ComAttachs obj)
        {
            DbSet4.Add(obj);
        }

        /// <summary>
        /// 批量导入数据库（菜单信息）
        /// </summary>
        /// <param name="recommendedDirectories"></param>
        public void AddRange_User_Info(List<Food_Info> user_Infos,string userID)
        {
            foreach (var a in user_Infos)
            {
                if(a.FoodName==""|| a.Remark == "" || a.Picture == ""||a.WeekNumber == "" ||a.Year==""||a.FoodType=="")
                {
                    continue;
                }
                a.AddDate = DateTime.Now;
                a.isDelete = "0";
                a.createUser = userID;
                a.status = "0";
                DbSet.Add(a);
            }

        }
        public  Food_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public  IQueryable<Food_Info> GetAll()
        {
            return DbSet;
        }

        public  void Update(Food_Info obj)
        {
            DbSet.Update(obj);
        }

        public  void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int DeleteByFoodInfoIdList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet.Single(w => w.Id == IdList[i]);
                model.isDelete = "1";
                model.updateDate = DateTime.Now;
                DbSet.Update(model);
                SaveChanges();
                DeleteRowNum = i + 1;
            }
            return DeleteRowNum;


        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

       

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        public List<Suggest_Food> SearchSuggestFoodInfoByWhereNum(SuggestFoodSearchViewModel suggestFoodSearchViewModel)
        {
      
            //查询条件
            var predicate = SearchSuggestFoodWhere(suggestFoodSearchViewModel);
            var result = DbSet3.Where(predicate).OrderByDescending(a => a.AddDate).ToList();
            return result;
        }


        public List<Suggest_Food> SearchSuggestFoodInfoByWhere(SuggestFoodSearchViewModel  suggestFoodSearchViewModel)
        {
            //查询条件
            int SkipNum = suggestFoodSearchViewModel.pageViewModel.CurrentPageNum * suggestFoodSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchSuggestFoodWhere(suggestFoodSearchViewModel);
            var result = DbSet3.Where(predicate).OrderByDescending(a=>a.AddDate)
                .Skip(SkipNum)
                .Take(suggestFoodSearchViewModel.pageViewModel.PageSize)
                .ToList();

            return result;
        }

        public List<Food_Info> SearchFoodInfoByWhere(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            //查询条件
            int SkipNum = foodInfoSearchViewModel.pageViewModel.CurrentPageNum * foodInfoSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchFoodWhere(foodInfoSearchViewModel);
            var result = DbSet.Where(predicate).OrderBy(o => o.AddDate).ToList()
                .Skip(SkipNum)
                .Take(foodInfoSearchViewModel.pageViewModel.PageSize)
                .ToList();

            return result;
        }

        //只查菜品类型
        public List<string> SearchFoodTypeInfoByWhere(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
         
            //查询条件
            var predicate = SearchFoodWhere(foodInfoSearchViewModel);
            var result = DbSet.Where(predicate).Select( a=>a.Picture)           
                .Distinct()
                .ToList();
            return result;
        }
        #region 查询条件
        //根据条件查询建议添加的菜
        private Expression<Func<Suggest_Food, bool>> SearchSuggestFoodWhere(SuggestFoodSearchViewModel  suggestFoodSearchViewModel)
        {
            var predicate = WhereExtension.True<Suggest_Food>();//初始化where表达式
            predicate = predicate.And(p => p.User_Info.UserName.Contains(suggestFoodSearchViewModel.userName));
            if(suggestFoodSearchViewModel.User_DepartId!=null)
            predicate = predicate.And(p => p.User_Info.User_DepartId== suggestFoodSearchViewModel.User_DepartId);
            if (suggestFoodSearchViewModel.strDate != null &&   suggestFoodSearchViewModel.endDate!= null)
            predicate = predicate.And(p => p.AddDate >= suggestFoodSearchViewModel.strDate && p.AddDate <= suggestFoodSearchViewModel.endDate);
            predicate = predicate.And(p => p.isDelete=="0");

            return predicate;
        }
        #endregion


        #region 查询条件
        //根据条件查询部门
        private Expression<Func<Food_Info, bool>> SearchFoodWhere(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Food_Info>();//初始化where表达式
            predicate = predicate.And(p => p.Price.ToString().Contains(foodInfoSearchViewModel.Price.ToString()));
            predicate = predicate.And(p => p.FoodName.Contains(foodInfoSearchViewModel.FoodName));
            predicate = predicate.And(p => p.FoodType.Contains(foodInfoSearchViewModel.FoodType));
            predicate = predicate.And(p => p.Remark.Contains(foodInfoSearchViewModel.Remark));
            if(foodInfoSearchViewModel.flag == "0")//手机，默认查询当前周
            {
                System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();

                int weekOfYear = gc.GetWeekOfYear(DateTime.Now, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                predicate = predicate.And(p => p.WeekNumber == weekOfYear.ToString());//默认当前周
                predicate = predicate.And(p => p.Year == DateTime.Now.Year.ToString());//默认当前年
            }
            else//PC查询任意周
            {
                if(foodInfoSearchViewModel.flag!="")
                predicate = predicate.And(p => p.WeekNumber == foodInfoSearchViewModel.flag);
                predicate = predicate.And(p => p.Year.Contains(foodInfoSearchViewModel.Year));
            }
            predicate = predicate.And(p => p.isDelete == "0");
          
            return predicate;
        }
        #endregion
        /// <summary>
        /// 菜单数量
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Food_Info> GetFoodAll(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            var predicate = SearchFoodWhere(foodInfoSearchViewModel);

            return DbSet.Where(predicate);
        }

        public Food_Info GetInfoByFoodId(int id)
        {
            Food_Info food_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return food_Info;
        }

        public IQueryable<Food_Info> GetInfoByFoodId(string code)
        {
            IQueryable<Food_Info> food_Infos = DbSet.Where(uid => uid.Code.Equals(code));
            return food_Infos;
        }

        /// <summary>
        /// 根据周数查询食品信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<Food_Info> GetInfoByWeekNumber(string y, string wn, string FoodType)
        {
            List<Food_Info> food_Infos = DbSet.Where(uid => uid.isDelete =="0" && uid.FoodType.Contains(FoodType)
                                                     &&  uid.WeekNumber == wn  && uid.Year == y).ToList();
            return food_Infos;
        }

        /// <summary>
        /// 获取数据库最大周数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int GetMaxWeekNumber()
        {
           var MaxWeekNumberList = DbSet.Where(uid => uid.isDelete == "0" && uid.Year == DateTime.Now.Year.ToString()).OrderByDescending(uid=>uid.WeekNumber).ToList();
            if (MaxWeekNumberList.Count > 0)
                return Convert.ToInt32(MaxWeekNumberList[0].WeekNumber);
            return 0;
        }
        /// <summary>
        /// 检查是否已存在数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<Food_Info> CheckTemplateAdd(string year,string zhou,string xq,string fn,string foodtype)
        {
            var Food_InfoList = DbSet.Where(uid => uid.isDelete == "0" && uid.Year == year && uid.WeekNumber == zhou &&uid.Remark == xq && uid.FoodName == fn && uid.FoodType == foodtype)
                                           .OrderByDescending(uid => uid.WeekNumber).ToList();
          
            return Food_InfoList;
        }
    }
}
