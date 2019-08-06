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
    public class RepairInfoRepository : IRepairInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Repair_Info> DbSet;

        public RepairInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Repair_Info>();
        }

        public virtual void Add(Repair_Info obj)
        {
            DbSet.Add(obj);
        }

        public virtual Repair_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Repair_Info> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Repair_Info obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public Repair_Info GetInfoByRepairId(int id)
        {
            Repair_Info  repair_Info = DbSet.Single(uid => uid.id.Equals(id));
            return repair_Info;
        }

        public int DeleteByRepairIdList(List<int> IdList)
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

        public IQueryable<Repair_Info> SearchInfoByRepairWhere(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            int SkipNum = repairInfoSearchViewModel.pageViewModel.CurrentPageNum * repairInfoSearchViewModel.pageViewModel.PageSize;
            var preciateByRepair = SearchRepairWhere(repairInfoSearchViewModel);
            IQueryable<Repair_Info> repair_Infos = Db.repair_Info.Where(preciateByRepair);

            IQueryable<Repair_Info> SearchResultTemp = repair_Infos.Include(a => a.User_Info)
                        .Include(a => a.User_Depart)
                        .Skip(SkipNum)
                        .Take(repairInfoSearchViewModel.pageViewModel.PageSize).OrderBy(o => o.repairsDate);
            return SearchResultTemp;
        }

        public Repair_Info GetById(int id)
        {
            return DbSet.Find(id);
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

        //根据条件查询报修
        private Expression<Func<Repair_Info, bool>> SearchRepairWhere(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Repair_Info>();//初始化where表达式
            predicate = predicate.And(p => p.User_Info.UserName.Contains(repairInfoSearchViewModel.UserName));
            predicate = predicate.And(p => p.User_Depart.Name.Contains(repairInfoSearchViewModel.Name));
            predicate = predicate.And(p => p.RepairsTitle.Contains(repairInfoSearchViewModel.RepairsTitle));
            predicate = predicate.And(p => p.RepairsType.Contains(repairInfoSearchViewModel.RepairsType));
            predicate = predicate.And(p => p.status.Contains(repairInfoSearchViewModel.status));
            return predicate;
        }

        public IQueryable<Repair_Info> GetInfoByRepairAll(RepairInfoSearchViewModel repairInfoSearchViewMode)
        {
            var predicate = SearchRepairWhere(repairInfoSearchViewMode);

            return DbSet.Where(predicate);
        }
    }
}
