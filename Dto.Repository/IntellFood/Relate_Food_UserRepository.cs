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


        #region 查询条件
        //根据条件查询点赞
        private Expression<Func<User_Relate_Food, bool>> SearchDelRelateWhere(int id)
        {
            var predicate = WhereExtension.True<User_Relate_Food>();//初始化where表达式
            predicate = predicate.And(p => p.Food_InfoId == id);
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
            var queryResult = DbSet.Where(k => k.User_InfoId == userid &&
                                          k.Food_InfoId == foodid && 
                                          k.User_Info.status=="0").ToList();
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
        /// 根据菜id删 点赞
        /// </summary>
        /// <param name="foodByUserPraiseDelViewModel"></param>
        /// <returns></returns>
        public int ByFoodIdDel(FoodByUserPraiseDelViewModel foodByUserPraiseDelViewModel)
        {

            //var preciate = SearchDelRelateWhere(foodByUserPraiseDelViewModel);
            //var temp = DbSet.Where(preciate).ToList();
            //for(int i=0;i<temp.Count;i++)
            //{
            //    DbSet.Remove(temp[i]);
            //}
            //return SaveChanges();

      
                int DeleteRowNum = 1;
                for (int i = 0; i < foodByUserPraiseDelViewModel.DeleleIdList.Count; i++)
                {
                    //var model = DbSet.Single(w => w.Food_InfoId == foodByUserPraiseDelViewModel.DeleleIdList[i]);
                    var preciate = SearchDelRelateWhere(foodByUserPraiseDelViewModel.DeleleIdList[i]);
                    var temp = DbSet.Where(preciate).ToList();
                    for(int j=0;j<temp.Count;j++)
                    {
                        DbSet.Remove(temp[j]);
                        SaveChanges();
                      DeleteRowNum = i + 1;
                    }   
                   
                }
                return DeleteRowNum;
 
        }

        /// <summary>
        /// 查询点赞数量
        /// </summary>
        /// <param name="foodByFoodIdSearchViewModel"></param>
        /// <returns></returns>
        public List<FoodPraiseNumMiddlecs> RelateFoodToFoodIdSearch(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs)
        {
            string foodtype = praiseNumSearchMiddlecs.FoodType;
            string foodName = praiseNumSearchMiddlecs.FoodName;
            string remark = praiseNumSearchMiddlecs.Remark;
            
            List<FoodPraiseNumMiddlecs> fpnm=new List<FoodPraiseNumMiddlecs>();
            //var p = SearchFoodWhere(praiseNumSearchMiddlecs);
            var food = DbSet.Include(a => a.Food_Info)
                .Where(b => b.Food_Info.FoodType.Contains(foodtype)&& 
                        b.Food_Info.FoodName.Contains(foodName)&&
                        b.Food_Info.Remark.Contains(remark)&&
                        b.User_Info.status=="0")
                .GroupBy(m => new { m.Food_InfoId, m.Food_Info.FoodName,
                                    m.Food_Info.FoodType,m.Food_Info.Remark })
                .Select(k => new
                {
                 ft= k.Key.FoodType,//地点类型
                 rm= k.Key.Remark,//星期
                 fn = k.Key.FoodName,//菜名
                 FoodId = k.Key.Food_InfoId,//主键Id
                 PraiseNum = k.Count()
                     
                }).OrderByDescending(m => m.PraiseNum).ToList();

            foreach (var temp in food)
            {
                fpnm.Add(new FoodPraiseNumMiddlecs() { Food_InfoId = temp.FoodId, FoodName = temp.fn,FoodType=temp.ft,Remark=temp.rm, PraiseNum = temp.PraiseNum });
            }
            return fpnm;

        }

        #region 查询条件
        //根据条件查询部门
        private Expression<Func<Food_Info, bool>> SearchFoodWhere(PraiseNumSearchMiddlecs praiseNumSearchMiddlecs)
        {
            var predicate = WhereExtension.True<Food_Info>();//初始化where表达式

            predicate = predicate.And(p => p.FoodType == praiseNumSearchMiddlecs.FoodType);
            predicate = predicate.And(p => p.FoodName == praiseNumSearchMiddlecs.FoodName);
            predicate = predicate.And(p => p.Remark == praiseNumSearchMiddlecs.Remark);
            return predicate;
        }
        #endregion
    }
}
