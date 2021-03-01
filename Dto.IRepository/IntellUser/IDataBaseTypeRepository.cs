using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.IRepository.IntellUser
{
    public interface IDataBaseTypeRepository : IRepository<DataBase_Type>
    {

        //添加基础信息
        int AddByNum(DataBase_Type obj);
        //批量删除
        List<int> DeleteByDataBaseidList(List<string> IdList);
        //查询
        List<DataBase_Type> SearchDataBaseWhere(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel);
        //根据主键id查询
        DataBase_Type GetInfoByDataBaseid(string id);
        //查询基础信息数量
        List<DataBase_Type> SearchDataBaseNum(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel);
        /// <summary>
        /// 根据楼id查区
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<DataBase_Type> SearchAreaByFloor(string id);

        List<DataBase_Type> SearchAreaByFloorNum(string id);

        /// <summary>
        /// 所有楼
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<DataBase_Type> SearchFloor();

        /// <summary>
        /// 根据区id查楼
        /// </summary>
        /// <param name="bookSearchViewModel"></param>
        /// <returns></returns>
        List<DataBase_Type> SearchFloorByArea(string id);
    }
}
