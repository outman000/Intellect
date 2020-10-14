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
        protected readonly DbSet<Integral_Commodity> DbSet4;
        protected readonly DbSet<Commodity_Attachs> DbSet5;
        protected readonly DbSet<Product_List> DbSet6;
        
        public UserIntegralRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Integral_Log>();
            DbSet2 = Db.Set<User_Integral>();
            DbSet3 = Db.Set<User_Info>();
            DbSet4 = Db.Set<Integral_Commodity>();
            DbSet5 = Db.Set<Commodity_Attachs>();
            DbSet6 = Db.Set<Product_List>();
        }
        public virtual void Update_Integral_Commodity(Integral_Commodity obj)
        {
            DbSet4.Update(obj);
        }
        public virtual void Update_Commodity_Attachs(Commodity_Attachs obj)
        {
            DbSet5.Update(obj);
        }
        public virtual void Add(User_Integral_Log obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Add_Product_List(Product_List obj)
        {
            DbSet6.Add(obj);
        }
        public virtual void Add_Commodity_Attachs(Commodity_Attachs obj)
        {
            DbSet5.Add(obj);
        }
        public virtual void Add_User_Integral(User_Integral obj)
        {
            DbSet2.Add(obj);
        }


        public virtual void Add_Integral_Commodity(Integral_Commodity obj)
        {
            DbSet4.Add(obj);
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
        /// 删除商品信息
        /// </summary>
        /// <param name="IdList"></param>
        /// <returns></returns>
        public int DeleteByUseridList(List<string> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
                var model = DbSet4.Single(w => w.Id == IdList[i]);
                model.IsDelete = "1";
                DbSet4.Update(model);
                SaveChanges();
                DeleteRowNum = i + 1;
            }
            return DeleteRowNum;


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
        public List<Commodity_Attachs> GetImageList(string formid)
        {
            var result = DbSet5.Where(p => p.formid == formid).OrderByDescending(info => info.createDate).ToList();
            return result;
        }
        /// <summary>
        /// 根据商品主键ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Integral_Commodity> GetIntegralCommodityList(string ID)
        {
            return DbSet4.Where(a => a.Id == ID && a.IsDelete == "0" && a.status=="0").ToList();
        }



        public List<Integral_Commodity> GetIntegral_CommodityList(IntegralCommoditySearchViewModel  integralCommoditySearchViewModel)
        {
            int SkipNum = integralCommoditySearchViewModel.pageViewModel.CurrentPageNum * integralCommoditySearchViewModel.pageViewModel.PageSize;
            var predicate = SearchIntegralCommodityWhere(integralCommoditySearchViewModel);
            var result = DbSet4.Where(predicate).OrderByDescending(A=>A.AddDate)
                                .Skip(SkipNum)
                                .Take(integralCommoditySearchViewModel.pageViewModel.PageSize).ToList();
            return result;
        }

        public List<Product_List> GetProductListList(ProductListSearchViewModel  productListSearchViewModel)
        {
            int SkipNum = productListSearchViewModel.pageViewModel.CurrentPageNum * productListSearchViewModel.pageViewModel.PageSize;
            var predicate = SearchProductListWhere(productListSearchViewModel);
            var result = DbSet6.Where(predicate).OrderByDescending(A => A.AddDate)
                                .Skip(SkipNum)
                                .Take(productListSearchViewModel.pageViewModel.PageSize).ToList();
            return result;
        }
        /// <summary>
        /// 根据用户主键ID查询兑换清单
        /// </summary>
        /// <param name="productListSearchByUserIdViewModel"></param>
        /// <returns></returns>
        public List<Product_List> GetProductListListByUserId(string userid)
        {
           
            var result = DbSet6.Where(a=>a.userid == userid).OrderByDescending(A => A.AddDate).ToList();
            return result;
        }


        public int GetProductListNum(ProductListSearchViewModel productListSearchViewModel)
        {
            var predicate = SearchProductListWhere(productListSearchViewModel);
            var result = DbSet6.Where(predicate).ToList().Count;
            return result;
        }




        public int GetIntegral_Commodity_Num(IntegralCommoditySearchViewModel integralCommoditySearchViewModel)
        {
         
            var predicate = SearchIntegralCommodityWhere(integralCommoditySearchViewModel);
            var result = DbSet4.Where(predicate)
                              .ToList().Count;
            return result;
        }

        //根据条件查询商品列表
        private Expression<Func<Integral_Commodity, bool>> SearchIntegralCommodityWhere(IntegralCommoditySearchViewModel integralCommoditySearchViewModel)
        {
            var predicate = WhereExtension.True<Integral_Commodity>();//初始化where表达式
            if(integralCommoditySearchViewModel.User_UnionId!=null)
                predicate = predicate.And(p => p.User_UnionId == integralCommoditySearchViewModel.User_UnionId.Value);
            predicate = predicate.And(p => p.CommodityName.Contains(integralCommoditySearchViewModel.CommodityName));
            predicate = predicate.And(p => p.IntegralNum.Contains(integralCommoditySearchViewModel.IntegralNum));
            predicate = predicate.And(p => p.status == integralCommoditySearchViewModel.status);
            predicate = predicate.And(p => p.IsDelete=="0");

            return predicate;
        }

        //根据条件查询商品列表
        private Expression<Func<Product_List, bool>> SearchProductListWhere(ProductListSearchViewModel productListSearchViewModel)
        {
            var predicate = WhereExtension.True<Product_List>();//初始化where表达式
            if (productListSearchViewModel.User_UnionId != null)
                predicate = predicate.And(p => p.User_UnionId == productListSearchViewModel.User_UnionId.Value);
            if (productListSearchViewModel.User_DepartId != null)
                predicate = predicate.And(p => p.User_DepartId == productListSearchViewModel.User_DepartId.Value);
            predicate = predicate.And(p => p.CommodityName.Contains(productListSearchViewModel.CommodityName));
            predicate = predicate.And(p => p.IntegralNum.Contains(productListSearchViewModel.IntegralNum));
            if (productListSearchViewModel.starDate != null && productListSearchViewModel.endDate!=null)
                predicate = predicate.And(p => p.AddDate >= productListSearchViewModel.starDate && p.AddDate <= productListSearchViewModel.endDate);

       
            return predicate;
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
