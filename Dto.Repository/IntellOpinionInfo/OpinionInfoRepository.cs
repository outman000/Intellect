using Dto.IRepository.IntellOpinionInfo;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.OpinionInfoViewModel.RequestViewModel;

namespace Dto.Repository.IntellOpinionInfo
{
    public class OpinionInfoRepository : IOpinionInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Opinion_Info> DbSet;

        public OpinionInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Opinion_Info>();
        }

        public void Add(Opinion_Info obj)
        {
            DbSet.Add(obj);
        }

        public Opinion_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<Opinion_Info> GetAll()
        {
            return DbSet;
        }

        public void Update(Opinion_Info obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
          /// <summary>
          /// 批量删除领导回复意见
          /// </summary>
          /// <param name="IdList"></param>
          /// <returns></returns>
            public int DeleteByOpinionInfoIdList(List<int> IdList)
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

        public Opinion_Info GetInfoByOpinionId(int id)
        {
            Opinion_Info opinion_Info = DbSet.Single(uid => uid.id.Equals(id));
            return opinion_Info;
        }

        IQueryable<Opinion_Info> IRepository<Opinion_Info>.GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据条件查询领导意见
        /// </summary>
        /// <param name="opinionInfoSearchViewModel"></param>
        /// <returns></returns>
        public IQueryable<Opinion_Info> SearchOpinionInfoByWhere(OpinionInfoSearchViewModel opinionInfoSearchViewModel)
        {
            int SkipNum = opinionInfoSearchViewModel.pageViewModel.CurrentPageNum * opinionInfoSearchViewModel.pageViewModel.PageSize;
            var preciateByopinionInfo = SearchOpinionInfoWhere(opinionInfoSearchViewModel);
            IQueryable<Opinion_Info> OpinionInfo = Db.opinion_Infos.Where(preciateByopinionInfo);

            IQueryable<Opinion_Info> SearchResultTemp = OpinionInfo.Include(a => a.User_Info)
                        .Include(a => a.Flow_NodeDefine)
                        .Skip(SkipNum)
                        .Take(opinionInfoSearchViewModel.pageViewModel.PageSize).OrderBy(o => o.AddDate);
            return SearchResultTemp;
        }

        //根据条件查询领导意见
        private Expression<Func<Opinion_Info, bool>> SearchOpinionInfoWhere(OpinionInfoSearchViewModel opinionInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Opinion_Info>();//初始化where表达式
            predicate = predicate.And(p => p.User_Info.UserName.Contains(opinionInfoSearchViewModel.UserName));
            if(opinionInfoSearchViewModel.Repair_InfoId != null)
            predicate = predicate.And(p => p.Repair_InfoId == opinionInfoSearchViewModel.Repair_InfoId.Value);
            predicate = predicate.And(p => p.Flow_NodeDefine.NodeName.Contains(opinionInfoSearchViewModel.NodeName));
            predicate = predicate.And(p => p.status.Contains(opinionInfoSearchViewModel.status));
            predicate = predicate.And(p => p.AddDate.ToString().Contains(opinionInfoSearchViewModel.AddDate.ToString()));
            return predicate;
        }

        public IQueryable<Opinion_Info> GetOpinionInfoAll(OpinionInfoSearchViewModel opinionInfoSearchViewModel)
        {
            var predicate = SearchOpinionInfoWhere(opinionInfoSearchViewModel);

            return DbSet.Where(predicate);
        }

        public List<Opinion_Info> GetInfoByRepair_InfoId(int id)
        {
            if(DbSet.Where(uid => uid.Repair_InfoId == id).ToList().Count>0)
            {
                List<Opinion_Info> opinion_Info = DbSet.Where(uid => uid.Repair_InfoId == id).Include(a=>a.User_Info).Include(a=>a.Flow_NodeDefine).
                                                       OrderByDescending(a => a.AddDate).ToList();
                return opinion_Info;
            }
            else
            return null;
        }
    }
}
