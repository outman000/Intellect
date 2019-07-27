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
    public class FlowProcedureInfoRepository : IFlowProcedureInfoRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<Flow_Procedure> DbSet;

        public FlowProcedureInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Flow_Procedure>();
        }

        public void Add(Flow_Procedure obj)
        {
            DbSet.Add(obj);
        }

        public int DeleteByProcedureList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet.Single(w => w.Id == IdList[i]);
                model.status = "1";
                DbSet.Update(model);
                SaveChanges();
                DeleteRowNum = i + 1;
            }
            return DeleteRowNum;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Flow_Procedure> GetAll()
        {
            return DbSet;
        }

        public Flow_Procedure GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Flow_Procedure GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public Flow_Procedure GetInfoByProcedureId(int id)
        {
            Flow_Procedure node_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return node_Info;
        }

        public IQueryable<Flow_Procedure> GetProcedureAll(FlowProcedureSearchViewModel flowProcedureSearchViewModel)
        {
            var predicate = SearchProcedureWhere(flowProcedureSearchViewModel);

            return DbSet.Where(predicate);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        /// <summary>
        /// 根据条件查流程
        /// </summary>
        /// <param name="flowProcedureSearchViewModel"></param>
        /// <returns></returns>
        public List<Flow_Procedure> SearchInfoByProcedureWhere(FlowProcedureSearchViewModel flowProcedureSearchViewModel)
        {
            //查询条件
            int SkipNum = flowProcedureSearchViewModel.pageViewModel.CurrentPageNum * flowProcedureSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchProcedureWhere(flowProcedureSearchViewModel);
            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(flowProcedureSearchViewModel.pageViewModel.PageSize)
                .ToList();

            return result;
        }

        public void Update(Flow_Procedure obj)
        {
            DbSet.Update(obj);
        }
        #region 查询条件
        //根据条件查询部门
        private Expression<Func<Flow_Procedure, bool>> SearchProcedureWhere(FlowProcedureSearchViewModel flowProcedureSearchViewModel)
        {
            var predicate = WhereExtension.True<Flow_Procedure>();//初始化where表达式
            predicate = predicate.And(p => p.status.Contains(flowProcedureSearchViewModel.status));
            predicate = predicate.And(p => p.Repair_InfoId== flowProcedureSearchViewModel.Repair_InfoId);
            return predicate;
        }




        #endregion
    }
}
