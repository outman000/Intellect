
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
    public class UserRightsRepository: IUserRightsRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Rights> DbSet;

        public UserRightsRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Rights>();
        }

        public virtual void Add(User_Rights obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Rights GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Rights> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Rights obj)
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
        public User_Rights GetInfoByRightId(int id)
        {
            User_Rights user_right = DbSet.Single(uid => uid.Id.Equals(id));
            return user_right;

        }
        public IQueryable<User_Rights> GetRightsByValue(string RightsValue)
        {
            IQueryable<User_Rights> user_Rights = DbSet.Where(uid => uid.RightsValue.Equals(RightsValue));
            return user_Rights;
        }
        //批量删除
        public int DeleteByRightsidList(List<int> IdList)
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

        public List<User_Rights> SearchRightsByWhere(RightsSearchViewModel rightsSearchViewModel)
        {
            //查询条件
            int SkipNum = rightsSearchViewModel.pageViewModel.CurrentPageNum * rightsSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchRightsWhere(rightsSearchViewModel);
            var result = DbSet.Where(predicate).OrderBy(o => o.Sort)
                .Skip(SkipNum)
                .Take(rightsSearchViewModel.pageViewModel.PageSize)
                .ToList();
            
            return result;
        }
        //根据条件查询权限
        private Expression<Func<User_Rights, bool>> SearchRightsWhere(RightsSearchViewModel rightsSearchViewModel)
        {
            var predicate = WhereExtension.True<User_Rights>();//初始化where表达式
            predicate = predicate.And(p => p.RightsName.Contains(rightsSearchViewModel.RightsName));
            predicate = predicate.And(p => p.RightsValue.Contains(rightsSearchViewModel.RightsValue));
            predicate = predicate.And(p => p.ParentId.Contains(rightsSearchViewModel.ParentId));
            predicate = predicate.And(p => p.Type.Contains(rightsSearchViewModel.Type));
            return predicate;
        }

        public IQueryable<User_Rights> GetRightsAll(RightsSearchViewModel rightsSearchViewModel)
        {
            var predicate = SearchRightsWhere(rightsSearchViewModel);

            return DbSet.Where(predicate);
        }
    }
}
