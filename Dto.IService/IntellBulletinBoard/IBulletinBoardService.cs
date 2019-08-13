using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.BulletinBoardViewModel.RequestViewModel;
using ViewModel.UserViewModel.MiddleModel;

namespace Dto.IService.IntellBulletinBoard
{
    public interface IBulletinBoardService
    {
        /// <summary>
        /// 添加公告栏信息
        /// </summary>
        /// <param name="bulletinBoardAddViewModel"></param>
        /// <returns></returns>
        int BulletinBoard_Add(BulletinBoardAddViewModel  bulletinBoardAddViewModel);
        /// <summary>
        /// 更新公告栏信息
        /// </summary>
        /// <param name="bulletinBoardUpdateViewModel"></param>
        /// <returns></returns>
        int BulletinBoard_Update(BulletinBoardUpdateViewModel  bulletinBoardUpdateViewModel);
        /// <summary>
        /// 查询公告栏信息
        /// </summary>
        /// <param name="foodInfoSearchViewModel"></param>
        List<BulletinBoardSearchMiddlecs> Bulletin_Board_Search(BulletinBoardSearchViewModel bulletinBoardSearchViewModel);
        /// <summary>
        /// 获取公告栏信息总数
        /// </summary>
        /// <returns></returns>
        int BulletinBoard_Get_ALLNum(BulletinBoardSearchViewModel bulletinBoardSearchViewModel);
        
        /// <summary>
        /// 删除公告栏信息
        /// </summary>
        /// <param name="bulletinBoardDelViewModel"></param>
        /// <returns></returns>
        int BulletinBoard_Delete(BulletinBoardDelViewModel  bulletinBoardDelViewModel);


        /// <summary>
        /// 根据公告栏查角色
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        List<UserRoleSearChMiddles> Role_By_Bulletin_Search(RoleByBulletinSearchViewModel  roleByBulletinSearchViewModel);
      
        /// <summary>
        /// 根据公告栏查角色总数
        /// </summary>
        /// <param name="roleByBulletinSearchViewModel"></param>
        /// <returns></returns>
        int Role_By_Bulletin_Get_ALLNum(RoleByBulletinSearchViewModel roleByBulletinSearchViewModel);

        /// <summary>
        /// 给公告栏分配角色
        /// </summary>
        /// <param name="roleByBulletinAddViewModel"></param>
        /// <returns></returns>
        int BulletinBoardToRole_Add(RoleByBulletinAddViewModel  roleByBulletinAddViewModel);

        /// <summary>
        /// 给公告栏删除角色
        /// </summary>
        /// <param name="roleByBulletinDelViewModel"></param>
        /// <returns></returns>
        int BulletinBoardToRole_Del(RoleByBulletinDelViewModel  roleByBulletinDelViewModel);
    }
}
