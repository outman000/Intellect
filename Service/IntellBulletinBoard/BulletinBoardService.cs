using AutoMapper;
using Dto.IRepository.IntellBulletinBoard;
using Dto.IService.IntellBulletinBoard;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.BulletinBoardViewModel.RequestViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.Service.IntellBulletinBoard
{
    public class BulletinBoardService : IBulletinBoardService
    {
        private readonly IBulletinBoardRepository _IBulletinBoardRepository;
        private readonly IBulletinBoardRelateRoleRepository _IBulletinBoardRelateRoleRepository;
        private readonly IMapper _IMapper;

        public BulletinBoardService(IBulletinBoardRepository  bulletinBoardRepository,
                                    IBulletinBoardRelateRoleRepository bulletinBoardRelateRoleRepository,
                                    IMapper mapper)
        {
            _IBulletinBoardRepository = bulletinBoardRepository;
            _IBulletinBoardRelateRoleRepository = bulletinBoardRelateRoleRepository;
            _IMapper = mapper;
        }
        /// <summary>
        /// 给公告栏分配角色
        /// </summary>
        /// <param name="roleByBulletinAddViewModel"></param>
        /// <returns></returns>
        public int BulletinBoardToRole_Add(RoleByBulletinAddViewModel roleByBulletinAddViewModel)
        {
            //获取视图集合
            List<RelateRoleBulletinAddMiddlecs> relateBulletinIdandRoleIdList = roleByBulletinAddViewModel.RelateBulletinIdandRoleIdList;
            //将视图模型和转为领域模型集合
            List<Bulletin_Board_Relate_Role> bulletin_Relate_Role = _IMapper.Map<List<RelateRoleBulletinAddMiddlecs>, List<Bulletin_Board_Relate_Role>>(relateBulletinIdandRoleIdList);

            int AddNum = _IBulletinBoardRelateRoleRepository
                       .RelateBulletinToRole(bulletin_Relate_Role);

            return AddNum;
        }
        /// <summary>
        /// 根据公告栏删除角色
        /// </summary>
        /// <param name="roleByBulletinDelViewModel"></param>
        /// <returns></returns>
        public int BulletinBoardToRole_Del(RoleByBulletinDelViewModel roleByBulletinDelViewModel)
        {

            int DelNum = _IBulletinBoardRelateRoleRepository
                       .RelateBulletinToRoleDel(roleByBulletinDelViewModel.RelateBulletinIdandRoleIdList);

            return DelNum;
        }

        /// <summary>
        /// 增加公告信息
        /// </summary>
        /// <param name="bulletinBoardAddViewModel"></param>
        /// <returns></returns>
        public int BulletinBoard_Add(BulletinBoardAddViewModel bulletinBoardAddViewModel)
        {
            var food_Info = _IMapper.Map<BulletinBoardAddViewModel, Bulletin_Board>(bulletinBoardAddViewModel);
            _IBulletinBoardRepository.Add(food_Info);
            return _IBulletinBoardRepository.SaveChanges();
        }

        /// <summary>
        /// 删除公告信息
        /// </summary>
        /// <param name="bulletinBoardDelViewModel"></param>
        /// <returns></returns>
        public int BulletinBoard_Delete(BulletinBoardDelViewModel bulletinBoardDelViewModel)
        {
            int DeleteRowsNum = _IBulletinBoardRepository
                  .DeleteByBulletinInfoIdList(bulletinBoardDelViewModel.DeleleIdList);
            if (DeleteRowsNum == bulletinBoardDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 查询公告栏信息数量
        /// </summary>
        /// <param name="bulletinBoardSearchViewModel"></param>
        /// <returns></returns>
        public int BulletinBoard_Get_ALLNum(BulletinBoardSearchViewModel bulletinBoardSearchViewModel)
        {
            return _IBulletinBoardRepository.GetBulletinBoardAll(bulletinBoardSearchViewModel).Count();
        }

        /// <summary>
        /// 更改公告栏信息
        /// </summary>
        /// <param name="bulletinBoardUpdateViewModel"></param>
        /// <returns></returns>
        public int BulletinBoard_Update(BulletinBoardUpdateViewModel bulletinBoardUpdateViewModel)
        {
            var bulletin_Info = _IBulletinBoardRepository.GetInfoByBulletinId(bulletinBoardUpdateViewModel.Id);
            var bulletin_Info_update = _IMapper.Map<BulletinBoardUpdateViewModel, Bulletin_Board>(bulletinBoardUpdateViewModel, bulletin_Info);
            _IBulletinBoardRepository.Update(bulletin_Info_update);
            return _IBulletinBoardRepository.SaveChanges();
        }

        /// <summary>
        /// 查询公告栏信息
        /// </summary>
        /// <param name="bulletinBoardSearchViewModel"></param>
        /// <returns></returns>
        public List<BulletinBoardSearchMiddlecs> Bulletin_Board_Search(BulletinBoardSearchViewModel bulletinBoardSearchViewModel)
        {
            List<Bulletin_Board> bulletin_Board = _IBulletinBoardRepository.SearchInfoByBulletinWhere(bulletinBoardSearchViewModel);
            List<BulletinBoardSearchMiddlecs> boardSearchMiddlecs = new List<BulletinBoardSearchMiddlecs>();

            foreach (var item in bulletin_Board)
            {
                var BusSearchMiddlecs = _IMapper.Map<Bulletin_Board, BulletinBoardSearchMiddlecs>(item);
                boardSearchMiddlecs.Add(BusSearchMiddlecs);

            }
            return boardSearchMiddlecs;
        }
        /// <summary>
        /// 根据公告栏查角色总数
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        public int Role_By_Bulletin_Get_ALLNum(RoleByBulletinSearchViewModel roleByBulletinSearchViewModel)
        {
            return _IBulletinBoardRelateRoleRepository.GetRoleByBulletinAll(roleByBulletinSearchViewModel).Count();
        }

        /// <summary>
        /// 根据公告查角色
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        public List<UserRoleSearChMiddles> Role_By_Bulletin_Search(RoleByBulletinSearchViewModel roleByBulletinSearchViewModel)
        {
            List<Bulletin_Board_Relate_Role> bulletin_Relate_Info_Roles = _IBulletinBoardRelateRoleRepository.SearchRoleInfoByWhere(roleByBulletinSearchViewModel);
            List<UserRoleSearChMiddles> user_roles = new List<UserRoleSearChMiddles>();

            foreach (var item in bulletin_Relate_Info_Roles)
            {
                var user_role_temp = _IMapper.Map<User_Role, UserRoleSearChMiddles>(item.User_Role);
                user_roles.Add(user_role_temp);
            }
            return user_roles;
        }
    }
}
