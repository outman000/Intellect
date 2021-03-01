using AutoMapper;
using Dto.IRepository.IntellUser;
using Dto.IService.IntellUser;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.RoomViewModel.MiddleModel;
using ViewModel.RoomViewModel.RequestViewModel;

namespace Dto.Service.IntellUser
{
    public class DataBaseTypeService : IDataBaseTypeService
    {
        private readonly IDataBaseTypeRepository _IDataBaseTypeRepository;
        private readonly IMapper _IMapper;

        public DataBaseTypeService(IDataBaseTypeRepository dataBaseTypeRepository, IMapper mapper)
        {
            _IDataBaseTypeRepository = dataBaseTypeRepository;
            _IMapper = mapper;

        }

        /// <summary>
        /// 增加基础信息
        /// </summary>
        /// <param name="dataBaseTypeAddViewModel"></param>
        /// <returns></returns>

        public int DataBase_Add(DataBaseTypeAddViewModel dataBaseTypeAddViewModel)
        {
            var database_type = _IMapper.Map<DataBaseTypeAddViewModel, DataBase_Type>(dataBaseTypeAddViewModel);
            database_type.IsDelete = "0";
            database_type.Status = "0";
            database_type.CreateDate = DateTime.Now;
            _IDataBaseTypeRepository.AddByNum(database_type);
            return _IDataBaseTypeRepository.SaveChanges();

        }

        /// <summary>
        /// 删除基础信息
        /// </summary>
        /// <param name="dataBaseTypeDeleteViewModel"></param>
        /// <returns></returns>
        public List<int> DataBase_Delete(DataBaseTypeDeleteViewModel dataBaseTypeDeleteViewModel)
        {
            List<int> DeleteRowsNum = _IDataBaseTypeRepository
                .DeleteByDataBaseidList(dataBaseTypeDeleteViewModel.DeleteIdList);

            return DeleteRowsNum;

        }
        /// <summary>
        ///  查询基础信息
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        public List<DataBaseTypeSearchMiddle> DataBase_Search(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {

            List<DataBase_Type> database_type = _IDataBaseTypeRepository.SearchDataBaseWhere(dataBaseTypeSearchViewModel);
            var result = _IMapper.Map<List<DataBase_Type>, List<DataBaseTypeSearchMiddle>>(database_type);
            return result;
        }
        /// <summary>
        ///  根据楼查区
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        public List<DataBaseTypeSearchMiddle> SearchAreaByFloor(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {

            List<DataBase_Type> database_type = _IDataBaseTypeRepository.SearchDataBaseWhere(dataBaseTypeSearchViewModel);

            List<DataBase_Type> floor_searchArea = _IDataBaseTypeRepository.SearchAreaByFloor(database_type[0].Id.ToString());
            var result = _IMapper.Map<List<DataBase_Type>, List<DataBaseTypeSearchMiddle>>(floor_searchArea);

            return result;
        }

        /// <summary>
        ///  根据楼查区数量
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        public int SearchAreaByFloorNum(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {

            List<DataBase_Type> database_type = _IDataBaseTypeRepository.SearchDataBaseWhere(dataBaseTypeSearchViewModel);

            List<DataBase_Type> floor_searchArea = _IDataBaseTypeRepository.SearchAreaByFloorNum(database_type[0].Id.ToString());

            return floor_searchArea.Count;
        }
        /// <summary>
        /// 查询基础信息数量
        /// </summary>
        /// <param name="dataBaseTypeSearchViewModel"></param>
        /// <returns></returns>
        public int DataBase_SearchNum(DataBaseTypeSearchViewModel dataBaseTypeSearchViewModel)
        {

            List<DataBase_Type> database_type = _IDataBaseTypeRepository.SearchDataBaseNum(dataBaseTypeSearchViewModel);
            return database_type.Count;
        }
        /// <summary>
        /// 更改基础信息
        /// </summary>
        /// <param name="BookUpdateViewModel"></param>
        /// <returns></returns>
        //public int DataBase_Update(DataBaseTypeUpdateViewModel dataBaseTypeUpdateViewModel)
        //{
        //    var room_information = _IDataBaseTypeRepository.GetInfoByDataBaseid(dataBaseTypeUpdateViewModel.Id);
        //    var room_Information_Result = _IMapper.Map<RoomInformationUpdateViewModel, MeetingRoom_Information>(roomInformationUpdateViewModel, room_information);
        //    room_Information_Result.UpdateDate = DateTime.Now;
        //    _IRoomInformationRepository.Update(room_Information_Result);
        //    return _IRoomInformationRepository.SaveChanges();
        //}
    }
}
