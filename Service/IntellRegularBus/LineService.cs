using AutoMapper;
using Dto.IRepository.IntellRegularBus;
using Dto.IService.IntellRegularBus;
using Dtol.dtol;
using System;
using System.Collections.Generic;
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

        public int Line_Add(LineAddViewModel lineAddViewModel)
        {
            var bus_Line = _IMapper.Map<LineAddViewModel, Bus_Line>(lineAddViewModel);
            _IBusLineRepository.Add(bus_Line);
            return _IBusLineRepository.SaveChanges();
        }

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
    }
}
