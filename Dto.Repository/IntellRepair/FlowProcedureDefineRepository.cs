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
    public class FlowProcedureDefineRepository : IFlowProcedureDefineRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Flow_ProcedureDefine> DbSet;

        public FlowProcedureDefineRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Flow_ProcedureDefine>();
        }

        public void Add(Flow_ProcedureDefine obj)
        {
            DbSet.Add(obj);
        }
        /// <summary>
        /// 批量删除流程
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public int DeleteByProcedureDefineIdList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet.Single(w => w.Id == IdList[i]);
                model.Status = "1";
                DbSet.Update(model);
                SaveChanges();
                DeleteRowNum = i + 1;
            }
            return DeleteRowNum;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Flow_ProcedureDefine> GetAll()
        {
            return DbSet;
        }

        public Flow_ProcedureDefine GetById(int id)
        {
            return DbSet.Find(id);
        }

        public Flow_ProcedureDefine GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Flow_ProcedureDefine GetInfoByProcedureDefineId(int id)
        {
            Flow_ProcedureDefine procedure_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return procedure_Info;
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
        /// 查询流程定义信息
        /// </summary>
        /// <param name="flowProcedureDefineSearchViewModel"></param>
        /// <returns></returns>
        public List<Flow_ProcedureDefine> SearchInfoByProcedureDefineWhere(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel)
        {

            int skipNum = flowProcedureDefineSearchViewModel.pageViewModel.CurrentPageNum * flowProcedureDefineSearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchProcedureDefineWhere(flowProcedureDefineSearchViewModel);
            return DbSet.Where(predicate)
                  .Skip(skipNum)
                  .Take(flowProcedureDefineSearchViewModel.pageViewModel.PageSize)
                  .OrderBy(o => o.Createtime).ToList();
        }

        //根据条件查询流程
        private Expression<Func<Flow_ProcedureDefine, bool>> SearchProcedureDefineWhere(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel)
        {
            var predicate = WhereExtension.True<Flow_ProcedureDefine>();//初始化where表达式
            predicate = predicate.And(p => p.ProcedureName.Contains(flowProcedureDefineSearchViewModel.ProcedureName));
            predicate = predicate.And(p => p.ProcedureCode.Contains(flowProcedureDefineSearchViewModel.ProcedureCode));
            predicate = predicate.And(p => p.Type.Contains(flowProcedureDefineSearchViewModel.Type));
            predicate = predicate.And(p => p.Status.Contains(flowProcedureDefineSearchViewModel.Status));
          if(flowProcedureDefineSearchViewModel.Id!=null)
            predicate = predicate.And(p => p.Id==flowProcedureDefineSearchViewModel.Id);
            return predicate;
        }
        public void Update(Flow_ProcedureDefine obj)
        {
            DbSet.Update(obj);
        }

        public IQueryable<Flow_ProcedureDefine> GetInfoByProcedureDefineId(string ProcedureCode)
        {
            IQueryable<Flow_ProcedureDefine> procedure_Infos = DbSet.Where(uid => uid.ProcedureCode.Equals(ProcedureCode));
            return procedure_Infos;
        }

        public IQueryable<Flow_ProcedureDefine> GetProcedureDefineAll(FlowProcedureDefineSearchViewModel flowProcedureDefineSearchViewModel)
        {
            var predicate = SearchProcedureDefineWhere(flowProcedureDefineSearchViewModel);

            return DbSet.Where(predicate);
        }
    }
}
