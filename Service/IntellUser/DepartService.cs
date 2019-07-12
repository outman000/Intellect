using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.IntellUser
{
   public class DepartService : IDepartService
    {
        private readonly IUserDepartRepository _IUserDepartRepository;
        private readonly IMapper _IMapper;

        public DepartService(IUserDepartRepository iuserDepartRepository, IMapper mapper)
        {
            _IUserDepartRepository = iuserDepartRepository;
            _IMapper = mapper;
        }
        //添加部门

        public int Depart_Add(DepartAddViewModel departAddViewModel)
        {

            var user_Depart = _IMapper.Map<DepartAddViewModel, User_Depart>(departAddViewModel);
            _IUserDepartRepository.Add(user_Depart);
            return _IUserDepartRepository.SaveChanges();
        }
        // //删除部门（一个或者多个）
        public int Depart_Delete(DepartDeleteViewModel departDeleteViewModel)
        {
            int DeleteRowsNum = _IUserDepartRepository
                .DeleteByDepartidList(departDeleteViewModel.DeleleIdList);
            if (DeleteRowsNum == departDeleteViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        //查询部门
        public List<DepartSearchMiddlecs> Depart_Search(DepartSearchViewModel departSearchViewModel)
        {
            List<User_Depart> user_Departs = _IUserDepartRepository.SearchDepartByWhere(departSearchViewModel);

            List<DepartSearchMiddlecs> departSearches = new List<DepartSearchMiddlecs>();

            foreach (var item in user_Departs)
            {
                var DeaprtSearchMiddlecs = _IMapper.Map<User_Depart, DepartSearchMiddlecs>(item);
                departSearches.Add(DeaprtSearchMiddlecs);

            }
            return departSearches;
        }

     

        //单一部门
        public bool Depart_Single(DepartValideRepeat departValideRepeat)
        {
            IQueryable<User_Depart> Queryable_UserDepart = _IUserDepartRepository
                                                                .GetDepartByCode(departValideRepeat.Code);
            return (Queryable_UserDepart.Count() < 1) ?
                   true : false;
        }
    
   
        //更新部门信息
        public int Depart_Update(DepartUpdateViewModel  departUpdateViewModel)
        {
            var user_Depart = _IMapper.Map<DepartUpdateViewModel, User_Depart>(departUpdateViewModel);
            _IUserDepartRepository.Update(user_Depart);
            return _IUserDepartRepository.SaveChanges();
        }


    }
}
