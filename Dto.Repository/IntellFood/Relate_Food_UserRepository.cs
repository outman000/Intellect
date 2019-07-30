using Dto.IRepository.IntellFood;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<User_Relate_Food> SearchFoodInfoByWhere(FoodByUserSearchViewModel foodByUserSearchViewModel)
        {
            int userid = foodByUserSearchViewModel.UserId;
            int foodid = foodByUserSearchViewModel.FoodId;
            var queryResult = DbSet.Where(k => k.User_InfoId == userid);
            var Result = queryResult.Where(k=> k.Food_InfoId==foodid).ToList();
            return Result;
        }

      

        public IQueryable<User_Relate_Food> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
