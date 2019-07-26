using Dto.IRepository.IntellRepair;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Repository.IntellRepair
{
    public class RelateRoleByNodeRepository : IRelateRoleByNodeRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Flow_Relate_NodeRole> DbSet;

        public RelateRoleByNodeRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Flow_Relate_NodeRole>();
        }

        public  void Add(Flow_Relate_NodeRole obj)
        {
            DbSet.Add(obj);
        }

        public Flow_Relate_NodeRole GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public  IQueryable<Flow_Relate_NodeRole> GetAll()
        {
            return DbSet;
        }

        public  void Update(Flow_Relate_NodeRole obj)
        {
            DbSet.Update(obj);
        }

        public  void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public Flow_Relate_NodeRole GetInfoByNodeDefineId(int id)
        {
            Flow_Relate_NodeRole node_Info = DbSet.Single(uid => uid.id.Equals(id));
            return node_Info;
        }
        /// <summary>
        /// 根据节点配置角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int RelateNodeToRoleAdd(List<Flow_Relate_NodeRole> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DbSet.Add(list[i]);
            }

            return SaveChanges();
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

        /// <summary>
        /// 根据节点删除角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int RelateNodeToRoleDel(List<int> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                var temp = DbSet.Single(a => a.id == list[i]);
                DbSet.Remove(temp);
            }

            return SaveChanges();
        }

        /// <summary>
        /// 根据节点查询角色
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public List<Flow_Relate_NodeRole> SearchRoleInfoByWhere(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            int SkipNum = roleByNodeSearchViewModel.pageViewModel.CurrentPageNum * roleByNodeSearchViewModel.pageViewModel.PageSize;
            int nodeid = roleByNodeSearchViewModel.NodeId;
            var queryResult = DbSet.Where(k => k.Flow_NodeDefineId == nodeid).Include(p => p.User_Role)
                .Skip(SkipNum)
                .Take(roleByNodeSearchViewModel.pageViewModel.PageSize)
                .ToList();
            return queryResult;
        }
        /// <summary>
        /// 根据节点查询角色数量
        /// </summary>
        /// <param name="roleByNodeSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Flow_Relate_NodeRole> Role_By_Node_Get_ALLNum(RoleByNodeSearchViewModel roleByNodeSearchViewModel)
        {
            int nodeid = roleByNodeSearchViewModel.NodeId;
            var queryResult = DbSet.Where(k => k.Flow_NodeDefineId == nodeid).Include(p => p.User_Role);
            return queryResult;
        }
    }
}
