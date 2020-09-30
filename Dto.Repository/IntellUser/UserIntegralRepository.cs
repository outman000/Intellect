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
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Repository.IntellUser
{
    public class UserIntegralRepository : IUserIntegralRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Integral_Log> DbSet;
        protected readonly DbSet<User_Integral> DbSet2;
        protected readonly DbSet<User_Info> DbSet3;

        public UserIntegralRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Integral_Log>();
            DbSet2 = Db.Set<User_Integral>();
            DbSet3 = Db.Set<User_Info>();
        }

        public virtual void Add(User_Integral_Log obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Add_User_Integral(User_Integral obj)
        {
            DbSet2.Add(obj);
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<User_Integral_Log> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual User_Integral_Log GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        /// <summary>
        /// 根据用户主键ID查询用户积分
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<User_Integral> SearchUserIntegralByUserId(string id)
        {
            return DbSet2.Where(a => a.createUser == id && a.IsDelete == "0").ToList();
        }
        public List<User_Integral> SearchUserIntegral(string idcard)
        {
            return DbSet2.Where(a => a.Idcard == idcard && a.IsDelete=="0").ToList();
        }
        public List<User_Integral_Log> SearchUserIntegral2(string idcard)
        {
            return DbSet.Where(a => a.Idcard == idcard && a.IsDelete == "0" && a.status =="0").OrderByDescending(a=>a.AddDate).ToList();
        }
        public virtual void Update(User_Integral_Log obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Update_User_Integral(User_Integral obj)
        {
            DbSet2.Update(obj);
        }


        public List<User_Integral> SearchUserIntegralAll(UserIntegralSearchViewModel  userIntegralSearchViewModel)
        {

            int SkipNum = userIntegralSearchViewModel.pageViewModel.CurrentPageNum * userIntegralSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchUserIntegralWhere(userIntegralSearchViewModel);

            var result = DbSet2.Where(predicate).OrderByDescending(o => o.AddDate)
                .Skip(SkipNum)
                .Take(userIntegralSearchViewModel.pageViewModel.PageSize)
                .ToList();


            return result;
        }
        public List<User_Integral> SearchUserIntegralAllNum(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            var predicate = SearchUserIntegralWhere(userIntegralSearchViewModel);
            var result = DbSet2.Where(predicate).OrderBy(o => o.AddDate) .ToList();

            return result;
        }

        //根据条件查询用户
        private Expression<Func<User_Integral, bool>> SearchUserIntegralWhere(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            var predicate = WhereExtension.True<User_Integral>();//初始化where表达式
            if(userIntegralSearchViewModel.User_DepartId != null)
            predicate = predicate.And(p => p.User_DepartId == userIntegralSearchViewModel.User_DepartId.Value);
            predicate = predicate.And(p => p.UserName.Contains(userIntegralSearchViewModel.UserName));
            predicate = predicate.And(p => p.TotalPoints.Contains(userIntegralSearchViewModel.TotalPoints));
            
            predicate = predicate.And(p => p.Mobile.Contains(userIntegralSearchViewModel.Mobile));
            if(userIntegralSearchViewModel.strDate!=null && userIntegralSearchViewModel.endDate!=null)
            predicate = predicate.And(p => p.updateDate.Value >= userIntegralSearchViewModel.strDate.Value  &&  p.updateDate.Value<= userIntegralSearchViewModel.endDate.Value);
            return predicate;
        }
        /// <summary>
        /// 查询积分信息（积分表和用户表联查）
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>
        public List<UserIntegralSearchMiddle> SearchUserIntegralNewAll(UserIntegralSearchViewModel userIntegralSearchViewModel)
        {
            string deptId = "";
            string User_UnionId = "";
            DateTime strDate;
            DateTime endDate;
            int SkipNum = userIntegralSearchViewModel.pageViewModel.CurrentPageNum * userIntegralSearchViewModel.pageViewModel.PageSize;
            if (userIntegralSearchViewModel.User_DepartId != null)
            {
                 deptId = userIntegralSearchViewModel.User_DepartId.Value.ToString();
            }
            if (userIntegralSearchViewModel.User_UnionId != null)
            {
                User_UnionId = userIntegralSearchViewModel.User_UnionId.Value.ToString();
            }
            string TotalPoints = userIntegralSearchViewModel.TotalPoints;
            string username= userIntegralSearchViewModel.UserName;
            string Mobile = userIntegralSearchViewModel.Mobile;
            if (userIntegralSearchViewModel.strDate != null && userIntegralSearchViewModel.endDate != null)
            {
                 strDate = userIntegralSearchViewModel.strDate.Value;
                 endDate = userIntegralSearchViewModel.endDate.Value;
                    var result = DbSet2.Where(a => a.User_DepartId.ToString().Contains(deptId)&& a.TotalPoints.Contains(TotalPoints) && a.UserName.Contains(username)
                    && a.Mobile.Contains(Mobile) && a.updateDate>= strDate &&a.updateDate <= endDate).Join(DbSet3.Where(D=>D.User_UnionId.ToString().Contains(User_UnionId))
                    .Include(c=>c.User_Depart).Include(f=>f.User_Union), a => a.Idcard, D => D.Idcard, (a, D) => new UserIntegralSearchMiddle
                    {
                        UserName = a.UserName,
                        Idcard=a.Idcard,
                        Dept=D.User_Depart.Name,
                        Type=a.Type,
                        TotalPoints=a.TotalPoints,
                        Mobile=a.Mobile,
                        UnionName=D.User_Union.Name,
                        updateDate = a.updateDate
                    }).OrderByDescending(a=>a.TotalPoints)
                     .Skip(SkipNum)
                     .Take(userIntegralSearchViewModel.pageViewModel.PageSize).ToList();
                return result;
            }
            else
            {
                var result = DbSet2.Where(a => a.User_DepartId.ToString().Contains(deptId) && a.TotalPoints.Contains(TotalPoints) && a.UserName.Contains(username)
                    && a.Mobile.Contains(Mobile) ).Join(DbSet3.Where(D => D.User_UnionId.ToString().Contains(User_UnionId)).Include(c => c.User_Depart).
                    Include(f => f.User_Union), a => a.Idcard, D => D.Idcard, (a, D) =>new UserIntegralSearchMiddle
                    {
                        UserName = a.UserName,
                        Idcard = a.Idcard,
                        Dept = D.User_Depart.Name,
                        Type = a.Type,
                        TotalPoints = a.TotalPoints,
                        Mobile = a.Mobile,
                        UnionName = D.User_Union.Name,
                        updateDate = a.updateDate
                    }).OrderByDescending(a => a.TotalPoints)
                       .Skip(SkipNum)
                       .Take(userIntegralSearchViewModel.pageViewModel.PageSize).ToList();
                return result;
            }

           
        }


    }
}
