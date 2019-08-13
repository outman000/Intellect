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

namespace Dto.Service.IntellBulletinBoard
{
    public class BulletinBoardService : IBulletinBoardService
    {
        private readonly IBulletinBoardRepository _IBulletinBoardRepository;
      
        private readonly IMapper _IMapper;

        public BulletinBoardService(IBulletinBoardRepository  bulletinBoardRepository,
                           IMapper mapper)
        {
            _IBulletinBoardRepository = bulletinBoardRepository;
            _IMapper = mapper;
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
    }
}
