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
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.Repository.IntellFood
{
    public class Relate_Food_UserRepository : IRelate_Food_UserRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<User_Relate_Food> DbSet;

        public Relate_Food_UserRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Relate_Food>();
        }
        public void Add(User_Relate_Food obj)
        {
            DbSet.Add(obj);
        }

        public User_Relate_Food GetById(Guid id)
        {
            return DbSet.Find(id);
        }

      

        public void Update(User_Relate_Food obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

       
        #region 查询条件
        //根据条件查询点赞
        private Expression<Func<User_Relate_Food, bool>> SearchDelRelateWhere(FoodByUserPraiseViewModel foodByUserSearchViewModel)
        {
            var predicate = WhereExtension.True<User_Relate_Food>();//初始化where表达式
            predicate = predicate.And(p => p.Food_InfoId == foodByUserSearchViewModel.Food_InfoId);
            predicate = predicate.And(p => p.User_InfoId == foodByUserSearchViewModel.User_InfoId);
            return predicate;
        }
        #endregion
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 根据用户id和菜id 去关系表查
        /// </summary>
        /// <param name="foodByUserSearchViewModel"></param>
        /// <returns></returns>
        public int SearchFoodInfoByWhere(FoodByUserPraiseViewModel foodByUserSearchViewModel)
        {
           
            int userid = foodByUserSearchViewModel.User_InfoId;
            int foodid = foodByUserSearchViewModel.Food_InfoId;
            var queryResult = DbSet.Where(k => k.User_InfoId == userid && k.Food_InfoId == foodid)
                                                            .ToList();
            return queryResult.Count;
        }

      

        public IQueryable<User_Relate_Food> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户id和菜id删 点赞
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int RelateFoodToUserDel(FoodByUserPraiseViewModel foodByUserSearchViewModel)
        {

                var preciate = SearchDelRelateWhere(foodByUserSearchViewModel);
                var temp = DbSet.Single(preciate);
                DbSet.Remove(temp);
           
            return SaveChanges();
        }
        /// <summary>
        /// 查询点赞数量
        /// </summary>
        /// <param name="foodByFoodIdSearchViewModel"></param>
        /// <returns></returns>
        public List<FoodPraiseNumMiddlecs> RelateFoodToFoodIdSearch()
        {
            List<FoodPraiseNumMiddlecs> fpnm=new List<FoodPraiseNumMiddlecs>();
              var student= DbSet.GroupBy(m => m.Food_InfoId)
           .Select(k => new { Food_InfoId = k.Key, PraiseNum = k.Count() })
           .OrderBy(m => m.PraiseNum).ToList();

            foreach (var temp in student)
            {
                fpnm.Add(new FoodPraiseNumMiddlecs() { Food_InfoId = temp.Food_InfoId, PraiseNum = temp.PraiseNum });
            }
            return fpnm;

        }
    }
}
