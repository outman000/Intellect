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
    public class FlowNodeRepository : IFlowNodeRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Flow_Node> DbSet;

        public FlowNodeRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Flow_Node>();
        }

        public virtual void Add(Flow_Node obj)
        {
            DbSet.Add(obj);
        }

        public virtual Flow_Node GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Flow_Node> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Flow_Node obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public Flow_Node GetInfoByNodeId(int id)
        {
            Flow_Node node_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return node_Info;
        }

        public int DeleteByNodeIdList(List<int> IdList)
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

        public Flow_Node GetById(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<Flow_Node> IRepository<Flow_Node>.GetAll()
        {
            throw new NotImplementedException();
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

        public List<Flow_Node> SearchInfoByNodeWhere(FlowNodeSearchViewModel flowNodeSearchViewModel)
        {
            int SkipNum = flowNodeSearchViewModel.pageViewModel.CurrentPageNum * flowNodeSearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchNodeWhere(flowNodeSearchViewModel);
            var result = DbSet.Where(predicate).Include(b=>b.User_Info)
                                               .ThenInclude(c => c.User_Depart)
                                               .Include(d=>d.Pre_User_Info)
                                               .ThenInclude(c=>c.User_Depart)
                                               .Include(a => a.Repair_Info )
                                               .Include(a => a.Flow_NodeDefine)
                                               .Where(s=>s.User_Info.status!="1"&&
                                                       s.Pre_User_Info.status != "1"&&
                                                       s.Repair_Info.status!="1")
                .OrderByDescending(o => o.Repair_Info.repairsDate).ToList()
                .Skip(SkipNum)
                .Take(flowNodeSearchViewModel.pageViewModel.PageSize).ToList();

            return result;
        }
        //查询流转信息（重载查找父节点id）
        public List<Flow_Node> SearchInfoByNodeWhere(FlowInfoSearchViewModel fLowInfoSearchViewModel)
        {
     

            var predicate = SearchNodeWhere(fLowInfoSearchViewModel);
            var result = DbSet.Where(predicate)
                     .OrderBy(o => o.StartTime).ToList();

            return result;
        }
        //根据条件查询报修
        private Expression<Func<Flow_Node, bool>> SearchNodeWhere(FlowNodeSearchViewModel flowNodeSearchViewModel)
        {
            var predicate = WhereExtension.True<Flow_Node>();//初始化where表达式
            predicate = predicate.And(p => p.status.Contains(flowNodeSearchViewModel.status));
            if(flowNodeSearchViewModel.Flow_ProcedureId!=null)
            predicate = predicate.And(p => p.Flow_ProcedureId==flowNodeSearchViewModel.Flow_ProcedureId);
            if(flowNodeSearchViewModel.Repair_InfoId != null)
            predicate = predicate.And(p => p.Repair_InfoId==flowNodeSearchViewModel.Repair_InfoId);
            predicate = predicate.And(p => p.operate.Contains(flowNodeSearchViewModel.operate));
            if (flowNodeSearchViewModel.User_InfoId != null)
            predicate = predicate.And(p => p.User_InfoId==flowNodeSearchViewModel.User_InfoId);
            if (flowNodeSearchViewModel.isHandler != null)
                predicate = predicate.And(p => p.Repair_Info.isHandler == flowNodeSearchViewModel.isHandler);

            return predicate;
        }
        //根据条件查询流转（重载）
        private Expression<Func<Flow_Node, bool>> SearchNodeWhere(FlowInfoSearchViewModel fLowInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Flow_Node>();//初始化where表达式
            predicate = predicate.And(p => p.status.Contains(fLowInfoSearchViewModel.status));
            predicate = predicate.And(p => p.Flow_ProcedureId == fLowInfoSearchViewModel.Flow_ProcedureId);
            predicate = predicate.And(p => p.Repair_InfoId == fLowInfoSearchViewModel.Repair_InfoId);
            predicate = predicate.And(p => p.operate.Contains(fLowInfoSearchViewModel.operate));
            predicate = predicate.And(p => p.User_InfoId == fLowInfoSearchViewModel.User_InfoId);
            return predicate;
        }
        public IQueryable<Flow_Node> GetNodeAll(FlowNodeSearchViewModel flowNodeSearchViewModel)
        {
            var predicate = SearchNodeWhere(flowNodeSearchViewModel);

            return DbSet.Where(predicate);
        }
        //根据条件查询报修
        private Expression<Func<Flow_Node, bool>> SearchByRepairWhere(FlowNodeByRepairIdSearchViewModel flowNodeByRepairIdSearchViewModel)
        {
            var predicate = WhereExtension.True<Flow_Node>();//初始化where表达式
            predicate = predicate.And(p => p.Repair_InfoId == flowNodeByRepairIdSearchViewModel.Repair_InfoId);
            return predicate;
        }
        /// <summary>
        /// 根据表单Id查流转信息
        /// </summary>
        /// <param name="flowNodeByRepairIdSearchViewModel"></param>
        /// <returns></returns>
        public List<Flow_Node> SearchInfoByRepariIdWhere(FlowNodeByRepairIdSearchViewModel flowNodeByRepairIdSearchViewModel)
        {

            //查询条件
            var predicate = SearchByRepairWhere(flowNodeByRepairIdSearchViewModel);
            var result = DbSet.Where(predicate).Include(a=>a.User_Info).Include(a=>a.Parent_Flow_NodeDefine)
                .OrderBy(o => o.StartTime).ToList();

            return result;
        }
    }
}
