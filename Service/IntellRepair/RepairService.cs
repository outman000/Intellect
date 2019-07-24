using AutoMapper;
using Dto.IRepository.IntellRepair;
using Dto.IService.IntellRepair;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.RepairsViewModel.MiddleModel;
using ViewModel.RepairsViewModel.RequestViewModel;

namespace Dto.Service.IntellRepair
{
    public class RepairService : IRepairService
    {
        private readonly IRepairInfoRepository _IRepairInfoRepository;
        private readonly IMapper _IMapper;

        public RepairService(IRepairInfoRepository irepairInfoRepository, IMapper mapper)
        {
            _IRepairInfoRepository = irepairInfoRepository;

            _IMapper = mapper;
        }

        public List<RepairInfoSearchMiddlecs> Repair_Search(RepairInfoSearchViewModel repairInfoSearchViewModel)
        {
            RepairInfoSearchMiddlecs repairSearches = new RepairInfoSearchMiddlecs();
            List<Repair_Info> line_Infos = _IRepairInfoRepository.SearchInfoByRepairWhere(repairInfoSearchViewModel).ToList();

            var repairSearchMiddlecs = _IMapper.Map< List<Repair_Info>, List<RepairInfoSearchMiddlecs>>(line_Infos);
             
            return repairSearchMiddlecs;
        }
    }
}
