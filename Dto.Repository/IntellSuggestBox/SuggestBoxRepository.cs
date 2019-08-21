using Dto.IRepository.IntellOpinionInfo;
using Dto.IRepository.IntellSuggestBox;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.SuggestBoxViewModel.RequestViewModel;

namespace Dto.Repository.IntellSuggestBox
{
    public class SuggestBoxRepository : ISuggestBoxRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Suggest_Box> DbSet;

        public SuggestBoxRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Suggest_Box>();
        }

        public void Add(Suggest_Box obj)
        {
            DbSet.Add(obj);
        }

        public Suggest_Box GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<Suggest_Box> GetAll()
        {
            return DbSet;
        }

        public void Update(Suggest_Box obj)
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
                var model = DbSet.Single(w => w.id == IdList[i]);
                model.status = "1";
                DbSet.Update(model);
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

        public Suggest_Box GetInfoBySuggestBoxId(int id)
        {
            Suggest_Box suggestBox_Info = DbSet.Single(uid => uid.id.Equals(id));
            return suggestBox_Info;
        }

        IQueryable<Suggest_Box> IRepository<Suggest_Box>.GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询意见
        /// </summary>
        /// <param name="suggestBoxSearchViewModel"></param>
        /// <returns></returns>
        public List<Suggest_Box> SearchSuggestBoxInfoByWhere(SuggestBoxSearchViewModel suggestBoxSearchViewModel)
        {
            //查询条件
            int SkipNum = suggestBoxSearchViewModel.pageViewModel.CurrentPageNum * suggestBoxSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchSggestBoxWhere(suggestBoxSearchViewModel);
            var result = DbSet.Where(predicate).Include(a=>a.User_Info)
                        .ThenInclude(c => c.User_Depart)
                .Skip(SkipNum)
                .Take(suggestBoxSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.SuggestDate).ToList();

            return result;
        }

        #region 查询条件
        //根据条件查询意见箱表单
        private Expression<Func<Suggest_Box, bool>> SearchSggestBoxWhere(SuggestBoxSearchViewModel suggestBoxSearchViewModel)
        {
            var predicate = WhereExtension.True<Suggest_Box>();//初始化where表达式
            predicate = predicate.And(p => p.SuggestDate.ToString().Contains(suggestBoxSearchViewModel.SuggestDate.ToString()));
            predicate = predicate.And(p => p.Content.Contains(suggestBoxSearchViewModel.Content));

            return predicate;
        }
        /// <summary>
        /// 意见箱表单数量
        /// </summary>
        /// <param name="suggestBoxSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Suggest_Box> GeSuggestBoxAll(SuggestBoxSearchViewModel suggestBoxSearchViewModel)
        {
            var predicate = SearchSggestBoxWhere(suggestBoxSearchViewModel);

            return DbSet.Where(predicate);
        }
        #endregion
    }
}
