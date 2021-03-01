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
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.Repository.IntellUser
{
    public class DataBaseTypeRepository : IDataBaseTypeRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<DataBase_Type> DbSet;

        public DataBaseTypeRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<DataBase_Type>();


        }
        public virtual void Add(DataBase_Type obj)
        {

            DbSet.Add(obj);
        }

        public int AddByNum(DataBase_Type obj)
        {
            int mex = 0;
            var model = DbSet.Where(a => a.Name.ToString() == obj.Name).ToList();
            if (model.Count <= 0)
            {
                DbSet.Add(obj);
            }
            else
            {
                mex = -1;
            }
            return mex;
        }


        public List<int> DeleteByDataBaseidList(List<string> IdList)
        {
            List<int> num = new List<int>();
            int DeleteFNum = 0;//删除失败数
            int DeleteRowNum = 0;//删除成功数
            for (int i = 0; i < IdList.Count; i++)
            {

                var model = DbSet.Where(w => w.Id.ToString() == IdList[i] && w.Status == "0").ToList();
                if (model.Count > 0)
                {
                    model[0].IsDelete = "1";
                    DbSet.Update(model[0]);
                    SaveChanges();
                    DeleteRowNum++;

                }
                else
                {
                    DeleteFNum += 1;
                }
            }
            num.Add(DeleteFNum);
            num.Add(DeleteRowNum);
            return num;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<DataBase_Type> GetAll()
        {
            return DbSet;
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public DataBase_Type GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Update(DataBase_Type obj)
        {
            DbSet.Update(obj);
        }

        /// <summary>
        /// 所有楼
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<DataBase_Type> SearchFloor()
        {
            var result = DbSet.Where(f => f.TypeCode == "0" && f.IsDelete == "0").OrderByDescending(f => f.Sort).ToList();

            return result;
        }
        /// <summary>
        /// 根据楼id查区
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<DataBase_Type> SearchAreaByFloor(string id)
        {
            var result = DbSet.Where(f => f.Parentid == id && f.TypeCode == "1" && f.IsDelete == "0").OrderByDescending(f => f.Sort).ToList();

            return result;
        }

        /// <summary>
        /// 根据区id查楼
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<DataBase_Type> SearchFloorByArea(string id)
        {
            var result1 = DbSet.Where(f => f.Id.ToString() == id && f.IsDelete == "0").OrderByDescending(f => f.Sort).ToList();
            var result = DbSet.Where(f => f.Id.ToString() == result1[0].Parentid && f.IsDelete == "0").OrderByDescending(f => f.Sort).ToList();

            return result;
        }

        public List<DataBase_Type> SearchAreaByFloorNum(string id)
        {

            var result = DbSet.Where(f => f.Parentid == id && f.TypeCode == "1" && f.IsDelete == "0").OrderByDescending(f => f.Sort).ToList();

            return result;
        }
        /// <summary>
        /// 基础类型信息查询
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        public List<DataBase_Type> SearchDataBaseWhere(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {
            var predicate = SearchDataBaseinfo(dataBaseTypeSearchViewModel);

            var result = DbSet.Where(predicate).OrderByDescending(a => a.CreateDate).ToList();

            return result;
        }

        public List<DataBase_Type> SearchDataBaseNum(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {

            var predicate = SearchDataBaseinfo(dataBaseTypeSearchViewModel);
            var result = DbSet.Where(predicate).ToList();
            return result;
        }
        #region 条件


        //根据条件查询会议室信息
        private Expression<Func<DataBase_Type, bool>> SearchDataBaseinfo(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {
            var predicate = WhereExtension.True<DataBase_Type>();//初始化where表达式

            predicate = predicate.And(a => a.IsDelete == "0");

            predicate = predicate.And(a => a.Id.ToString().Contains(dataBaseTypeSearchViewModel.Id.ToString()));

            predicate = predicate.And(a => a.Name.Contains(dataBaseTypeSearchViewModel.Name));

            predicate = predicate.And(a => a.TypeName.Contains(dataBaseTypeSearchViewModel.TypeName));

            predicate = predicate.And(a => a.Purview.Contains(dataBaseTypeSearchViewModel.Purview));

            return predicate;
        }
        #endregion
        //根据主键id查询
        public DataBase_Type GetInfoByDataBaseid(string id)
        {
            DataBase_Type database_Type = DbSet.Single(uid => uid.Id.Equals(id));
            return database_Type;
        }

    }
}
