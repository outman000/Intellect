﻿
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
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.Repository.IntellUser
{
    public class UserInfoRepository : IUserInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Info> DbSet;
        protected readonly DbSet<ComAttachs> DbSet2;
        protected readonly DbSet<User_Test> DbSet3;
        protected readonly DbSet<User_Register> DbSet4;
        public UserInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Info>();
            DbSet2 = Db.Set<ComAttachs>();
            DbSet3 = Db.Set<User_Test>();
            DbSet4 = Db.Set<User_Register>();
        }

        public virtual void Add(User_Info obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Add2(ComAttachs obj)
        {
            DbSet2.Add(obj);
        }

        public virtual void Add3(User_Register obj)
        {
            DbSet4.Add(obj);
        }
        public virtual User_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public  IQueryable<User_Info> GetUserAll(UserSearchViewModel userSearchViewModel)
        {
            var predicate = SearchUserWhere(userSearchViewModel);

            return DbSet.Where(predicate);
        }

        public virtual void Update(User_Info obj)
        {
            DbSet.Update(obj);
        }
        public  void Update3(User_Test obj)
        {
            DbSet3.Update(obj);
        }

        /// <summary>
        /// 批量导入数据库（推荐目录）
        /// </summary>
        /// <param name="recommendedDirectories"></param>
        public void AddRange_User_Info(List<User_Info>  user_Infos)
        {
            foreach (var a in user_Infos)
            {
                DbSet.Add(a);
            }

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
            IQueryable<User_Info> user_Infos = DbSet.Where(uid => uid.UserId==userid && uid.status=="0");
            return user_Infos;
        }

        public List<User_Info> SearchByIdcard(string Idcard)
        {
            return  DbSet.Where(a => a.Idcard == Idcard && a.status=="0"  ).Include(a=>a.User_Depart).Include(a=>a.User_Union).ToList();
        }
        public List<User_Info> SearchByIdcardNew(string Idcard)
        {
            return DbSet.Where(a => a.Idcard == Idcard && a.status == "0" && (a.User_UnionId != null || a.User_UnionId.ToString() != "")).Include(a => a.User_Depart).ToList();
        }
        public List<User_Test> SearchUser_Test()
        {
            return DbSet3.Where(a => a.UserId!=null).ToList();
        }
        //根据用户主键id查询
        public User_Info GetInfoByUserid(int id)
        {
            User_Info user_Info = DbSet.Single(uid => uid.Id==id && uid.status=="0");
            return user_Info;
        }

        public List<User_Info> CheckIdcard(string Idcard)
        {
            List<User_Info> user_Info = DbSet.Where(uid => uid.Idcard == Idcard && uid.status=="0").ToList();
            return user_Info;
        }
        public User_Info GetPwd(string userid)
        {
            User_Info user_Info = DbSet.Single(uid => uid.UserId.Equals(userid) && uid.status=="0");
            return user_Info;
        }
        public List<User_Info> GetPwdByUserid(string userid)
        {
            List<User_Info> user_Info = DbSet.Where(uid => uid.UserId.Equals(userid) && uid.status == "0").ToList();
            return user_Info;
        }

        //根据条件查询

        public List<User_Info> SearchInfoByWhere(UserSearchViewModel userSearchViewModel)
        {
            int SkipNum = userSearchViewModel.pageViewModel.CurrentPageNum * userSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchUserWhere(userSearchViewModel);
           
            var result= DbSet.Where(predicate).OrderBy(o => o.AddDate)
                .Skip(SkipNum)
                .Take(userSearchViewModel.pageViewModel.PageSize)
                .ToList();
            

            return result;
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
        //根据条件查询用户
        private Expression<Func<User_Info, bool>> SearchUserWhere(UserSearchViewModel userSearchViewModel)
        {
            var predicate = WhereExtension.True<User_Info>();//初始化where表达式
                predicate = predicate.And(p => p.UserId.Contains(userSearchViewModel.UserId));
                predicate = predicate.And(p => p.UserName.Contains(userSearchViewModel.UserName));
                predicate = predicate.And(p => p.Levels.Contains(userSearchViewModel.Levels));
                predicate = predicate.And(p => p.status.Contains(userSearchViewModel.status));
                //predicate = predicate.And(p => p.User_DepartId== userSearchViewModel.User_DepartId);
            return predicate;
        }

        public IQueryable<User_Info> GetAll()
        {
            return DbSet;
        }

        public User_Info GetInfoAndDepartByUserid(int id)
        {
            User_Info user_Info = DbSet.Include(a=>a.User_Depart).Include(a=>a.User_Union)
                                 .Single(uid => uid.Id.Equals(id));
            return user_Info;
        }
        /// <summary>
        /// 根据部门查用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        public List<User_Info> SearchUserInfoByDepartWhere(UserByDepartSearchViewModel userByDepartSearchViewModel)
        {
            int SkipNum = userByDepartSearchViewModel.pageViewModel.CurrentPageNum * userByDepartSearchViewModel.pageViewModel.PageSize;
            int lineid = userByDepartSearchViewModel.User_DepartId;
            string username = userByDepartSearchViewModel.userName;
            var queryResult = DbSet.Where(k => k.User_DepartId == lineid && k.status == "0" && k.UserName.Contains(username))
                     .Skip(SkipNum)
                     .Take(userByDepartSearchViewModel.pageViewModel.PageSize)
                     .ToList();
            return queryResult;
        }
        /// <summary>
        /// 根据部门查用户用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<User_Info> GetUserByDepartAll(UserByDepartSearchViewModel userByDepartSearchViewModel)
        {
            int departId = userByDepartSearchViewModel.User_DepartId;
            string username = userByDepartSearchViewModel.userName;
            var queryResult = DbSet.Where(k => k.User_DepartId == departId && k.status == "0" && k.UserName.Contains(username));
            return queryResult;
        }


        #endregion


    }
}
