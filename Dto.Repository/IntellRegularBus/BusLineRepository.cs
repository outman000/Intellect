using Dto.IRepository.IntellRegularBus;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.Repository.IntellRegularBus
{
    public class BusLineRepository : IBusLineRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<Bus_Line> DbSet;

        public BusLineRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Bus_Line>();
        }

        public void Add(Bus_Line obj)
        {
            DbSet.Add(obj);
        }
        /// <summary>
        /// 根据id列表删
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public int DeleteByLineIdList(List<int> IdList)
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

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Bus_Line> GetAll()
        {
            return DbSet;
        }

        public Bus_Line GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<Bus_Line> GetInfoByLineid(string lineid)
        {
            IQueryable<Bus_Line> line_Infos = DbSet.Where(uid => uid.Code.Equals(lineid));
            return line_Infos;
        }

        public Bus_Line GetInfoByLineId(int id)
        {

            Bus_Line line_Info = DbSet.Single(uid => uid.Id.Equals(id));
            return line_Info;
        }

        public IQueryable<Bus_Line> GetLineAll(LineSearchViewModel lineSearchViewModel)
        {
            var predicate = SearchLineWhere(lineSearchViewModel);

            return DbSet.Where(predicate);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public List<Bus_Line> SearchInfoByLineWhere(LineSearchViewModel lineSearchViewModel)
        {
            int SkipNum = lineSearchViewModel.pageViewModel.CurrentPageNum * lineSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchLineWhere(lineSearchViewModel);
            var result = DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(lineSearchViewModel.pageViewModel.PageSize)
                 .OrderBy(o => o.AddDate).ToList();


            return result;
        }
    

        public void Update(Bus_Line obj)
        {
            DbSet.Update(obj);
        }
        //根据条件查询班车
        private Expression<Func<Bus_Line, bool>> SearchLineWhere(LineSearchViewModel lineSearchViewModel)
        {
            var predicate = WhereExtension.True<Bus_Line>();//初始化where表达式
            predicate = predicate.And(p => p.Code.Contains(lineSearchViewModel.Code));
            predicate = predicate.And(p => p.LineName.Contains(lineSearchViewModel.LineName));
            predicate = predicate.And(p => p.status.Contains(lineSearchViewModel.status));
           // predicate = predicate.And(p => p.Id==lineSearchViewModel.Id);

            return predicate;
        }

     
     
    }
}
