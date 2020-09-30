using Dto.IRepository.IntellUser;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Repository.IntellUser
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Register> DbSet;

        public UserRegisterRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Register>();
        }

        public virtual void Add(User_Register obj)
        {
            DbSet.Add(obj);
        }
        public virtual User_Register GetById(Guid id)
        {
            return DbSet.Find(id);
        }



        public virtual void Update(User_Register obj)
        {
            DbSet.Update(obj);
        }


       
        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

     
        public List<User_Register> SearchById(int Id)
        {
            return DbSet.Where(a => a.Id == Id).ToList();
        }
        public List<User_Register> SearchUserRegister(UserRegisterSearchViewModel userRegisterSearchViewModel)
        {
            int SkipNum = userRegisterSearchViewModel.pageViewModel.CurrentPageNum * userRegisterSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchRegisterWhere(userRegisterSearchViewModel);

            var result = DbSet.Where(predicate).OrderByDescending(o => o.AddDate)
                .Skip(SkipNum)
                .Take(userRegisterSearchViewModel.pageViewModel.PageSize)
                .ToList();
            return result;
        }
        public List<User_Register> SearchUserRegisterNum(UserRegisterSearchViewModel userRegisterSearchViewModel)
        {
        

            //查询条件
            var predicate = SearchRegisterWhere(userRegisterSearchViewModel);
            var result = DbSet.Where(predicate).OrderByDescending(o => o.AddDate)
                .ToList();
            return result;
        }


        //根据条件查询用户
        private Expression<Func<User_Register, bool>> SearchRegisterWhere(UserRegisterSearchViewModel userRegisterSearchViewModel)
        {
            var predicate = WhereExtension.True<User_Register>();//初始化where表达式
            predicate = predicate.And(p => p.status.Contains(userRegisterSearchViewModel.status));
            if (userRegisterSearchViewModel.strDate != null && userRegisterSearchViewModel.endDate != null)
                predicate = predicate.And(p => p.AddDate.Value >= userRegisterSearchViewModel.strDate.Value && p.AddDate.Value <= userRegisterSearchViewModel.endDate.Value);

            return predicate;
        }

        public IQueryable<User_Register> GetAll()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
           return Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
