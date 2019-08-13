using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BulletinBoardViewModel.MiddleModel;
using ViewModel.BulletinBoardViewModel.RequestViewModel;

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
    }
}
