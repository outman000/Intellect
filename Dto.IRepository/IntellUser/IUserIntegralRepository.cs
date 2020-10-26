using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.IntellUser
{
    public interface IUserIntegralRepository : IRepository<User_Integral_Log>
    {
        List<User_Integral> SearchUserIntegral(string  idcard);
        void Add_User_Integral(User_Integral obj);
        void Add_Integral_Commodity(Integral_Commodity obj);
        void Add_Commodity_Attachs(Commodity_Attachs obj);
        void Add_Product_List(Product_List obj);
        void Update_Integral_Commodity(Integral_Commodity obj);
        void Update_Commodity_Attachs(Commodity_Attachs obj);
        List<Commodity_Attachs> GetImageList(string formid);
        void Update_User_Integral(User_Integral obj);
        int DeleteByUseridList(List<string> IdList);
        List<User_Integral_Log> SearchUserIntegral2(string idcard);

        /// <summary>
        /// 根据用户主键ID查询兑换清单
        /// </summary>
        /// <param name="productListSearchByUserIdViewModel"></param>
        /// <returns></returns>
        List<Product_List> GetProductListListByUserId(string userid);
        List<User_Integral> SearchUserIntegralByUserId(string id);
        /// <summary>
        /// 查询商品列表
        /// </summary>
        /// <param name="integralCommoditySearchViewModel"></param>
        /// <returns></returns>
        List<Integral_Commodity> GetIntegral_CommodityList(IntegralCommoditySearchViewModel integralCommoditySearchViewModel);
        /// <summary>
        /// 查询物品兑换清单
        /// </summary>
        /// <param name="productListSearchViewModel"></param>
        /// <returns></returns>
        List<Product_List> GetProductListList(ProductListSearchViewModel productListSearchViewModel);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="productListSearchViewModel"></param>
        /// <returns></returns>
        int GetProductListNum(ProductListSearchViewModel productListSearchViewModel);
        /// <summary>
        /// 根据商品主键ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        List<Integral_Commodity> GetIntegralCommodityList(string ID);

        /// <summary>
        /// 查询商品列表数量
        /// </summary>
        /// <param name="integralCommoditySearchViewModel"></param>
        /// <returns></returns>
        int GetIntegral_Commodity_Num(IntegralCommoditySearchViewModel integralCommoditySearchViewModel);
        /// <summary>
        /// 根据条件查询用户积分
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>
        List<User_Integral> SearchUserIntegralAll(UserIntegralSearchViewModel userIntegralSearchViewModel);
        /// <summary>
        ///  根据条件查询用户积分数量
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>
        List<User_Integral> SearchUserIntegralAllNum(UserIntegralSearchViewModel userIntegralSearchViewModel);
        /// <summary>
        /// 根据条件查询用户积分(最新)
        /// </summary>
        /// <param name="userIntegralSearchViewModel"></param>
        /// <returns></returns>

        List<User_Integral> SearchUserIntegralNewAll(UserIntegralSearchViewModel userIntegralSearchViewModel);
    }
}
