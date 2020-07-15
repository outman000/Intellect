using Dto.IRepository.IntellRepair;
using Dtol;
using Dtol.dtol;
using Dtol.EfCoreExtion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.BusViewModel.RequestViewModel.BusUserViewModel;
using ViewModel.PublicViewModel;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Repository.IntellRepair
{
    public class RepairInfoRepository : IRepairInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Repair_Info> DbSet;

        public RepairInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Repair_Info>();
        }

        public virtual void Add(Repair_Info obj)
        {
            DbSet.Add(obj);
        }

        public virtual Repair_Info GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<Repair_Info> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(Repair_Info obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
        //根据条件查询报修
        private Expression<Func<Repair_Info, bool>> SearchRepairIdWhere(int id)
        {
            var predicate = WhereExtension.True<Repair_Info>();//初始化where表达式
            predicate = predicate.And(p => p.id==id);
            predicate = predicate.And(p => p.status == "0");

            return predicate;
        }

        public Repair_Info GetInfoByRepairId(int id)
        {
            Repair_Info repair_Info = DbSet.Single(a=>a.id==id && a.status=="0");
            return repair_Info;

        }

 
        /// <summary>
        /// 根据表单主键id 查询表单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Repair_Info> GetInfoByRepairIdSingle(int id)
        {
            var p=SearchRepairIdWhere(id);

            var repair_Info = DbSet.Where(p).Include(a => a.User_Info).ThenInclude(b => b.User_Depart);

            return repair_Info;
        }

        public int DeleteByRepairIdList(List<int> IdList)
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

        public IQueryable<Repair_Info> SearchInfoByRepairWhere(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            int SkipNum = repairInfoSearchViewModel.pageViewModel.CurrentPageNum * repairInfoSearchViewModel.pageViewModel.PageSize;
            var preciateByRepair = SearchRepairWhere(repairInfoSearchViewModel);
            IQueryable<Repair_Info> repair_Infos = Db.repair_Info.Where(preciateByRepair);

            IQueryable<Repair_Info> SearchResultTemp = repair_Infos.Include(a => a.User_Info)
                        .Include(a => a.User_Depart).OrderBy(o => o.repairsDate)
                        .Skip(SkipNum)
                        .Take(repairInfoSearchViewModel.pageViewModel.PageSize);
            return SearchResultTemp;
        }

        public Repair_Info GetById(int id)
        {
            return DbSet.Find(id);
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
        //查询当前用户下已经结束的流程
        public List<RepairIsEndMiddlecs> GetRepairinfoByUserid(NodeEndSearchViewModel nodeEndSearchViewModel)
        {
            return getIsEndInfo(nodeEndSearchViewModel.pageViewModel, nodeEndSearchViewModel.User_InfoId, nodeEndSearchViewModel.isHandler);
        }


        //查询当前用户下未结束的流程
        public IQueryable<RepairNoEndMiddlecs> GetRepairinfoByUseridNoEnd(NodeEndSearchViewModel nodeEndSearchViewModel)
        {
            int SkipNum = nodeEndSearchViewModel.pageViewModel.CurrentPageNum * nodeEndSearchViewModel.pageViewModel.PageSize;
            int userKey = nodeEndSearchViewModel.User_InfoId;
            string isHandler = nodeEndSearchViewModel.isHandler;
            var IsEndInfoList = getIsEndInfoMiddle(userKey,isHandler);//已经结束的流程
            var repair_Infos_User = DbSet.Where(a => a.User_InfoId == userKey && a.isHandler ==isHandler && a.status=="0");
            var NotEndRepairInfo = from a in repair_Infos_User
                                   where !IsEndInfoList.Any(b => b.RepairInfoId == a.id)
                                   select new RepairNoEndMiddlecs
                                   {
                                       Title = a.RepairsTitle,
                                       RepairInfoId = a.id,
                                       User_InfoId = a.User_InfoId,
                                       repairsDate = a.repairsDate
                                   };

                          NotEndRepairInfo.Skip(SkipNum).OrderBy(o => o.repairsDate).ToList()
                          .Take(nodeEndSearchViewModel.pageViewModel.PageSize)
                          .ToList();
            return NotEndRepairInfo;
        }

        /// <summary>
        /// 查询该用户的当前表单类型的已经结束的表单
        /// </summary>
        /// <param name="pageView"></param>
        /// <param name="userKey"></param>
        /// <param name="isHandler"></param>
        /// <returns></returns>
        public List<RepairIsEndMiddlecs> getIsEndInfo(PageViewModel pageView,int userKey ,string isHandler)
        {
            int SkipNum = pageView.CurrentPageNum * pageView.PageSize;
            var EndRepairInfo = DbSet.Where(a => a.User_InfoId == userKey&& a.isHandler == isHandler && a.status=="0")
                                            .Join(Db.flow_Node, a => a.id, b => b.Repair_InfoId,
            (a, b) => new RepairIsEndMiddlecs
            {
                Title = a.RepairsTitle,
                RepairInfoId = a.id,
                User_InfoId = b.User_InfoId,
                Pre_User_InfoId = b.Pre_User_InfoId,
                repairsDate = a.repairsDate
            }
            ).Where(w => w.User_InfoId == null && w.Pre_User_InfoId != null).OrderBy(o => o.repairsDate).ToList()
              .Skip(SkipNum)
              .Take(pageView.PageSize).ToList();
            return EndRepairInfo;
        }

        /// <summary>
        /// 查询该用户当前表单类型未结束的表单，中间方法（内部使用）
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="isHandler"></param>
        /// <returns></returns>
        private List<RepairIsEndMiddlecs> getIsEndInfoMiddle(int userKey, string isHandler)
        {

            var EndRepairInfo = DbSet.Where(a => a.User_InfoId == userKey && a.isHandler == isHandler && a.status=="0")
                                            .Join(Db.flow_Node, a => a.id, b => b.Repair_InfoId,
            (a, b) => new RepairIsEndMiddlecs
            {
                Title = a.RepairsTitle,
                RepairInfoId = a.id,
                User_InfoId = b.User_InfoId,
                Pre_User_InfoId = b.Pre_User_InfoId,
                repairsDate = a.repairsDate
            }
            ).Where(w => w.User_InfoId == null && w.Pre_User_InfoId != null)
             .OrderBy(o => o.repairsDate).ToList();
            return EndRepairInfo;
        }
        //根据条件查询报修
        private Expression<Func<Repair_Info, bool>> SearchRepairWhere(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            var predicate = WhereExtension.True<Repair_Info>();//初始化where表达式
            predicate = predicate.And(p => p.User_Info.UserName.Contains(repairInfoSearchViewModel.UserName));
            predicate = predicate.And(p => p.User_Depart.Name.Contains(repairInfoSearchViewModel.Name));
            predicate = predicate.And(p => p.RepairsTitle.Contains(repairInfoSearchViewModel.RepairsTitle));
            predicate = predicate.And(p => p.RepairsType.Contains(repairInfoSearchViewModel.RepairsType));
            predicate = predicate.And(p => p.status.Contains(repairInfoSearchViewModel.status));
            return predicate;
        }

        public IQueryable<Repair_Info> GetInfoByRepairAll(RepairInfoSearchViewModel repairInfoSearchViewMode)
        {
            var predicate = SearchRepairWhere(repairInfoSearchViewMode);

            return DbSet.Where(predicate);
        }

      
    }
}
