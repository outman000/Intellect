using AutoMapper;
using Dto.IRepository.IntellBulletinBoard;
using Dto.IRepository.IntellUser;
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
        private readonly IUserInfoRepository _IUserInfoRepository;
        private readonly IMapper _IMapper;

        public BulletinBoardService(IBulletinBoardRepository  bulletinBoardRepository,
                                    IBulletinBoardRelateRoleRepository bulletinBoardRelateRoleRepository,
                                     IUserInfoRepository userInfoRepository,
                                    IMapper mapper)
        {
            _IBulletinBoardRepository = bulletinBoardRepository;
            _IBulletinBoardRelateRoleRepository = bulletinBoardRelateRoleRepository;
            _IUserInfoRepository = userInfoRepository;
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

        /// <summary>
        /// 根据用户Id，查询部门，角色，符合条件的公告栏
        /// </summary>
        /// <param name="bulletinByUserSearchViewModel"></param>
        /// <returns></returns>
        public BulletinBoardRoleSearchMiddlecs BulletinByUserId_Search(BulletinByUserSearchViewModel  bulletinByUserSearchViewModel)
        {

            BulletinBoardRoleSearchMiddlecs  bulletinBoardRoleSearchMiddlecs = new BulletinBoardRoleSearchMiddlecs();
            //公告栏集合
            List<Bulletin_Board>  bulletin_Boards = new List<Bulletin_Board>();
            //获取用户信息
            var user_info = _IUserInfoRepository.GetInfoAndDepartByUserid(bulletinByUserSearchViewModel.UserUid);
            //获取用户相关所有信息（部门，公告栏，角色等等）
            var user_Infos_All = _IBulletinBoardRelateRoleRepository.SearchInfoByWhere(bulletinByUserSearchViewModel.UserUid);
            //匹配相关信息
            bulletinBoardRoleSearchMiddlecs = _IMapper.Map(user_info, bulletinBoardRoleSearchMiddlecs);
            //建有层级关系的权限扁平化
            for (int i = 0; i < user_Infos_All.Count; i++)
            {
                int rightNum = user_Infos_All[i].User_Role.Bulletin_Board_Relate_Role.Count;
                for (int j = 0; j < rightNum; j++)
                {
                    //将外键变为空
                    var tempBoards = user_Infos_All[i].User_Role.Bulletin_Board_Relate_Role[j].Bulletin_Board;
                    int sn = Convert.ToInt32(tempBoards.StayNum);//停留小时数
                     //创建公告时间+停留小时数 转换为时间戳格式
                    TimeSpan ts= tempBoards.AddDate.AddHours(sn).ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    long sdate = Convert.ToInt64(ts.TotalSeconds);
                    //当前时间转为时间戳格式
                    TimeSpan ts2=DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    long edate = Convert.ToInt64(ts2.TotalSeconds);
                    //当前时间 在限制的时间内 则显示，否则不显示
                    if (sdate > edate)
                    {
                    
                         bulletin_Boards.Add(tempBoards);
                    }
                }
            }

            bulletinBoardRoleSearchMiddlecs.Bulletin_Board = bulletin_Boards;
            return bulletinBoardRoleSearchMiddlecs;
        }

    }
}
