
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto.IRepository.IntellUser;
using ViewModel.UserViewModel.MiddleModel;
using Dtol.EfCoreExtion;
using System.Linq.Expressions;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Repository.IntellUser
{
    public class UserRelateInfoRoleRepository : IUserRelateInfoRoleRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Relate_Info_Role> DbSet;

        public UserRelateInfoRoleRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Relate_Info_Role>();
        }

        public virtual void Add(User_Relate_Info_Role obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Relate_Info_Role GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Relate_Info_Role> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Relate_Info_Role obj)
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

        public int RelateRoleToUser(List<User_Relate_Info_Role> list)
        {
            for(int i=0;i< list.Count;i++)
            {
                DbSet.Add(list[i]);
            }
        
            return SaveChanges();
        }

        public int RelateRoleToUserDel(List<int> list)
        {
            
            for (int i = 0; i < list.Count; i++)
            {
               var temp= DbSet.Single(a => a.Id == list[i]);
                DbSet.Remove(temp);
            }
 
            return SaveChanges();
        }
        /// <summary>
        /// 根据用户查角色
        /// </summary>
        /// <param name="roleByUserSearchViewModel"></param>
        /// <returns></returns>
        public List<User_Relate_Info_Role> SearchRoleInfoByWhere(RoleByUserSearchViewModel roleByUserSearchViewModel)
        {
            int SkipNum = roleByUserSearchViewModel.pageViewModel.CurrentPageNum * roleByUserSearchViewModel.pageViewModel.PageSize;
            int userid = roleByUserSearchViewModel.UserId;
       
       
            var queryResult = DbSet.Where(k => k.User_InfoId == userid).Include(p => p.User_Role)
                                .Skip(SkipNum)
                            .Take(roleByUserSearchViewModel.pageViewModel.PageSize)
                            .ToList();
            return queryResult;
         
     
          
        }
        /// <summary>
        /// 根据角色查用户
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        public List<User_Relate_Info_Role> SearchUserInfoByWhere(UserByRoleSearchViewModel userByRoleSearchViewModel)
        {
            int roleid = userByRoleSearchViewModel.RoleId;
            var queryResult = DbSet.Where(k => k.User_RoleId == roleid).Include(p => p.User_Info)
                .ToList();
            return queryResult;
        }
        /// <summary>
        /// 根据用户查角色数量
        /// </summary>
        /// <param name="roleByUserSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<User_Relate_Info_Role> GetRoleByUserAll(RoleByUserSearchViewModel roleByUserSearchViewModel)
        {
            int userid = roleByUserSearchViewModel.UserId;
            var queryResult = DbSet.Where(k => k.User_InfoId == userid).Include(p => p.User_Role);

            return queryResult;
        }
        /// <summary>
        /// 根据角色查用户数量
        /// </summary>
        /// <param name="userByRoleSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<User_Relate_Info_Role> GetUserByRoleAll(UserByRoleSearchViewModel userByRoleSearchViewModel)
        {
            int roleid = userByRoleSearchViewModel.RoleId;
            var queryResult = DbSet.Where(k => k.User_RoleId == roleid).Include(p => p.User_Info) ;
            return queryResult;
        }
    }
}
