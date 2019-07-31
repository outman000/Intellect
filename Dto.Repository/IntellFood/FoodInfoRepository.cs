using Dto.IRepository.IntellFood;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.Repository.IntellFood
{
    public class FoodInfoRepository : IFoodInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Food_Info> DbSet;

        public FoodInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Food_Info>();
        }

        public  void Add(Food_Info obj)
        {
            DbSet.Add(obj);
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
                DbSet.Remove(model);
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

   

        public List<Food_Info> SearchFoodInfoByWhere(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            //查询条件
            int SkipNum = foodInfoSearchViewModel.pageViewModel.CurrentPageNum * foodInfoSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchFoodWhere(foodInfoSearchViewModel);
            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(foodInfoSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o).ToList();

            return result;
        }
        #region 查询条件
        //根据条件查询部门
        private Expression<Func<Food_Info, bool>> SearchFoodWhere(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Food_Info>();//初始化where表达式
            predicate = predicate.And(p => p.Price.ToString().Contains(foodInfoSearchViewModel.Price.ToString()));
            predicate = predicate.And(p => p.FoodName.Contains(foodInfoSearchViewModel.FoodName));
            predicate = predicate.And(p => p.FoodType.Contains(foodInfoSearchViewModel.FoodType));
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

       




      
    }
}
