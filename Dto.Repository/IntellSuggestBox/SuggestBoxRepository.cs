using Dto.IRepository.IntellFood;
using Dto.IRepository.IntellSuggestBox;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.Repository.IntellSuggestBox
{
    public class SuggestBoxRepository : ISuggestBoxRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Suggest_Box> DbSet;

        public SuggestBoxRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Suggest_Box>();
        }

        public void Add(Suggest_Box obj)
        {
            DbSet.Add(obj);
        }

        public Suggest_Box GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<Suggest_Box> GetAll()
        {
            return DbSet;
        }

        public void Update(Suggest_Box obj)
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
                var model = DbSet.Single(w => w.id == IdList[i]);
                model.status = "1";
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

        public Suggest_Box GetInfoBySuggestBoxId(int id)
        {
            Suggest_Box suggestBox_Info = DbSet.Single(uid => uid.id.Equals(id));
            return suggestBox_Info;
        }

        IQueryable<Suggest_Box> IRepository<Suggest_Box>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
