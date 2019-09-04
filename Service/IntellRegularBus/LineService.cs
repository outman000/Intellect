using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusViewModel.MiddleModel;
using ViewModel.BusViewModel.RequestViewModel.LineInfoViewModel;

namespace Dto.Service.IntellRegularBus
{
    public class LineService : ILineService
    {
        private readonly IBusLineRepository _IBusLineRepository;
        private readonly IMapper _IMapper;

        public LineService(IBusLineRepository ibusLineRepository, IMapper mapper)
        {
            _IBusLineRepository = ibusLineRepository;

            _IMapper = mapper;
        }
        /// <summary>
        /// 线路增加
        /// </summary>
        /// <param name="lineAddViewModel"></param>
        /// <returns></returns>
        public int Line_Add(LineAddViewModel lineAddViewModel)
        {
            var bus_Line = _IMapper.Map<LineAddViewModel, Bus_Line>(lineAddViewModel);
            _IBusLineRepository.Add(bus_Line);
            return _IBusLineRepository.SaveChanges();
        }
        /// <summary>
        /// 线路查询
        /// </summary>
        /// <param name="lineSearchViewModel"></param>
        /// <returns></returns>
        public List<LineSearchMiddlecs> Line_Search(LineSearchViewModel lineSearchViewModel)
        {
            List<Bus_Line> line_Infos = _IBusLineRepository.SearchInfoByLineWhere(lineSearchViewModel);

            List<LineSearchMiddlecs> lineSearches = new List<LineSearchMiddlecs>();

            foreach (var item in line_Infos)
            {
                var LineSearchMiddlecs = _IMapper.Map<Bus_Line, LineSearchMiddlecs>(item);
                lineSearches.Add(LineSearchMiddlecs);
            }
            return lineSearches;
        }

        //删除班车（一个或者多个）
        public int Line_Delete(LineDelViewModel lineDelViewModel)
        {
            int DeleteRowsNum = _IBusLineRepository
                 .DeleteByLineIdList(lineDelViewModel.DeleleIdList);
            if (DeleteRowsNum == lineDelViewModel.DeleleIdList.Count)
            {
                return DeleteRowsNum;
            }
            else
            {
                return -1;
            }

        }
        /// <summary>
        /// 线路更新
        /// </summary>
        /// <param name="lineUpdateViewModel"></param>
        /// <returns></returns>
        public int Line_Update(LineUpdateViewModel lineUpdateViewModel)
        {
            var Line_Info = _IBusLineRepository.GetInfoByLineId (lineUpdateViewModel.Id);
            var line_Info = _IMapper.Map<LineUpdateViewModel, Bus_Line>(lineUpdateViewModel, Line_Info);
            _IBusLineRepository.Update(line_Info);
            return _IBusLineRepository.SaveChanges();
        }
       /// <summary>
       /// 验证线路唯一性
       /// </summary>
       /// <param name="busValideRepeat"></param>
       /// <returns></returns>
        public bool Line_Single(BusValideRepeat busValideRepeat)
        {
            IQueryable<Bus_Line> Queryable_UserDepart = _IBusLineRepository
                                                                .GetInfoByLineid(busValideRepeat.Code);
            return (Queryable_UserDepart.Count() < 1) ?
                   true : false;
        }
        /// <summary>
        /// 线路查询数量
        /// </summary>
        /// <param name="lineSearchViewModel"></param>
        /// <returns></returns>
        public int Line_Get_ALLNum(LineSearchViewModel lineSearchViewModel)
        {
            return _IBusLineRepository.GetLineAll(lineSearchViewModel).Count();
        }
    }
}
