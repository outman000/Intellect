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
using ViewModel.BulletinBoardViewModel.RequestViewModel;

namespace Dto.Repository.IntellBulletinBoard
{
    public class BulletinBoardRepository : IBulletinBoardRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Bulletin_Board> DbSet;

        public BulletinBoardRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bulletin_Board>();
        }

        public void Add(Bulletin_Board obj)
        {
            DbSet.Add(obj);
        }

        public Bulletin_Board GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<Bulletin_Board> GetAll()
        {
            return DbSet;
        }

        public void Update(Bulletin_Board obj)
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
        /// 查询公告栏信息
        /// </summary>
        /// <param name="bulletinBoardSearchViewModel"></param>
        /// <returns></returns>
        public List<Bulletin_Board> SearchInfoByBulletinWhere(BulletinBoardSearchViewModel bulletinBoardSearchViewModel)
        {
            //查询条件
            int SkipNum = bulletinBoardSearchViewModel.pageViewModel.CurrentPageNum * bulletinBoardSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchBulletinBoardWhere(bulletinBoardSearchViewModel);
            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(bulletinBoardSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.AddDate).ToList();

            return result;
        }
        #region 查询条件
        //根据条件查询公告栏
        private Expression<Func<Bulletin_Board, bool>> SearchBulletinBoardWhere(BulletinBoardSearchViewModel bulletinBoardSearchViewModel)
        {
            var predicate = WhereExtension.True<Bulletin_Board>();//初始化where表达式
            predicate = predicate.And(p => p.BulletinTitle.Contains(bulletinBoardSearchViewModel.BulletinTitle));
            predicate = predicate.And(p => p.StayNum.Contains(bulletinBoardSearchViewModel.StayNum));
            predicate = predicate.And(p => p.UserName.Contains(bulletinBoardSearchViewModel.UserName));
            predicate = predicate.And(p => p.status.Contains(bulletinBoardSearchViewModel.status));
            return predicate;
        }
        #endregion
        /// <summary>
        /// 公告栏数量
        /// </summary>
        /// <param name="bulletinBoardSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Bulletin_Board> GetBulletinBoardAll(BulletinBoardSearchViewModel bulletinBoardSearchViewModel)
        {
            var predicate = SearchBulletinBoardWhere(bulletinBoardSearchViewModel);

            return DbSet.Where(predicate);
        }
        /// <summary>
        /// 公告栏删除
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public int DeleteByBulletinInfoIdList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet.Single(w => w.Id == IdList[i]);
                model.status = "1";
                DbSet.Update(model);
                SaveChanges();
                DeleteRowNum = i + 1;
            }
            return DeleteRowNum;
        }
        /// <summary>
        /// 根据公告栏主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bulletin_Board GetInfoByBulletinId(int id)
        {
            Bulletin_Board bulletin_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return bulletin_Info;
        }
    }
}
