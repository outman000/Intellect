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
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Repository.IntellRepair
{
    public class FlowNodeDefineRepository : IFlowNodeDefineInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Flow_NodeDefine> DbSet;
        protected readonly DbSet<Flow_CurrentNodeAndNextNode> DbSet2;
        public FlowNodeDefineRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Flow_NodeDefine>();
            DbSet2 = Db.Set<Flow_CurrentNodeAndNextNode>();
        }

        public virtual void Add(Flow_NodeDefine obj)
        {
            DbSet.Add(obj);
        }

        public virtual Flow_NodeDefine GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Flow_NodeDefine> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Flow_NodeDefine obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public Flow_NodeDefine GetInfoByNodeDefineId(int id)
        {
            Flow_NodeDefine node_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return node_Info;
        }
        //根据流程定义主键Id去查开始节点Id
        public Flow_NodeDefine GetInfoByProcedureDefineId(int id)
        {
            Flow_NodeDefine node_Info = DbSet.Single(uid => uid.Flow_ProcedureDefineId==id &&
                                                            uid.NodeType=="开始类型");
            return node_Info;
        }

        /// <summary>
        /// 删除节点定义 列表
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public int DeleteByNodeDefineIdList(List<int> IdList)
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

        /// <summary>
        /// 根据条件查询节点定义信息
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Flow_NodeDefine> SearchInfoByNodeDefineWhere(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            int SkipNum = flowNodeDefineSearchViewModel.pageViewModel.CurrentPageNum * flowNodeDefineSearchViewModel.pageViewModel.PageSize;
            var preciateByNodeDefine = SearchNodeDefineWhere(flowNodeDefineSearchViewModel);
            IQueryable<Flow_NodeDefine> NodeDefine_Infos = Db.flow_NodeDefine.Where(preciateByNodeDefine);

            IQueryable<Flow_NodeDefine> SearchResultTemp = NodeDefine_Infos
                        .Include(a => a.Flow_ProcedureDefine).OrderBy(o => o.CreateTime)
                        .Skip(SkipNum)
                        .Take(flowNodeDefineSearchViewModel.pageViewModel.PageSize);
            return SearchResultTemp;
        }

        /// <summary>
        /// 根据当前节点查下一节点信息
        /// </summary>
        /// <param name="nextNodeByCurrentNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<Flow_CurrentNodeAndNextNode> SearchNextNodeInfoByWhere(NextNodeByCurrentNodeSearchViewModel  nextNodeByCurrentNodeSearchViewModel)
        {
            int SkipNum = nextNodeByCurrentNodeSearchViewModel.pageViewModel.CurrentPageNum * nextNodeByCurrentNodeSearchViewModel.pageViewModel.PageSize;
            int Flow_NodeDefineId = nextNodeByCurrentNodeSearchViewModel.Flow_NodeDefineId;
            var queryResult = DbSet2.Where(k => k.Flow_NodeDefineId== Flow_NodeDefineId && 
                                    k.Flow_NodeDefine.status == "0").Include(p => p.Flow_NextNodeDefine)
                                    .ThenInclude(p => p.Flow_ProcedureDefine).OrderBy(o => o.Id)
                 .Skip(SkipNum)
                .Take(nextNodeByCurrentNodeSearchViewModel.pageViewModel.PageSize)
                .ToList();
            return queryResult;
        }

        //根据当前节点查下一节点信息(重载)
        public List<Flow_CurrentNodeAndNextNode> SearchNextNodeInfoByWhere(int id)
        {
           

            var queryResult = DbSet2.Where(k => k.Flow_NodeDefineId == id &&
                                        k.Flow_NodeDefine.status == "0").Include(p => p.Flow_NextNodeDefine)  
                 .OrderBy(o => o.Id)
                .ToList();
            return queryResult;


        }
        /// <summary>
        /// 根据id条件查询节点定义信息（重载）
        /// </summary>
        /// <param name="flowNodeDefineSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Flow_NodeDefine> SearchInfoByNodeDefineWhere(int ProduceKeyId)
        {

            IQueryable<Flow_NodeDefine> NodeDefine_Infos = Db.flow_NodeDefine.Where(p=>p.Id== ProduceKeyId);
            IQueryable<Flow_NodeDefine> SearchResultTemp = NodeDefine_Infos
                        .Include(a => a.Flow_ProcedureDefine)
                        .OrderBy(o => o.CreateTime);
            return SearchResultTemp;
        }

        //根据条件查询节点定义
        private Expression<Func<Flow_NodeDefine, bool>> SearchNodeDefineWhere(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            var predicate = WhereExtension.True<Flow_NodeDefine>();//初始化where表达式
            predicate = predicate.And(p => p.NodeName.Contains(flowNodeDefineSearchViewModel.NodeName));
            predicate = predicate.And(p => p.NodeType.Contains(flowNodeDefineSearchViewModel.NodeType));
            predicate = predicate.And(p => p.status.Contains(flowNodeDefineSearchViewModel.status));
       
            if(flowNodeDefineSearchViewModel.Flow_ProcedureDefineId!=null)
            predicate = predicate.And(p => p.Flow_ProcedureDefine.Id==flowNodeDefineSearchViewModel.Flow_ProcedureDefineId);
            predicate = predicate.And(p => p.Flow_ProcedureDefine.ProcedureName.Contains(flowNodeDefineSearchViewModel.ProcedureName));
            if (flowNodeDefineSearchViewModel.Id != null)
                predicate = predicate.And(p => p.Id == flowNodeDefineSearchViewModel.Id);
            return predicate;
        }
        public Flow_NodeDefine GetById(int id)
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

        public IQueryable<Flow_NodeDefine> GetNodeDefineAll(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            var predicate = SearchNodeDefineWhere(flowNodeDefineSearchViewModel);

            return DbSet.Where(predicate);
        }
        /// <summary>
        /// 给当前节点添加下一节点
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int CurrentNodeAddNextNode(List<Flow_CurrentNodeAndNextNode> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DbSet2.Add(list[i]);
            }

            return SaveChanges();
        }

       /// <summary>
       /// 给当前节点删除下一节点
       /// </summary>
       /// <param name="list"></param>
       /// <returns></returns>
        public int RelateCurrentNodeToNextNodeDel(List<CurrentNodeToNextNodeDelMiddlecs> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var preciate = SearchDelRelateWhere(list[i]);
                var temp = DbSet2.Single(preciate);
                DbSet2.Remove(temp);
            }

            return SaveChanges();
        }
        #region 查询条件
        //根据条件查询关系表
        private Expression<Func<Flow_CurrentNodeAndNextNode, bool>> SearchDelRelateWhere(CurrentNodeToNextNodeDelMiddlecs  currentNodeToNextNodeDelMiddlecs)
        {
            var predicate = WhereExtension.True<Flow_CurrentNodeAndNextNode>();//初始化where表达式
            predicate = predicate.And(p => p.Flow_NodeDefineId == currentNodeToNextNodeDelMiddlecs.Flow_NodeDefineId);
            predicate = predicate.And(p => p.Flow_NextNodeDefineId == currentNodeToNextNodeDelMiddlecs.Flow_NextNodeDefineId);
            return predicate;
        }
        #endregion
    }
}
