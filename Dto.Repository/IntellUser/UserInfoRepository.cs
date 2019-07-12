
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
    public class UserInfoRepository : IUserInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Info> DbSet;

        public UserInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Info>();
        }

        public virtual void Add(User_Info obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Info> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Info obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int DeleteByUseridList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
               var model= DbSet.Single(w => w.Id == IdList[i]);
                model.status = "1";
                DbSet.Update(model);
                SaveChanges();
                DeleteRowNum = i+1;
            }
            return DeleteRowNum;
        

        }


        public IQueryable<User_Info> GetInfoByUserid(string userid)
        {
            IQueryable<User_Info> user_Infos = DbSet.Where(uid => uid.UserId.Equals(userid));
            return user_Infos;
        }


        //根据条件查询

        public List<User_Info> SearchInfoByWhere(UserSearchViewModel userSearchViewModel)
        {
            //查询条件
            var predicate = SearchUserWhere(userSearchViewModel);
            return DbSet.Where(predicate).OrderBy(o => o.AddDate).ToList();
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

        #region 查询条件
        //根据调价查询用户
        private Expression<Func<User_Info, bool>> SearchUserWhere(UserSearchViewModel userSearchViewModel)
        {
            var predicate = WhereExtension.True<User_Info>();//初始化where表达式
                predicate = predicate.And(p => p.UserId.Contains(userSearchViewModel.UserId));
                predicate = predicate.And(p => p.UserName.Contains(userSearchViewModel.UserName));
                predicate = predicate.And(p => p.Levels.Contains(userSearchViewModel.Levels));
                predicate = predicate.And(p => p.status.Contains(userSearchViewModel.status));
            return predicate;
        }


        #endregion


    }
}
