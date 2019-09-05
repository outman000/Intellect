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
    public class ReminderInfoRepository : IReminderInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Reminder_Info> DbSet;

        public ReminderInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Reminder_Info>();
        }
        public virtual void Add(Reminder_Info obj)
        {
            DbSet.Add(obj);
        }

        public virtual Reminder_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Reminder_Info> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Reminder_Info obj)
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
        public List<Reminder_Info> SearchInfoByReminderWhere(ReminderInfoSearchViewModel reminderInfoSearchViewModel)
        {
            int SkipNum = reminderInfoSearchViewModel.pageViewModel.CurrentPageNum * reminderInfoSearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchSatisfactionWhere(reminderInfoSearchViewModel);
            var result = DbSet.Where(predicate).Include(b => b.User_Info)
                                               .ThenInclude(c => c.User_Depart)
                                               .Include(a => a.Repair_Info)
                                               .Where(s => s.User_Info.status != "1" &&
                                                       s.Repair_Info.status != "1")

                .Skip(SkipNum)
                .Take(reminderInfoSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.AddDate);

            return result.ToList();
        }

        //根据条件查询催单
        private Expression<Func<Reminder_Info, bool>> SearchSatisfactionWhere(ReminderInfoSearchViewModel reminderInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Reminder_Info>();//初始化where表达式
            predicate = predicate.And(p => p.status.Contains(reminderInfoSearchViewModel.status));
            predicate = predicate.And(p => p.User_Info.User_Depart.Name.Contains(reminderInfoSearchViewModel.Name));
            predicate = predicate.And(p => p.User_Info.UserName.Contains(reminderInfoSearchViewModel.UserName));
            if (reminderInfoSearchViewModel.Repair_InfoId != null)
                predicate = predicate.And(p => p.Repair_InfoId == reminderInfoSearchViewModel.Repair_InfoId);
            if (reminderInfoSearchViewModel.AddDate != null)
                predicate = predicate.And(p => p.AddDate == reminderInfoSearchViewModel.AddDate);
            predicate = predicate.And(p => p.Repair_Info.RepairsTitle.Contains(reminderInfoSearchViewModel.RepairTitle));
            return predicate;
        }
    }
}
