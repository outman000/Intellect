using AutoMapper;
using Dto.IRepository.IntellFood;
using Dto.IService.IntellFood;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.FoodViewModel.MiddleModel;
using ViewModel.FoodViewModel.RequestViewModel;

namespace Dto.Service.IntellFood
{
    public class FoodService : IFoodService
    {
        private readonly IFoodInfoRepository _IFoodInfoRepository;
        private readonly IRelate_Food_UserRepository  _IRelate_Food_UserRepository;
        private readonly IMapper _IMapper;

        public FoodService(IFoodInfoRepository  foodInfoRepository, 
                            IRelate_Food_UserRepository relate_Food_UserRepository,
                            IMapper mapper)
        {
            _IFoodInfoRepository = foodInfoRepository;
            _IRelate_Food_UserRepository = relate_Food_UserRepository;
            _IMapper = mapper;
        }
        /// <summary>
        /// 菜单增加
        /// </summary>
        /// <param name="foodInfoAddViewModel"></param>
        /// <returns></returns>
        public int Food_Add(FoodInfoAddViewModel foodInfoAddViewModel)
        {

            var food_Info = _IMapper.Map<FoodInfoAddViewModel, Food_Info>(foodInfoAddViewModel);
            _IFoodInfoRepository.Add(food_Info);
            return _IFoodInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="foodInfoDelViewModel"></param>
        /// <returns></returns>
        public int Food_Delete(FoodInfoDelViewModel foodInfoDelViewModel)
        {

            int DeleteRowsNum = _IFoodInfoRepository
                 .DeleteByFoodInfoIdList(foodInfoDelViewModel.DeleleIdList);
            if (DeleteRowsNum == foodInfoDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取菜单数量
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        public int Food_Get_ALLNum(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {
            return _IFoodInfoRepository.GetFoodAll(foodInfoSearchViewModel).Count();
        }
        /// <summary>
        /// 菜单查询
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<Food_Info> Food_Search(FoodInfoSearchViewModel foodInfoSearchViewModel)
        {

            List<Food_Info> user_Departs = _IFoodInfoRepository.SearchFoodInfoByWhere(foodInfoSearchViewModel);
            return user_Departs;
        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="foodInfoUpdateViewModel"></param>
        /// <returns></returns>
        public int Food_Update(FoodInfoUpdateViewModel foodInfoUpdateViewModel)
        {
            var food_Info = _IFoodInfoRepository.GetInfoByFoodId(foodInfoUpdateViewModel.Id);
            var food_Info_update = _IMapper.Map<FoodInfoUpdateViewModel, Food_Info>(foodInfoUpdateViewModel, food_Info);
            _IFoodInfoRepository.Update(food_Info_update);
            return _IFoodInfoRepository.SaveChanges();
        }

        public bool Food_Single(FoodInfoValideRepeat foodInfoValideRepeat)
        {

            IQueryable<Food_Info> Queryable_UserDepart = _IFoodInfoRepository
                                                                 .GetInfoByFoodId(foodInfoValideRepeat.Code);
            return (Queryable_UserDepart.Count() < 1) ?
                   true : false;
        }
        /// <summary>
        /// 根据用户和菜单查询点赞
        /// </summary>
        /// <param name="foodByUserSearchViewMode"></param>
        /// <returns></returns>
        public List<User_Relate_Food> Food_Relate_User_Search(FoodByUserSearchViewModel foodByUserSearchViewMode)
        {
            List<User_Relate_Food> Food_Relate_Users = _IRelate_Food_UserRepository.SearchFoodInfoByWhere(foodByUserSearchViewMode);
         
            return Food_Relate_Users;
        }
    }
}
