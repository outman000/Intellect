using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.IService.IntellUser
{
    public interface IDataBaseTypeService
    {
        /// <summary>
        ///  根据楼查区
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        List<DataBaseTypeSearchMiddle> SearchAreaByFloor(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel);

        /// <summary>
        ///  查询基础信息
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        List<DataBaseTypeSearchMiddle> DataBase_Search(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel);

        /// <summary>
        /// 查询基础信息数量
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        int DataBase_SearchNum(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel);

        /// <summary>
        ///  根据楼查区数量
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        int SearchAreaByFloorNum(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel);
    }
}
