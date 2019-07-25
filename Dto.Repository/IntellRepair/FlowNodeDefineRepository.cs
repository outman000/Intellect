﻿using Dto.IRepository.IntellRepair;
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
    public class FlowNodeDefineRepository : IFlowNodeDefineInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Flow_NodeDefine> DbSet;

        public FlowNodeDefineRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Flow_NodeDefine>();
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
                DbSet.Remove(model);
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

            IQueryable<Flow_NodeDefine> SearchResultTemp = NodeDefine_Infos.Include(a => a.Flow_NextNodeDefine)
                        .Include(a => a.Flow_ProcedureDefine)
                        .Skip(SkipNum)
                        .Take(flowNodeDefineSearchViewModel.pageViewModel.PageSize);
            return SearchResultTemp;
        }

        //根据条件查询报修
        private Expression<Func<Flow_NodeDefine, bool>> SearchNodeDefineWhere(FlowNodeDefineSearchViewModel flowNodeDefineSearchViewModel)
        {
            var predicate = WhereExtension.True<Flow_NodeDefine>();//初始化where表达式
            predicate = predicate.And(p => p.NodeName.Contains(flowNodeDefineSearchViewModel.NodeName));
            predicate = predicate.And(p => p.NodeType.Contains(flowNodeDefineSearchViewModel.NodeType));
            predicate = predicate.And(p => p.Flow_NextNodeDefine.NodeName.Contains(flowNodeDefineSearchViewModel.FlowNextName));
            predicate = predicate.And(p => p.Flow_ProcedureDefine.ProcedureName.Contains(flowNodeDefineSearchViewModel.ProcedureName));
           
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
    }
}