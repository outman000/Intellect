using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto.IRepository.IntellUser;
using ViewModel.UserViewModel.RequsetModel;
using System.Linq.Expressions;
using Dtol.EfCoreExtion;

namespace Dto.Repository.IntellUser
{
    public class UserRoleRepository: IUserRoleRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Role> DbSet;

        public UserRoleRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Role>();
        }

        public virtual void Add(User_Role obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Role GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Role> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Role obj)
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
        public User_Role GetInfoByRoleid(int id)
        {
            User_Role user_role = DbSet.Single(uid => uid.Id.Equals(id));
            return user_role;
        }
        public IQueryable<User_Role> GetInfoByRoleCode(string roleCode)
        {
            IQueryable<User_Role> user_Infos = DbSet.Where(code => code.RoleCode.Equals(roleCode));
            return user_Infos;
        }

        public int DeleteByRoleIdList(List<int> IdList)
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

        public List<User_Role> SearchRoleInfoByWhere(UserRoleSearchViewModel userRoleSearchViewModel)
        {
            int skipNum = userRoleSearchViewModel.pageViewModel.CurrentPageNum * userRoleSearchViewModel.pageViewModel.PageSize;
            //查询条件
            var predicate = SearchUserRoleWhere(userRoleSearchViewModel);
            return DbSet.Where(predicate).OrderBy(o => o.Createdate)
                  .Skip(skipNum)
                  .Take(userRoleSearchViewModel.pageViewModel.PageSize)
                  .ToList();
        }
        /// <summary>
        /// 获得角色数量
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<User_Role> GetRoleAll(UserRoleSearchViewModel userRoleSearchViewModel)
        {
            var predicate = SearchUserRoleWhere(userRoleSearchViewModel);

            return DbSet.Where(predicate);
        }
        #region 条件
        //用户搜索条件
        private Expression<Func<User_Role, bool>> SearchUserRoleWhere(UserRoleSearchViewModel userRoleSearchViewModel)
        {
            var predicate = WhereExtension.True<User_Role>();//初始化where表达式
            predicate = predicate.And(p => p.RoleName.Contains(userRoleSearchViewModel.RoleName));
            predicate = predicate.And(p => p.Status.Contains(userRoleSearchViewModel.Status));
            predicate = predicate.And(p => p.RoleType.Contains(userRoleSearchViewModel.RoleType));
            return predicate;
        }

     


        #endregion
    }
}
