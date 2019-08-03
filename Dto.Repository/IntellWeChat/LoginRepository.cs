using Dto.IRepository.IntellWeChat;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.WeChatViewModel.MiddleModel;
using ViewModel.WeChatViewModel.RequestViewModel;

namespace Dto.Repository.IntellWeChat
{
    public class LoginRepository : ILoginRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Info> DbSet;

        public LoginRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Info>();

        }

        public virtual void Add(User_Info obj)
        {
            DbSet.Add(obj);
        }
        public User_Info GetInfoByDepartid(int id)
        {
            User_Info user_depart = DbSet.Single(uid => uid.Id.Equals(id));
            return user_depart;
        }
       

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<User_Info> GetAll()
        {
            return DbSet;
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public User_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public List<User_Info> SearchInfoByWeChatWhere(WeChatLoginViewModel weChatLoginViewModel)
        {
            throw new NotImplementedException();
        }



 

        public void Update(User_Info obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User_Info> SearchInfoByWhere(WeChatLoginViewModel weChatLoginViewModel)
        {
         
            var preciate = SearchUserWhere(weChatLoginViewModel);
            IQueryable<User_Info> OpinionInfo = Db.user_Info.Where(preciate);
            IQueryable<User_Info> SearchResultTemp = OpinionInfo.Include(a => a.User_Depart);

            return SearchResultTemp.ToList();

        }
        #region 查询条件
        //根据条件查询用户
        private Expression<Func<User_Info, bool>> SearchUserWhere(WeChatLoginViewModel weChatLoginViewModel)
        {
            var predicate = WhereExtension.True<User_Info>();//初始化where表达式
            predicate = predicate.And(p => p.UserId.Contains(weChatLoginViewModel.UserId));
            predicate = predicate.And(p => p.UserPwd.Contains(weChatLoginViewModel.UserPwd));    
            return predicate;
        }

        public void Add(WeChatLoginMiddlecs obj)
        {
            throw new NotImplementedException();
        }

       

        public void Update(WeChatLoginMiddlecs obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
