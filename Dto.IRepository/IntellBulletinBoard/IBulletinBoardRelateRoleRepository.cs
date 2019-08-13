using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.BulletinBoardViewModel.RequestViewModel;

namespace Dto.IRepository.IntellBulletinBoard
{
    public interface IBulletinBoardRelateRoleRepository : IRepository<Bulletin_Board_Relate_Role>
    {
        /// <summary>
        /// 给公告栏添加角色
        /// </summary>
        /// <param name="Bulletin_BoardId"></param>
        /// <param name="User_RoleId"></param>
        /// <returns></returns>
        int RelateBulletinToRole(List<Bulletin_Board_Relate_Role> list);
        /// <summary>
        /// 给公告栏删除角色
        /// </summary>
        /// <param name="Bulletin_BoardId"></param>
        /// <param name="User_RoleId"></param>
        /// <returns></returns>
        int RelateBulletinToRoleDel(List<RelateRoleBulletinDelMiddlecs> list);
        /// <summary>
        /// 根据公告栏查角色
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        List<Bulletin_Board_Relate_Role> SearchRoleInfoByWhere(RoleByBulletinSearchViewModel  roleByBulletinSearchViewModel);

        /// <summary>
        /// 根据公告栏查角色数量
        /// </summary>
        /// <param name="userRoleSearchViewModel"></param>
        /// <returns></returns>
        IQueryable<Bulletin_Board_Relate_Role> GetRoleByBulletinAll(RoleByBulletinSearchViewModel roleByBulletinSearchViewModel);
    }
}
