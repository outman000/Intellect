
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

        public int RelateRoleToRightsDel(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var temp = DbSet.Single(a => a.Id == list[i]);
                DbSet.Remove(temp);
            }

            return SaveChanges();
        }
        /// <summary>
        /// 根据权限查角色
        /// </summary>
        /// <param name="roleByRightsSearchViewModel"></param>
        /// <returns></returns>
        public List<User_Relate_Role_Right> SearchRoleInfoByRightsWhere(RoleByRightsSearchViewModel roleByRightsSearchViewModel)
        {
            int rightid = roleByRightsSearchViewModel.RightId;
            var queryResult = DbSet.Where(k => k.User_RightsId == rightid).Include(p => p.User_Role)
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
            int roleid = rightsByRoleSearchViewModel.RoleId;
            var queryResult = DbSet.Where(k => k.User_RoleId == roleid).Include(p => p.User_Rights)
                .ToList();
            return queryResult;

        }
    }
}
