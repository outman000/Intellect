using Dto.IRepository.IntellWeChat;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.Repository.IntellWeChat
{
    public  class UserBindRepository : IUserBindRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<UserBind> DbSet;

        public UserBindRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<UserBind>();

        }

        public virtual void Add(UserBind obj)
        {
            DbSet.Add(obj);
        }
        public UserBind GetInfoByDepartid(int id)
        {
            UserBind user_depart = DbSet.Single(uid => uid.ID.Equals(id));
            return user_depart;
        }


        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<UserBind> GetAll()
        {
            return DbSet;
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public UserBind GetById(Guid id)
        {
            return DbSet.Find(id);
        }

  


        public void Update(UserBind obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<UserBind> GetoUserBindStr(string openid)
        {
            List<UserBind> user_Bind = DbSet.Where(uid => uid.OpenId  == openid).ToList();
            return user_Bind;
        }

        public List<UserBind> GetoUserBindStr2(string userid)
        {
            List<UserBind> user_Bind = DbSet.Where(uid => uid.userId == userid).ToList();
            return user_Bind;
        }
    }
}
