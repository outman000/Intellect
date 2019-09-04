using Dto.IRepository.IntellRepair;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Repository.IntellRepair
{
    public class SatisfactionInfoRepository : ISatisfactionInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Satisfaction_Info> DbSet;

        public SatisfactionInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Satisfaction_Info>();
        }

        public virtual void Add(Satisfaction_Info obj)
        {
            DbSet.Add(obj);
        }

        public virtual Satisfaction_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Satisfaction_Info> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Satisfaction_Info obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
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

        public List<Satisfaction_Info> SearchInfoByRepairWhere(SatisfactionInfoSearchViewModel satisfactionInfoSearchViewModel)
        {
            int SkipNum = satisfactionInfoSearchViewModel.pageViewModel.CurrentPageNum * satisfactionInfoSearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchSatisfactionWhere(satisfactionInfoSearchViewModel);
            var result = DbSet.Where(predicate).Include(b => b.User_Info)
                                               .ThenInclude(c => c.User_Depart) 
                                               .Include(a => a.Repair_Info)
                                               .Where(s => s.User_Info.status != "1" &&
                                                       s.Repair_Info.status != "1")

                .Skip(SkipNum)
                .Take(satisfactionInfoSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.AddDate);

            return result.ToList();
        }

        //根据条件查询报修
        private Expression<Func<Satisfaction_Info, bool>> SearchSatisfactionWhere(SatisfactionInfoSearchViewModel satisfactionInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Satisfaction_Info>();//初始化where表达式
            predicate = predicate.And(p => p.status.Contains(satisfactionInfoSearchViewModel.status));
          
                predicate = predicate.And(p => p.User_Info.UserName == satisfactionInfoSearchViewModel.UserName);
            if (satisfactionInfoSearchViewModel.Repair_InfoId != null)
                predicate = predicate.And(p => p.Repair_InfoId == satisfactionInfoSearchViewModel.Repair_InfoId);
            if (satisfactionInfoSearchViewModel.AddDate != null)
                predicate = predicate.And(p => p.AddDate == satisfactionInfoSearchViewModel.AddDate);
            predicate = predicate.And(p => p.Repair_Info.RepairsTitle == satisfactionInfoSearchViewModel.RepairTitle);
            return predicate;
        }
    }
}
