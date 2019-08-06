
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto.IRepository.IntellUser;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.ResponseModel;
using System.Linq.Expressions;
using Dtol.EfCoreExtion;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.Repository.IntellUser
{
    public class UserRelateRoleRightRepository : IUserRelateRoleRightRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Relate_Role_Right> DbSet;

        public UserRelateRoleRightRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Relate_Role_Right>();
        }

        public virtual void Add(User_Relate_Role_Right obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Relate_Role_Right GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Relate_Role_Right> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Relate_Role_Right obj)
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

        public int RelateRoleToRightsAdd(List<User_Relate_Role_Right> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DbSet.Add(list[i]);
            }

            return SaveChanges();
        }

        public int RelateRoleToRightsDel(List<RelateRoleRightDelMiddlecs> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var preciate = SearchDelRelateWhere(list[i]);
                var temp = DbSet.Single(preciate);
                DbSet.Remove(temp);
            }

            return SaveChanges();
        }

        #region 查询条件
        //根据条件查询关系表
        private Expression<Func<User_Relate_Role_Right, bool>> SearchDelRelateWhere(RelateRoleRightDelMiddlecs  relateRoleRightDelMiddlecs )
        {
            var predicate = WhereExtension.True<User_Relate_Role_Right>();//初始化where表达式
            predicate = predicate.And(p => p.User_RightsId == relateRoleRightDelMiddlecs.User_RightsId);
            predicate = predicate.And(p => p.User_RoleId == relateRoleRightDelMiddlecs.User_RoleId);
            return predicate;
        }






        #endregion
        /// <summary>
        /// 根据权限查角色
        /// </summary>
        /// <param name="roleByRightsSearchViewModel"></param>
        /// <returns></returns>
        public List<User_Relate_Role_Right> SearchRoleInfoByRightsWhere(RoleByRightsSearchViewModel roleByRightsSearchViewModel)
        {
            int SkipNum = roleByRightsSearchViewModel.pageViewModel.CurrentPageNum * roleByRightsSearchViewModel.pageViewModel.PageSize;
            int rightid = roleByRightsSearchViewModel.RightId;
            var queryResult = DbSet.Where(k => k.User_RightsId == rightid).Include(p => p.User_Role)
                            .Skip(SkipNum)
                            .Take(roleByRightsSearchViewModel.pageViewModel.PageSize)
                              .OrderBy(o => o.Id)
                            .ToList();
            return queryResult;

        }

        /// <summary>
        /// 根据角色查权限
        /// </summary>
        /// <param name="rightsByRoleSearchViewModel"></param>
        /// <returns></returns>
        public List<User_Relate_Role_Right> SearchRightsInfoByRoleWhere(RightsByRoleSearchViewModel rightsByRoleSearchViewModel)
        {
            int SkipNum = rightsByRoleSearchViewModel.pageViewModel.CurrentPageNum * rightsByRoleSearchViewModel.pageViewModel.PageSize;
            int roleid = rightsByRoleSearchViewModel.RoleId;
            var queryResult = DbSet.Where(k => k.User_RoleId == roleid).Include(p => p.User_Rights)
                            .Skip(SkipNum)
                            .Take(rightsByRoleSearchViewModel.pageViewModel.PageSize)
                              .OrderBy(o => o.Id)
                            .ToList();
            return queryResult;

        }
        /// <summary>
        /// 根据角色查权限数量
        /// </summary>
        /// <param name="rightsByRoleSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<User_Relate_Role_Right> GetRightsByRoleAll(RightsByRoleSearchViewModel rightsByRoleSearchViewModel)
        {
            int roleid = rightsByRoleSearchViewModel.RoleId;
            var queryResult = DbSet.Where(k => k.User_RoleId == roleid).Include(p => p.User_Rights);

            return queryResult;
        }
        /// <summary>
        /// 各局权限查角色数量
        /// </summary>
        /// <param name="roleByRightsSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<User_Relate_Role_Right> GetRoleByRightsAll(RoleByRightsSearchViewModel roleByRightsSearchViewModel)
        {
            int rightid = roleByRightsSearchViewModel.RightId;
            var queryResult = DbSet.Where(k => k.User_RightsId == rightid).Include(p => p.User_Role);

            return queryResult;
        }
    }
}
