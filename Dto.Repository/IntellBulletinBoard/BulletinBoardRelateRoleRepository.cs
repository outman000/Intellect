using Dto.IRepository.IntellBulletinBoard;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.BulletinBoardViewModel.RequestViewModel;

namespace Dto.Repository.IntellBulletinBoard
{
    public class BulletinBoardRelateRoleRepository : IBulletinBoardRelateRoleRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Bulletin_Board_Relate_Role> DbSet;

        public BulletinBoardRelateRoleRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bulletin_Board_Relate_Role>();
        }
        public void Add(Bulletin_Board_Relate_Role obj)
        {
            DbSet.Add(obj);
        }

        public Bulletin_Board_Relate_Role GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<Bulletin_Board_Relate_Role> GetAll()
        {
            return DbSet;
        }

        public void Update(Bulletin_Board_Relate_Role obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int DeleteByFoodInfoIdList(List<int> IdList)
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

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }



        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 根据公告栏查询角色
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        public List<Bulletin_Board_Relate_Role> SearchRoleInfoByWhere(RoleByBulletinSearchViewModel roleByBulletinSearchViewModel)
        {

            int SkipNum = roleByBulletinSearchViewModel.pageViewModel.CurrentPageNum * roleByBulletinSearchViewModel.pageViewModel.PageSize;
            int bulletinId = roleByBulletinSearchViewModel.Bulletin_BoardId;
            var queryResult = DbSet.Where(k => k.Bulletin_BoardId == bulletinId).Include(p => p.User_Role)
                 .Skip(SkipNum)
                .Take(roleByBulletinSearchViewModel.pageViewModel.PageSize)
                 .OrderBy(o => o.Id)
                .ToList();
            return queryResult;
        }

        /// <summary>
        /// 根据公告查角色数量
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bulletin_Board_Relate_Role> GetRoleByBulletinAll(RoleByBulletinSearchViewModel roleByBulletinSearchViewModel)
        {
            int bulletinId = roleByBulletinSearchViewModel.Bulletin_BoardId;
            var queryResult = DbSet.Where(k => k.Bulletin_BoardId == bulletinId).Include(p => p.User_Role);

            return queryResult;
        }

        /// <summary>
        /// 根据公告栏添加角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int RelateBulletinToRole(List<Bulletin_Board_Relate_Role> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DbSet.Add(list[i]);
            }

            return SaveChanges();
        }
        /// <summary>
        /// 根据公告栏删除角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int RelateBulletinToRoleDel(List<RelateRoleBulletinDelMiddlecs> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var preciate = SearchDelRelateWhere(list[i]);
                var temp = DbSet.Single(preciate);
                DbSet.Remove(temp);
            }

            return SaveChanges();
        }
        #region 查询条件
        //根据条件查询角色和公告关联关系
        private Expression<Func<Bulletin_Board_Relate_Role, bool>> SearchDelRelateWhere(RelateRoleBulletinDelMiddlecs  relateRoleBulletinDelMiddlecs)
        {
            var predicate = WhereExtension.True<Bulletin_Board_Relate_Role>();//初始化where表达式
            predicate = predicate.And(p => p.Bulletin_BoardId == relateRoleBulletinDelMiddlecs.Bulletin_BoardId);
            predicate = predicate.And(p => p.User_RoleId == relateRoleBulletinDelMiddlecs.User_RoleId);
            return predicate;
        }
        #endregion


        /// <summary>
        /// 根据用户信息获取所有相关信息（公告栏，角色）
        /// </summary>
        /// <param name="user_Info"></param>
        /// <returns></returns>
        public List<User_Relate_Info_Role> SearchInfoByWhere(int id)
        {
            var userAllInfo = Db.user_Relate_Info_Role
                                        .Where(a => a.User_InfoId == id)
                                        .Include(b => b.User_Role)
                                        .ThenInclude(c => c.Bulletin_Board_Relate_Role)
                                        .ThenInclude(
                                              d => d.Bulletin_Board
                                            ).ToList();
            return userAllInfo;
        }
    }
}
