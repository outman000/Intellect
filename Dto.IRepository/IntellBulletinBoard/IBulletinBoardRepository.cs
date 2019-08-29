using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BulletinBoardViewModel.RequestViewModel;

namespace Dto.IRepository.IntellBulletinBoard
{
    public interface IBulletinBoardRepository : IRepository<Bulletin_Board>
    {
        //批量删除
        int DeleteByBulletinInfoIdList(List<int> IdList);
        // 根据条件查公告栏
        List<Bulletin_Board> SearchInfoByBulletinWhere(BulletinBoardSearchViewModel bulletinBoardSearchViewModel);
        //根据条件查人员缴费数量
        IQueryable<Bulletin_Board> GetBulletinBoardAll(BulletinBoardSearchViewModel  bulletinBoardSearchViewModel);
        //根据公告栏主键id查询
        Bulletin_Board GetInfoByBulletinId(int id);
        //根据公告栏主键id查询
        IQueryable<Bulletin_Board> SearchByBulletinId(int id);

    }
}
