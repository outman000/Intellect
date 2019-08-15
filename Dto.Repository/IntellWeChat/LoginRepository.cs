using Dto.IRepository.IntellWeChat;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="weChatLoginViewModel"></param>
        /// <returns></returns>
        public User_Info ValideUserInfo(WeChatLoginViewModel weChatLoginViewModel)
        {
            var preciate = SearchUserWhere(weChatLoginViewModel);
            User_Info SearchResultTemp = DbSet
                                        .Where(preciate)
                                        .FirstOrDefault();
            return SearchResultTemp;
        }

        /// <summary>
        /// 根据用户信息获取所有相关信息（权限，部门，角色）
        /// </summary>
        /// <param name="user_Info"></param>
        /// <returns></returns>
        public List<User_Relate_Info_Role> SearchInfoByWhere(int  id)
        {
                var userAllInfo = Db.user_Relate_Info_Role
                                            .Where(a => a.User_InfoId == id)
                                            .Include(b => b.User_Role)
                                            .ThenInclude(c => c.User_Relate_Role_Right)
                                            .ThenInclude(
                                              d => d.User_Rights
                                            ).ToList()
                                            ;
                return userAllInfo;
        }

     




        #region 查询条件
        //根据条件查询用户
        private Expression<Func<User_Info, bool>> SearchUserWhere(WeChatLoginViewModel weChatLoginViewModel)
        {
            var predicate = WhereExtension.True<User_Info>();//初始化where表达式
            predicate = predicate.And(p => p.UserId.Contains(weChatLoginViewModel.UserId));
            predicate = predicate.And(p => p.UserPwd.Contains(weChatLoginViewModel.UserPwd));
            predicate = predicate.And(p => p.status=="0");
            return predicate;
        }

        public void Add(WeChatIndexMiddlecs obj)
        {
            throw new NotImplementedException();
        }

       

        public void Update(WeChatIndexMiddlecs obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
